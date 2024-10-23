using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace YemekTarifiUygulamasi
{
    public partial class TarifEkleForm : Form
    {
        private Form1 form1; // Form1 referansı
        string connectionString = "Server=localhost;Database=yemektarifidb;Uid=root;Pwd=1234;";
        private string selectedImagePath = string.Empty; // Seçilen görselin dosya yolu
        private MalzemeEkleForm malzemeEkleForm;
        public TarifEkleForm(Form1 form1, MalzemeEkleForm malzemeEkleForm) // Form1 referansı parametre olarak alınıyor
        {
            InitializeComponent();
            this.form1 = form1; // Form1 referansını ayarlıyoruz
            LoadCategories(); // Kategorileri yükle
            lstTalimatlar.ScrollAlwaysVisible = true; // Kaydırma çubuğunu her zaman görünür yap
            lstTalimatlar.HorizontalScrollbar = true;
            pbGorsel.Click += pbGorsel_Click;  // Görsel seçim işlemi için tıklama olayını bağla
            this.malzemeEkleForm = malzemeEkleForm;
        }

        private void LoadCategories()
        {
            // ComboBox'ı kategoriler ile doldur
            cmbKategori.Items.AddRange(new object[]
            {
                "Atıştırmalıklar",
                "Tatlılar",
                "İçecekler",
                "Sebze Yemekleri",
                "Kahvaltılıklar",
                "Ana Yemekler"
            });
        }

        private void ClearForm()
        {
            // Formu temizle
            txtTarifAdi.Clear();
            cmbKategori.SelectedIndex = -1;
            txtHazirlamaSuresi.Clear();
            pbGorsel.Image = null; // Görseli temizle
            selectedImagePath = string.Empty; // Seçilen görsel yolunu temizle
            lstTalimatlar.Items.Clear(); // Talimatlar listesini temizle
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            // Tarif ekleme işlemi
            if (!string.IsNullOrEmpty(txtTarifAdi.Text) && !string.IsNullOrEmpty(cmbKategori.SelectedItem?.ToString())
                && int.TryParse(txtHazirlamaSuresi.Text, out int hazirlamaSuresi)
                && lstTalimatlar.Items.Count > 0 // Talimatlar eklenmiş olmalı
                && !string.IsNullOrEmpty(selectedImagePath))
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        // Önce veritabanında aynı isimde tarif olup olmadığını kontrol et
                        MySqlCommand checkCommand = new MySqlCommand("SELECT COUNT(*) FROM Tarifler WHERE TarifAdi = @TarifAdi", connection);
                        checkCommand.Parameters.AddWithValue("@TarifAdi", txtTarifAdi.Text);

                        int tarifCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                        // Eğer aynı isimde bir tarif varsa eklemeyi durdur
                        if (tarifCount > 0)
                        {
                            MessageBox.Show("Bu isimde bir tarif zaten mevcut. Lütfen başka bir isim seçin.");
                            return;
                        }

                        // Görseli belirttiğiniz dizine kaydetmek için dosya adını kullanıyoruz
                        string imageFileName = Path.GetFileName(selectedImagePath);
                        string imageSavePath = Path.Combine(@"C:\Users\iclal dere\source\YemekTarifiUygulamasi\YemekTarifiUygulamasi\Resources", imageFileName);

                        // Eğer dizin yoksa oluştur
                        if (!Directory.Exists(@"C:\Users\iclal dere\source\YemekTarifiUygulamasi\YemekTarifiUygulamasi\Resources"))
                        {
                            Directory.CreateDirectory(@"C:\Users\iclal dere\source\YemekTarifiUygulamasi\YemekTarifiUygulamasi\Resources");
                        }

                        // Dosyayı hedef dizine kopyala
                        File.Copy(selectedImagePath, imageSavePath, true);

                        // Tarif ismi benzersiz olduğuna göre eklemeye devam edebiliriz
                        MySqlCommand command = new MySqlCommand("INSERT INTO Tarifler (TarifAdi, Kategori, HazirlamaSuresi, Talimatlar, GorselAdi) VALUES (@TarifAdi, @Kategori, @HazirlamaSuresi, @Talimatlar, @GorselAdi); SELECT LAST_INSERT_ID();", connection);
                        command.Parameters.AddWithValue("@TarifAdi", txtTarifAdi.Text);
                        command.Parameters.AddWithValue("@Kategori", cmbKategori.SelectedItem.ToString());
                        command.Parameters.AddWithValue("@HazirlamaSuresi", hazirlamaSuresi);

                        // Talimatlar ListBox'ındaki tüm maddeleri birleştir
                        string talimatlar = string.Join("\n", lstTalimatlar.Items.Cast<string>());
                        command.Parameters.AddWithValue("@Talimatlar", talimatlar);
                        command.Parameters.AddWithValue("@GorselAdi", imageFileName); // Görsel dosya adını kaydet

                        int yeniTarifId = Convert.ToInt32(command.ExecuteScalar());
                        MessageBox.Show("Tarif başarıyla eklendi.");

                        // Malzeme ilişkisi formunu aç
                        TarifMalzemeIliskisiForm malzemeIliskisiForm = new TarifMalzemeIliskisiForm(form1, yeniTarifId);
                        this.Close(); // Formu kapat
                        this.Hide(); // Formu gizler

                        form1.Hide();
                        malzemeIliskisiForm.ShowDialog();

                        ClearForm(); // Formu temizle

                        // Form1'deki DataGridView'i güncelle
                        form1.LoadTarifler(); // DataGridView'i güncellemeye yönelik metodu çağır
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurun ve bir görsel seçin.");
            }
        }


        // Görsel seçim işlemi, PictureBox'a tıklanarak yapılacak
        private void pbGorsel_Click(object sender, EventArgs e)
        {
            // Görsel seçme işlemi
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = ofd.FileName;
                pbGorsel.ImageLocation = selectedImagePath; // Seçilen görseli PictureBox'a yükle
                pbGorsel.SizeMode = PictureBoxSizeMode.Zoom;

                // Eğer görsel yüklenirse, PictureBox içinde değişiklik yapılmadığı takdirde aynı görseli tekrar seçebiliriz
                pbGorsel.Invalidate(); // PictureBox'ı günceller
                pbGorsel.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }


        private void btnMaddeEkle_Click_1(object sender, EventArgs e)
        {
            // Talimat maddesi ekleme
            string madde = txtMadde.Text.Trim();

            if (!string.IsNullOrEmpty(madde))
            {
                lstTalimatlar.Items.Add(madde); // Listeye madde ekle
                txtMadde.Clear(); // Madde girişini temizle
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir madde girin.");
            }
        }

        private void pbGorsel_Paint(object sender, PaintEventArgs e)
        {
            string message = "Resim Ekleyin";

            // PictureBox'ın sınırlarını al
            Rectangle rect = new Rectangle(0, 0, pbGorsel.Width - 1, pbGorsel.Height - 1);

            // Çerçevenin rengini ve kalınlığını belirleyin
            Pen pen = new Pen(Color.Black, 3); // Siyah ve kalınlığı 3 olan bir çerçeve

            // Çerçeveyi çizin
            e.Graphics.DrawRectangle(pen, rect);

            // Kaynakları serbest bırakın
            pen.Dispose();
        }

        private void TarifEkleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Show();
        }

      
    }
}

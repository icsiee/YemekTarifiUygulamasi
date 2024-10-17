using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Windows.Forms;

namespace YemekTarifiUygulamasi
{
    public partial class TarifEkleForm : Form
    {
        string connectionString = "Server=localhost;Database=yemektarifidb;Uid=root;Pwd=1234;";
        private string selectedImagePath = string.Empty; // Seçilen görselin dosya yolu

        public TarifEkleForm()
        {
            InitializeComponent();
            LoadCategories(); // Load categories
        }

        private void LoadCategories()
        {
            // Populate categories in ComboBox
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
            // Clear the form
            txtTarifAdi.Clear();
            cmbKategori.SelectedIndex = -1;
            txtHazirlamaSuresi.Clear();
            txtTalimatlar.Clear();
            pbGorsel.Image = null; // Görseli temizle
            selectedImagePath = string.Empty; // Seçilen görsel yolunu temizle
        }


        private void btnEkle_Click(object sender, EventArgs e)
        {
            // Add recipe to the database
            if (!string.IsNullOrEmpty(txtTarifAdi.Text) && !string.IsNullOrEmpty(cmbKategori.SelectedItem?.ToString())
                && int.TryParse(txtHazirlamaSuresi.Text, out int hazirlamaSuresi)
                && !string.IsNullOrEmpty(txtTalimatlar.Text) && !string.IsNullOrEmpty(selectedImagePath))
            {
                try
                {
                    // Görseli projenin Images klasörüne kaydetmek için dosya adını kullanıyoruz
                    string imageFileName = Path.GetFileName(selectedImagePath);
                    string imageSavePath = Path.Combine(Application.StartupPath, "Images", imageFileName);

                    // Eğer dizin yoksa oluştur
                    if (!Directory.Exists(Path.Combine(Application.StartupPath, "Images")))
                    {
                        Directory.CreateDirectory(Path.Combine(Application.StartupPath, "Images"));
                    }

                    // Dosyayı hedef dizine kopyala
                    File.Copy(selectedImagePath, imageSavePath, true);

                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        // Aynı isimde başka bir tarif olup olmadığını kontrol et
                        MySqlCommand checkCommand = new MySqlCommand("SELECT COUNT(*) FROM Tarifler WHERE TarifAdi = @TarifAdi", connection);
                        checkCommand.Parameters.AddWithValue("@TarifAdi", txtTarifAdi.Text);

                        int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (count > 0)
                        {
                            // Eğer aynı isimde tarif varsa kullanıcıya uyarı ver
                            MessageBox.Show("Bu isimde başka bir tarif zaten mevcut. Lütfen başka bir isim girin.");
                        }
                        else
                        {
                            // Tarif ismi benzersizse eklemeye devam et
                            MySqlCommand command = new MySqlCommand("INSERT INTO Tarifler (TarifAdi, Kategori, HazirlamaSuresi, Talimatlar, GorselAdi) VALUES (@TarifAdi, @Kategori, @HazirlamaSuresi, @Talimatlar, @GorselAdi); SELECT LAST_INSERT_ID();", connection);
                            command.Parameters.AddWithValue("@TarifAdi", txtTarifAdi.Text);
                            command.Parameters.AddWithValue("@Kategori", cmbKategori.SelectedItem.ToString());
                            command.Parameters.AddWithValue("@HazirlamaSuresi", hazirlamaSuresi);
                            command.Parameters.AddWithValue("@Talimatlar", txtTalimatlar.Text);
                            command.Parameters.AddWithValue("@GorselAdi", imageFileName); // Görsel dosya adını kaydet

                            int yeniTarifId = Convert.ToInt32(command.ExecuteScalar());
                            MessageBox.Show("Tarif başarıyla eklendi.");

                            // Malzeme ilişkisi formunu aç
                            TarifMalzemeIliskisiForm malzemeIliskisiForm = new TarifMalzemeIliskisiForm(yeniTarifId);
                            malzemeIliskisiForm.ShowDialog();

                            ClearForm(); // Formu temizle
                        }
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


        private void btnResimSec_Click_1(object sender, EventArgs e)
        {
            // Open file dialog to select an image
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = ofd.FileName;
                pbGorsel.ImageLocation = selectedImagePath; // Seçilen görseli PictureBox'a yükle
            }
        }
    }
}

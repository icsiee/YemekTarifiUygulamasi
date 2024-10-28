using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace YemekTarifiUygulamasi
{
    public partial class TarifDetayForm : Form
    {
        private long tarifId;
        private Form1 form1;

        public TarifDetayForm(long tarifId, Form1 form1)
        {
            InitializeComponent();
            this.tarifId = tarifId; // Parametre olarak gelen tarifId'yi sakla
            LoadTarifDetails(); // Detayları yükle
            LoadIngredients(); // Malzemeleri yükle
            this.form1 = form1;
            pictureBoxTarif.Click += PictureBoxTarif_Click; // PictureBox'a tıklama olayını bağla
        }

        private void LoadTarifDetails()
        {
            string connectionString = "Server=localhost;Database=yemektarifidb;Uid=root;Pwd=1234"; // Veritabanı bağlantı dizesi
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT TarifAdi, Talimatlar, GorselAdi FROM tarifler WHERE TarifID = @tarifId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@tarifId", tarifId);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblTarifAdi.Text = reader.GetString("TarifAdi"); // Tarif adını ekle
                        txtTalimatlar.Text = reader.GetString("Talimatlar"); // Talimatları ekle

                        // Görselin projenin Resources klasöründen yüklenmesi
                        string imageFileName = reader.GetString("GorselAdi");
                        string imagePath = Path.Combine(@"C:\Users\iclal dere\source\YemekTarifiUygulamasi\YemekTarifiUygulamasi\Resources", imageFileName);

                        if (File.Exists(imagePath))
                        {
                            pictureBoxTarif.SizeMode = PictureBoxSizeMode.Zoom; // Resmi orantılı şekilde sığdır
                            pictureBoxTarif.ImageLocation = imagePath; // Resmi göster
                        }
                        else
                        {
                            MessageBox.Show("Görsel bulunamadı.");
                        }
                    }
                }
            }
        }

        private void LoadIngredients()
        {
            string connectionString = "Server=localhost;Database=yemektarifidb;Uid=root;Pwd=1234"; // Veritabanı bağlantı dizesi
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT m.MalzemeID, m.MalzemeAdi, mi.MalzemeMiktar FROM tarifmalzemeiliskisi mi JOIN malzemeler m ON mi.MalzemeID = m.MalzemeID WHERE mi.TarifID = @tarifId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@tarifId", tarifId);

                MySqlDataReader reader = command.ExecuteReader();

                // DataGridView sütunlarını oluştur
                dataGridViewMalzemeler.Columns.Clear();
                DataGridViewTextBoxColumn malzemeIdColumn = new DataGridViewTextBoxColumn
                {
                    Name = "MalzemeID",
                    HeaderText = "Malzeme ID",
                    Visible = false // Sütunu gizli yap
                };
                dataGridViewMalzemeler.Columns.Add(malzemeIdColumn);
                dataGridViewMalzemeler.Columns.Add("MalzemeAdi", "Malzeme Adı");
                dataGridViewMalzemeler.Columns.Add("MalzemeMiktar", "Malzeme Miktarı");
                DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn
                {
                    Name = "Sil",
                    HeaderText = "Sil",
                    Text = "Sil",
                    UseColumnTextForButtonValue = true // Butonun metnini ayarla
                };
                dataGridViewMalzemeler.Columns.Add(deleteColumn);

                // Malzemeleri DataGridView'e ekle
                while (reader.Read())
                {
                    int rowIndex = dataGridViewMalzemeler.Rows.Add();
                    dataGridViewMalzemeler.Rows[rowIndex].Cells["MalzemeID"].Value = reader.GetInt32("MalzemeID"); // Malzeme ID'sini ekle
                    dataGridViewMalzemeler.Rows[rowIndex].Cells["MalzemeAdi"].Value = reader.GetString("MalzemeAdi");
                    dataGridViewMalzemeler.Rows[rowIndex].Cells["MalzemeMiktar"].Value = reader.GetFloat("MalzemeMiktar");
                    dataGridViewMalzemeler.Rows[rowIndex].Cells["Sil"].Value = "Sil"; // Sil butonunun görünümünü ayarla
                }
            }
        }

        private void PictureBoxTarif_Click(object sender, EventArgs e)
        {
            // Resim seçme işlemi
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = ofd.FileName;
                string imageFileName = Path.GetFileName(selectedImagePath);
                string imageSavePath = Path.Combine(@"C:\Users\iclal dere\source\YemekTarifiUygulamasi\YemekTarifiUygulamasi\Resources", imageFileName);

                // Dosyayı hedef dizine kopyala
                File.Copy(selectedImagePath, imageSavePath, true);

                // Görseli PictureBox'a yükle
                pictureBoxTarif.ImageLocation = imageSavePath;

                // Görsel adı veritabanında güncellenmeli
                UpdateRecipeImage(imageFileName);
            }
        }

        private void UpdateRecipeImage(string newImageName)
        {
            string connectionString = "Server=localhost;Database=yemektarifidb;Uid=root;Pwd=1234"; // Veritabanı bağlantı dizesi
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE tarifler SET GorselAdi = @GorselAdi WHERE TarifID = @tarifId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@GorselAdi", newImageName);
                command.Parameters.AddWithValue("@tarifId", tarifId);
                command.ExecuteNonQuery();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Tarif detaylarını kaydet
            SaveTarifDetails();
            this.Hide();
        }

        private void SaveTarifDetails()
        {
            string connectionString = "Server=localhost;Database=yemektarifidb;Uid=root;Pwd=1234"; // Veritabanı bağlantı dizesi
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE tarifler SET TarifAdi = @tarifAdi, Talimatlar = @talimatlar WHERE TarifID = @tarifId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@tarifAdi", lblTarifAdi.Text);
                command.Parameters.AddWithValue("@talimatlar", txtTalimatlar.Text);
                command.Parameters.AddWithValue("@tarifId", tarifId);
                command.ExecuteNonQuery();
            }
        }

        private void dataGridViewMalzemeler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewMalzemeler.Columns["Sil"].Index && e.RowIndex >= 0)
            {
                // Silme işlemi
                DialogResult result = MessageBox.Show("Bu malzemeyi silmek istediğinize emin misiniz?", "Sil", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Malzeme ID'sini gizli bir hücrede saklayalım
                    int malzemeId = (int)dataGridViewMalzemeler.Rows[e.RowIndex].Cells["MalzemeID"].Value;
                    DeleteMalzeme(malzemeId);
                    dataGridViewMalzemeler.Rows.RemoveAt(e.RowIndex); // Satırı DataGridView'den kaldır
                }
            }
        }

        private void DeleteMalzeme(int malzemeId)
        {
            string connectionString = "Server=localhost;Database=yemektarifidb;Uid=root;Pwd=1234"; // Veritabanı bağlantı dizesi
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM tarifmalzemeiliskisi WHERE MalzemeID = @malzemeId AND TarifID = @tarifId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@malzemeId", malzemeId);
                command.Parameters.AddWithValue("@tarifId", tarifId);
                command.ExecuteNonQuery();
            }
        }

        private void txtTalimatlar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

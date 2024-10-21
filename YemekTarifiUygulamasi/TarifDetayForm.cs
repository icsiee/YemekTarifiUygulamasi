using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Diagnostics;

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
            this.form1 = form1;
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

                        // Görselin projenin Images klasöründen yüklenmesi
                        string imageFileName = reader.GetString("GorselAdi");
                        string imagePath = Path.Combine(Application.StartupPath, "Images", imageFileName);
                        if (File.Exists(imagePath))
                        {
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

        
    }
}

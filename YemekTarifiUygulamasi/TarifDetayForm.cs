using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace YemekTarifiUygulamasi
{
    public partial class TarifDetayForm : Form
    {
        private long tarifId;

        public TarifDetayForm(long tarifId)
        {
            InitializeComponent();
            this.tarifId = tarifId; // Parametre olarak gelen tarifId'yi sakla
            LoadTarifDetails(); // Detayları yükle
        }

        private void LoadTarifDetails()
        {
            string connectionString = "Server=localhost;Database=yemektarifidb;Uid=root;Pwd=1234;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT TarifAdi, Talimatlar, GorselYolu FROM tarifler WHERE TarifID = @tarifId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@tarifId", tarifId);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblTarifAdi.Text = reader.GetString("TarifAdi"); // Tarif adını ekle
                        txtTalimatlar.Text = reader.GetString("Talimatlar"); // Talimatları ekle
                        pictureBoxTarif.ImageLocation = reader.GetString("GorselYolu"); // Resmi göster
                    }
                }
            }
        }
    }
}

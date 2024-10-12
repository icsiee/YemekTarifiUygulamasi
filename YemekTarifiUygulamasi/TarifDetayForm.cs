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
            this.tarifId = tarifId;
            LoadTarifDetails();
        }

        private void LoadTarifDetails()
        {
            string connectionString = "Server=localhost;Database=yemektarifidb;Uid=ezgi;Pwd=Ke1994+-7645@;"; // Veritabanı bağlantı dizesi
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
                        lblTarifAdi.Text = reader.GetString("TarifAdi");
                        txtTalimatlar.Text = reader.GetString("Talimatlar");
                        pictureBoxTarif.ImageLocation = reader.GetString("GorselYolu");
                    }
                }
            }
        }
    }
}

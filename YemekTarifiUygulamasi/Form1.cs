using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;  // MySQL için ADO.NET kütüphanesi

namespace YemekTarifiUygulamasi
{
    public partial class Form1 : Form
    {
        private FlowLayoutPanel flowLayoutPanelTarifler; // Tariflerin listelendiði dinamik panel

        public Form1()
        {
            InitializeComponent(); // Formu ve kontrolleri baþlat
            LoadTarifler(); // Form yüklendiðinde tarifleri yükle
                            // btnTarifEkle.Click += new EventHandler(btnTarifEkle_Click); // Olay iþleyicilerini ekle
                            //btnMalzemeEkle.Click += new EventHandler(malzeme_Click_1); // Olay iþleyicilerini ekle
        }

        private void LoadTarifler()
        {
            string connectionString = "Server=localhost;Database=yemektarifidb;Uid=ezgi;Pwd=Ke1994+-7645@;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT TarifID, TarifAdi, GorselYolu FROM tarifler";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long tarifId = reader.GetInt64("TarifID");
                            string tarifAdi = reader.GetString("TarifAdi");
                            string gorselYolu = reader.GetString("GorselYolu");

                            // Tarif kartýný oluþtur
                            CreateTarifCard(tarifId, tarifAdi, gorselYolu);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Veritabanýna baðlanýrken bir hata oluþtu: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void CreateTarifCard(long tarifId, string tarifAdi, string gorselYolu)
        {
            // Tarif için yeni bir panel oluþtur
            Panel tarifPanel = new Panel
            {
                Size = new Size(200, 250),
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle,
                Tag = tarifId // Tarif ID'sini panellerin Tag'ine ekle
            };

            // Resmi yükle
            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(200, 150),
                ImageLocation = gorselYolu, // Resim yolunu kullan
                SizeMode = PictureBoxSizeMode.StretchImage // Resmi panel boyutuna uydur
            };

            // Tarif adý etiketi
            Label label = new Label
            {
                Text = tarifAdi,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Bottom
            };

            // Etiket ve resmi panele ekle
            tarifPanel.Controls.Add(pictureBox);
            tarifPanel.Controls.Add(label);

            // Panel týklandýðýnda yapýlacak iþlemleri tanýmla
            tarifPanel.Click += (s, e) =>
            {
                ShowTarifDetails(tarifId);
            };

            // Paneli FlowLayoutPanel'e ekle
            flowLayoutPanelTarifler.Controls.Add(tarifPanel);
        }

        private void ShowTarifDetails(long tarifId)
        {
            // Tarif detaylarýný gösteren bir form aç
            TarifDetayForm detayForm = new TarifDetayForm(tarifId);
            detayForm.ShowDialog(); // Detay formunu modal olarak aç
        }

        


        private void btnMalzemeEkle_Click(object sender, EventArgs e)
        {
            MalzemeEkleForm malzemeEkleForm = new MalzemeEkleForm();
            malzemeEkleForm.ShowDialog(); // Formu modal olarak aç
        }

        private void btnTarifEkle_Click_1(object sender, EventArgs e)
        {
            TarifEkleForm tarifEkleForm = new TarifEkleForm();
            tarifEkleForm.ShowDialog(); // Formu modal olarak aç
        }
    }
}

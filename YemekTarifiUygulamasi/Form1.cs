using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;  // MySQL i�in ADO.NET k�t�phanesi

namespace YemekTarifiUygulamasi
{
    public partial class Form1 : Form
    {
        private FlowLayoutPanel flowLayoutPanelTarifler; // Tariflerin listelendi�i dinamik panel

        public Form1()
        {
            InitializeComponent(); // Formu ve kontrolleri ba�lat
            LoadTarifler(); // Form y�klendi�inde tarifleri y�kle
                            // btnTarifEkle.Click += new EventHandler(btnTarifEkle_Click); // Olay i�leyicilerini ekle
                            //btnMalzemeEkle.Click += new EventHandler(malzeme_Click_1); // Olay i�leyicilerini ekle
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

                            // Tarif kart�n� olu�tur
                            CreateTarifCard(tarifId, tarifAdi, gorselYolu);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Veritaban�na ba�lan�rken bir hata olu�tu: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void CreateTarifCard(long tarifId, string tarifAdi, string gorselYolu)
        {
            // Tarif i�in yeni bir panel olu�tur
            Panel tarifPanel = new Panel
            {
                Size = new Size(200, 250),
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle,
                Tag = tarifId // Tarif ID'sini panellerin Tag'ine ekle
            };

            // Resmi y�kle
            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(200, 150),
                ImageLocation = gorselYolu, // Resim yolunu kullan
                SizeMode = PictureBoxSizeMode.StretchImage // Resmi panel boyutuna uydur
            };

            // Tarif ad� etiketi
            Label label = new Label
            {
                Text = tarifAdi,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Bottom
            };

            // Etiket ve resmi panele ekle
            tarifPanel.Controls.Add(pictureBox);
            tarifPanel.Controls.Add(label);

            // Panel t�kland���nda yap�lacak i�lemleri tan�mla
            tarifPanel.Click += (s, e) =>
            {
                ShowTarifDetails(tarifId);
            };

            // Paneli FlowLayoutPanel'e ekle
            flowLayoutPanelTarifler.Controls.Add(tarifPanel);
        }

        private void ShowTarifDetails(long tarifId)
        {
            // Tarif detaylar�n� g�steren bir form a�
            TarifDetayForm detayForm = new TarifDetayForm(tarifId);
            detayForm.ShowDialog(); // Detay formunu modal olarak a�
        }

        


        private void btnMalzemeEkle_Click(object sender, EventArgs e)
        {
            MalzemeEkleForm malzemeEkleForm = new MalzemeEkleForm();
            malzemeEkleForm.ShowDialog(); // Formu modal olarak a�
        }

        private void btnTarifEkle_Click_1(object sender, EventArgs e)
        {
            TarifEkleForm tarifEkleForm = new TarifEkleForm();
            tarifEkleForm.ShowDialog(); // Formu modal olarak a�
        }
    }
}

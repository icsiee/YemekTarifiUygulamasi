using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // MySQL için ADO.NET kütüphanesi

namespace YemekTarifiUygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); // Formu ve kontrolleri baþlat

            // DataGridView'e sütun ekle
            dataGridViewTarifler.Columns.Clear(); // Önceki sütunlarý temizle

            // Gorsel sütunu (Image türü için)
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "Gorsel";
            imageColumn.HeaderText = "Görsel";
            dataGridViewTarifler.Columns.Add(imageColumn);

            // TarifID sütununu ekle
            DataGridViewTextBoxColumn tarifIdColumn = new DataGridViewTextBoxColumn();
            tarifIdColumn.Name = "TarifID"; // Bu ismi kullanmalýsýnýz
            tarifIdColumn.HeaderText = "Tarif ID";
            tarifIdColumn.Visible = false; // Görünmez yapabilirsiniz
            dataGridViewTarifler.Columns.Add(tarifIdColumn);

            // Diðer sütunlarý ekle
            dataGridViewTarifler.Columns.Add("TarifAdi", "Tarif Adý");
            dataGridViewTarifler.Columns.Add("HazirlamaSuresi", "Hazýrlama Süresi (dk)");
            dataGridViewTarifler.Columns.Add("ToplamMaliyet", "Toplam Maliyet");

            // Diðer ayarlar (isteðe baðlý)
            dataGridViewTarifler.AllowUserToAddRows = false; // Kullanýcýnýn yeni satýr eklemesine izin verme

            // Form yüklendiðinde tarifleri yükle
            LoadTarifler();
        }

        private void LoadTarifler()
        {
            string connectionString = "Server=localhost;Database=yemektarifidb;Uid=root;Pwd=1234;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                        SELECT 
                            t.TarifID, 
                            t.TarifAdi, 
                            t.HazirlamaSuresi, 
                            SUM(m.BirimFiyat * tm.Malzememiktar) AS ToplamMaliyet, 
                            t.GorselYolu 
                        FROM 
                            tarifler t
                        LEFT JOIN 
                            tarifmalzemeiliskisi tm ON t.TarifID = tm.TarifID
                        LEFT JOIN 
                            malzemeler m ON tm.MalzemeID = m.MalzemeID
                        GROUP BY 
                            t.TarifID, t.TarifAdi, t.HazirlamaSuresi, t.GorselYolu";

                    MySqlCommand command = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long tarifId = reader.GetInt64("TarifID");
                            string tarifAdi = reader.GetString("TarifAdi");
                            int hazirlamaSuresi = reader.GetInt32("HazirlamaSuresi");
                            decimal maliyet = reader.IsDBNull("ToplamMaliyet") ? 0 : reader.GetDecimal("ToplamMaliyet");
                            string gorselYolu = reader.GetString("GorselYolu");

                            // Resmi yükle, eðer yol geçersizse null olacak
                            Image tarifImage = null;
                            if (!string.IsNullOrEmpty(gorselYolu) && System.IO.File.Exists(gorselYolu))
                            {
                                try
                                {
                                    tarifImage = Image.FromFile(gorselYolu);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Resim yüklenemedi: " + ex.Message);
                                }
                            }

                            // Verileri DataGridView'e ekle
                            dataGridViewTarifler.Rows.Add(tarifImage, tarifId, tarifAdi, hazirlamaSuresi, maliyet);
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

        // DataGridView satýrýna týklayýnca detaylarý göster
        private void dataGridViewTarifler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Geçerli bir satýr seçildi mi kontrol et
            {
                // Seçilen satýrdaki Tarif ID'sini al
                long tarifId = Convert.ToInt64(dataGridViewTarifler.Rows[e.RowIndex].Cells["TarifID"].Value);
                ShowTarifDetails(tarifId); // Tarif detaylarýný göster
            }
        }

        private void ShowTarifDetails(long tarifId)
        {
            TarifDetayForm detayForm = new TarifDetayForm(tarifId);
            detayForm.ShowDialog(); // Modal olarak detay formunu aç
        }

        private void btnMalzemeEkle_Click_1(object sender, EventArgs e)
        {
            MalzemeEkleForm malzemeEkleForm = new MalzemeEkleForm();
            malzemeEkleForm.ShowDialog(); // Formu modal olarak aç
        }

        private void btnTarifEkle_Click(object sender, EventArgs e)
        {
            TarifEkleForm tarifEkleForm = new TarifEkleForm();
            tarifEkleForm.ShowDialog(); // Formu modal olarak aç
        }
    }
}

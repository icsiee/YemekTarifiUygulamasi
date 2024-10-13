using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace YemekTarifiUygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // DataGridView'e sütun ekle
            dataGridViewTarifler.Columns.Clear();

            // Görsel sütunu
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "Gorsel";
            imageColumn.HeaderText = "Görsel";
            dataGridViewTarifler.Columns.Add(imageColumn);


            // TarifID sütununu ekle
            DataGridViewTextBoxColumn tarifIdColumn = new DataGridViewTextBoxColumn();
            tarifIdColumn.Name = "TarifID";
            tarifIdColumn.HeaderText = "Tarif ID";
            tarifIdColumn.Visible = false;
            dataGridViewTarifler.Columns.Add(tarifIdColumn);

            // Diðer sütunlarý ekle
            dataGridViewTarifler.Columns.Add("TarifAdi", "Tarif Adý");
            dataGridViewTarifler.Columns.Add("HazirlamaSuresi", "Hazýrlama Süresi (dk)");
            dataGridViewTarifler.Columns.Add("ToplamMaliyet", "Toplam Maliyet");

            // Diðer ayarlar
            dataGridViewTarifler.AllowUserToAddRows = false;

            // Form yüklendiðinde tarifleri yükle
            LoadTarifler();

            // Baþlangýçta hiçbir satýr seçili olmamasý için ClearSelection() kullan
            dataGridViewTarifler.ClearSelection();
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
                        t.GorselYolu,
                        (SELECT SUM(m2.BirimFiyat * (tm2.Malzememiktar - m2.ToplamMiktar))
                         FROM malzemeler m2
                         JOIN tarifmalzemeiliskisi tm2 ON m2.MalzemeID = tm2.MalzemeID
                         WHERE tm2.TarifID = t.TarifID AND m2.ToplamMiktar < tm2.Malzememiktar) AS EksikMaliyet
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
                        dataGridViewTarifler.Rows.Clear();

                        while (reader.Read())
                        {
                            long tarifId = reader.GetInt64("TarifID");
                            string tarifAdi = reader.GetString("TarifAdi");
                            int hazirlamaSuresi = reader.GetInt32("HazirlamaSuresi");
                            decimal maliyet = reader.IsDBNull("ToplamMaliyet") ? 0 : reader.GetDecimal("ToplamMaliyet");
                            decimal? eksikMaliyet = reader.IsDBNull("EksikMaliyet") ? null : reader.GetDecimal("EksikMaliyet");
                            string gorselYolu = reader.GetString("GorselYolu");

                            // Resmi yükle
                            Image tarifImage = null;
                            if (!string.IsNullOrEmpty(gorselYolu) && System.IO.File.Exists(gorselYolu))
                            {
                                tarifImage = Image.FromFile(gorselYolu);
                            }

                            // Verileri DataGridView'e ekle
                            int rowIndex = dataGridViewTarifler.Rows.Add(tarifImage, tarifId, tarifAdi, hazirlamaSuresi, maliyet);
                            var row = dataGridViewTarifler.Rows[rowIndex];

                            // Tarifin durumuna göre renk ayarla
                            if (eksikMaliyet.HasValue)
                            {
                                row.DefaultCellStyle.BackColor = Color.Red; // Eksik malzeme var
                                row.Cells["HazirlamaSuresi"].Value += $" (Eksik Maliyet: {eksikMaliyet.Value:C})"; // Maliyet bilgisini göster
                            }
                            else
                            {
                                row.DefaultCellStyle.BackColor = Color.Green; // Tüm malzemeler yeterli
                            }
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

        private void btnAra_Click(object sender, EventArgs e)
        {
            string aramaKriteri = txtAra.Text.Trim();
            string filtreKriteri = cmbFiltrele.SelectedItem?.ToString();

            LoadTarifler(aramaKriteri, filtreKriteri); // Tarife yükleme fonksiyonunu çaðýr
        }

        private void LoadTarifler(string aramaKriteri, string filtreKriteri)
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
                    WHERE 
                        t.TarifAdi LIKE @aramaKriteri";

                    if (filtreKriteri != null && filtreKriteri != "Tüm Tarifler")
                    {
                        query += " AND t.Kategori = @filtreKriteri"; // Örnek: Kategori filtresi
                    }

                    query += " GROUP BY t.TarifID, t.TarifAdi, t.HazirlamaSuresi, t.GorselYolu";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@aramaKriteri", "%" + aramaKriteri + "%");

                    if (filtreKriteri != null && filtreKriteri != "Tüm Tarifler")
                    {
                        command.Parameters.AddWithValue("@filtreKriteri", filtreKriteri);
                    }

                    dataGridViewTarifler.Rows.Clear(); // Önceki sonuçlarý temizle

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long tarifId = reader.GetInt64("TarifID");
                            string tarifAdi = reader.GetString("TarifAdi");
                            int hazirlamaSuresi = reader.GetInt32("HazirlamaSuresi");
                            decimal maliyet = reader.IsDBNull("ToplamMaliyet") ? 0 : reader.GetDecimal("ToplamMaliyet");
                            string gorselYolu = reader.GetString("GorselYolu");

                            // Resmi yükle
                            Image tarifImage = null;
                            if (!string.IsNullOrEmpty(gorselYolu) && System.IO.File.Exists(gorselYolu))
                            {
                                tarifImage = Image.FromFile(gorselYolu);
                            }

                            // Verileri DataGridView'e ekle
                            int rowIndex = dataGridViewTarifler.Rows.Add(tarifImage, tarifId, tarifAdi, hazirlamaSuresi, maliyet);
                            var row = dataGridViewTarifler.Rows[rowIndex];
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

        private void dataGridViewTarifler_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Geçerli bir satýr seçildi mi kontrol et
            {
                // Seçilen satýrdaki Tarif ID'sini al
                long tarifId = Convert.ToInt64(dataGridViewTarifler.Rows[e.RowIndex].Cells["TarifID"].Value);
                ShowTarifDetails(tarifId); // Tarif detaylarýný göster
            }
        }
    }
}

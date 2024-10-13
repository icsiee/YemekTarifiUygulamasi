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

            // DataGridView'e s�tun ekle
            dataGridViewTarifler.Columns.Clear();

            // G�rsel s�tunu
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "Gorsel";
            imageColumn.HeaderText = "G�rsel";
            dataGridViewTarifler.Columns.Add(imageColumn);


            // TarifID s�tununu ekle
            DataGridViewTextBoxColumn tarifIdColumn = new DataGridViewTextBoxColumn();
            tarifIdColumn.Name = "TarifID";
            tarifIdColumn.HeaderText = "Tarif ID";
            tarifIdColumn.Visible = false;
            dataGridViewTarifler.Columns.Add(tarifIdColumn);

            // Di�er s�tunlar� ekle
            dataGridViewTarifler.Columns.Add("TarifAdi", "Tarif Ad�");
            dataGridViewTarifler.Columns.Add("HazirlamaSuresi", "Haz�rlama S�resi (dk)");
            dataGridViewTarifler.Columns.Add("ToplamMaliyet", "Toplam Maliyet");

            // Di�er ayarlar
            dataGridViewTarifler.AllowUserToAddRows = false;

            // Form y�klendi�inde tarifleri y�kle
            LoadTarifler();

            // Ba�lang��ta hi�bir sat�r se�ili olmamas� i�in ClearSelection() kullan
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

                            // Resmi y�kle
                            Image tarifImage = null;
                            if (!string.IsNullOrEmpty(gorselYolu) && System.IO.File.Exists(gorselYolu))
                            {
                                tarifImage = Image.FromFile(gorselYolu);
                            }

                            // Verileri DataGridView'e ekle
                            int rowIndex = dataGridViewTarifler.Rows.Add(tarifImage, tarifId, tarifAdi, hazirlamaSuresi, maliyet);
                            var row = dataGridViewTarifler.Rows[rowIndex];

                            // Tarifin durumuna g�re renk ayarla
                            if (eksikMaliyet.HasValue)
                            {
                                row.DefaultCellStyle.BackColor = Color.Red; // Eksik malzeme var
                                row.Cells["HazirlamaSuresi"].Value += $" (Eksik Maliyet: {eksikMaliyet.Value:C})"; // Maliyet bilgisini g�ster
                            }
                            else
                            {
                                row.DefaultCellStyle.BackColor = Color.Green; // T�m malzemeler yeterli
                            }
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

        private void ShowTarifDetails(long tarifId)
        {
            TarifDetayForm detayForm = new TarifDetayForm(tarifId);
            detayForm.ShowDialog(); // Modal olarak detay formunu a�
        }

        private void btnMalzemeEkle_Click_1(object sender, EventArgs e)
        {
            MalzemeEkleForm malzemeEkleForm = new MalzemeEkleForm();
            malzemeEkleForm.ShowDialog(); // Formu modal olarak a�
        }

        private void btnTarifEkle_Click(object sender, EventArgs e)
        {
            TarifEkleForm tarifEkleForm = new TarifEkleForm();
            tarifEkleForm.ShowDialog(); // Formu modal olarak a�
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            string aramaKriteri = txtAra.Text.Trim();
            string filtreKriteri = cmbFiltrele.SelectedItem?.ToString();

            LoadTarifler(aramaKriteri, filtreKriteri); // Tarife y�kleme fonksiyonunu �a��r
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

                    if (filtreKriteri != null && filtreKriteri != "T�m Tarifler")
                    {
                        query += " AND t.Kategori = @filtreKriteri"; // �rnek: Kategori filtresi
                    }

                    query += " GROUP BY t.TarifID, t.TarifAdi, t.HazirlamaSuresi, t.GorselYolu";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@aramaKriteri", "%" + aramaKriteri + "%");

                    if (filtreKriteri != null && filtreKriteri != "T�m Tarifler")
                    {
                        command.Parameters.AddWithValue("@filtreKriteri", filtreKriteri);
                    }

                    dataGridViewTarifler.Rows.Clear(); // �nceki sonu�lar� temizle

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long tarifId = reader.GetInt64("TarifID");
                            string tarifAdi = reader.GetString("TarifAdi");
                            int hazirlamaSuresi = reader.GetInt32("HazirlamaSuresi");
                            decimal maliyet = reader.IsDBNull("ToplamMaliyet") ? 0 : reader.GetDecimal("ToplamMaliyet");
                            string gorselYolu = reader.GetString("GorselYolu");

                            // Resmi y�kle
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
                    MessageBox.Show("Veritaban�na ba�lan�rken bir hata olu�tu: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void dataGridViewTarifler_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ge�erli bir sat�r se�ildi mi kontrol et
            {
                // Se�ilen sat�rdaki Tarif ID'sini al
                long tarifId = Convert.ToInt64(dataGridViewTarifler.Rows[e.RowIndex].Cells["TarifID"].Value);
                ShowTarifDetails(tarifId); // Tarif detaylar�n� g�ster
            }
        }
    }
}

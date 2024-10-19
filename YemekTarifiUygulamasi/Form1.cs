using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace YemekTarifiUygulamasi
{
    public partial class Form1 : Form
    {
        string connectionString = "Server=localhost;Database=yemektarifidb;Uid=root;Pwd=1234";
        private MalzemeEkleForm malzemeEkleForm;

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
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Resmi orantýlý þekilde küçültüp büyütür


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
            // Eksik Maliyet sütununu ekleyelim
            DataGridViewTextBoxColumn eksikMaliyetColumn = new DataGridViewTextBoxColumn();
            eksikMaliyetColumn.Name = "EksikMaliyet";
            eksikMaliyetColumn.HeaderText = "Eksik Maliyet";
            eksikMaliyetColumn.ReadOnly = true;
            dataGridViewTarifler.Columns.Add(eksikMaliyetColumn);
            // Diðer ayarlar
            dataGridViewTarifler.AllowUserToAddRows = false;

            // Baþlangýçta hiçbir satýr seçili olmamasý için ClearSelection() kullan
            dataGridViewTarifler.ClearSelection();

            // Seçili satýr rengini kaldýr
            dataGridViewTarifler.SelectionMode = DataGridViewSelectionMode.CellSelect;

            // Mouse olaylarýný yakalamak için event handler ekleyelim
            dataGridViewTarifler.CellMouseEnter += DataGridViewTarifler_CellMouseEnter;
            dataGridViewTarifler.CellMouseLeave += DataGridViewTarifler_CellMouseLeave;

            cmbFiltrele.SelectedIndexChanged += cmbFiltrele_SelectedIndexChanged;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);

            malzemeEkleForm = new MalzemeEkleForm(this);


            // Form yüklendiðinde tarifleri yükle
            LoadTarifler();
        }
        public void LoadTarifler()
        {
            string connectionString = "Server=localhost;Database=yemektarifidb;Uid=root;Pwd=1234";
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
                    t.GorselAdi,
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
                    t.TarifID, t.TarifAdi, t.HazirlamaSuresi, t.GorselAdi";

                    MySqlCommand command = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        dataGridViewTarifler.Rows.Clear();

                        while (reader.Read())
                        {
                            try
                            {
                                long tarifId = reader.GetInt64("TarifID");
                                string tarifAdi = reader.GetString("TarifAdi");
                                int hazirlamaSuresi = reader.GetInt32("HazirlamaSuresi");
                                decimal maliyet = reader.IsDBNull(reader.GetOrdinal("ToplamMaliyet")) ? 0 : reader.GetDecimal(reader.GetOrdinal("ToplamMaliyet"));
                                decimal? eksikMaliyet = reader.IsDBNull("EksikMaliyet") ? null : reader.GetDecimal("EksikMaliyet");
                                string gorselAdi = reader.GetString("GorselAdi");

                                // Resmi yükle
                                Image tarifImage = null;
                                string imagePath = Path.Combine(Application.StartupPath, "Images", gorselAdi);
                                if (!string.IsNullOrEmpty(gorselAdi) && File.Exists(imagePath))
                                {
                                    tarifImage = Image.FromFile(imagePath);
                                }

                                // Verileri DataGridView'e ekle
                                int rowIndex = dataGridViewTarifler.Rows.Add(tarifImage, tarifId, tarifAdi, hazirlamaSuresi, maliyet);

                                // EksikMaliyet sütununa veri ekle
                                var row = dataGridViewTarifler.Rows[rowIndex];
                                row.Cells["EksikMaliyet"].Value = eksikMaliyet.HasValue ? eksikMaliyet.Value.ToString("C") : "Eksik Maliyet Yok";

                                // Tarifin durumuna göre renk ayarla
                                if (eksikMaliyet.HasValue)
                                {
                                    row.DefaultCellStyle.BackColor = Color.Red; // Eksik malzeme var
                                }
                                else
                                {
                                    row.DefaultCellStyle.BackColor = Color.Green; // Tüm malzemeler yeterli
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Satýr iþleme hatasý: " + ex.Message);
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
                    MessageBox.Show("Beklenmeyen hata: " + ex.Message);
                }
            }
        }


        private void ShowTarifDetails(long tarifId)
        {
            TarifDetayForm detayForm = new TarifDetayForm(tarifId, this);
            detayForm.ShowDialog(); // Modal olarak detay formunu aç
        }

        private void btnMalzemeEkle_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            MalzemeEkleForm malzemeEkleForm = new MalzemeEkleForm(this);
            malzemeEkleForm.ShowDialog(); // Formu modal olarak aç

        }

        private void cmbFiltrele_SelectedIndexChanged(object sender, EventArgs e)
        {
            string aramaKriteri = txtAra.Text.Trim();
            string filtreKriteri = cmbFiltrele.SelectedItem?.ToString();

            LoadTarifler(aramaKriteri, filtreKriteri); // Tarife yükleme fonksiyonunu çaðýr
        }


        private void btnTarifEkle_Click(object sender, EventArgs e)
        {
            this.Hide(); // Formu gizler

            // TarifEkleForm'u Form1 referansý ile aç
            TarifEkleForm tarifEkleForm = new TarifEkleForm(this, malzemeEkleForm); // Form1 referansýný geçiyoruz
            tarifEkleForm.ShowDialog(); // Modal olarak açýyoruz
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
                t.GorselAdi,
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
            WHERE 
                t.TarifAdi LIKE @aramaKriteri";

                    if (filtreKriteri != null && filtreKriteri != "Tümü")
                    {
                        query += " AND t.Kategori = @filtreKriteri"; // Kategoriye göre filtreleme
                    }

                    query += " GROUP BY t.TarifID, t.TarifAdi, t.HazirlamaSuresi, t.GorselAdi";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@aramaKriteri", "%" + aramaKriteri + "%");

                    if (filtreKriteri != null && filtreKriteri != "Tümü")
                    {
                        command.Parameters.AddWithValue("@filtreKriteri", filtreKriteri);
                    }

                    // DataGridView'i temizle
                    dataGridViewTarifler.Rows.Clear();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long tarifId = reader.GetInt64("TarifID");
                            string tarifAdi = reader.GetString("TarifAdi");
                            int hazirlamaSuresi = reader.GetInt32("HazirlamaSuresi");
                            decimal maliyet = reader.IsDBNull(reader.GetOrdinal("ToplamMaliyet")) ? 0 : reader.GetDecimal(reader.GetOrdinal("ToplamMaliyet"));
                            decimal? eksikMaliyet = reader.IsDBNull("EksikMaliyet") ? null : reader.GetDecimal("EksikMaliyet");
                            string gorselAdi = reader.GetString("GorselAdi");

                            // Resmi yükle
                            Image tarifImage = null;
                            string imagePath = Path.Combine(Application.StartupPath, "Images", gorselAdi);
                            if (!string.IsNullOrEmpty(gorselAdi) && File.Exists(imagePath))
                            {
                                tarifImage = Image.FromFile(imagePath);
                            }


                            // Verileri DataGridView'e ekle
                            int rowIndex = dataGridViewTarifler.Rows.Add(tarifImage, tarifId, tarifAdi, hazirlamaSuresi, maliyet);

                            // EksikMaliyet sütununa veri ekle
                            var row = dataGridViewTarifler.Rows[rowIndex];
                            row.Cells["EksikMaliyet"].Value = eksikMaliyet.HasValue ? eksikMaliyet.Value.ToString("C") : "Maliyet Yok";

                            // Tarifin durumuna göre renk ayarla
                            if (eksikMaliyet.HasValue)
                            {
                                row.DefaultCellStyle.BackColor = Color.Red; // Eksik malzeme var
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




        // Fare ile üzerine gelindiðinde yazýyý beyaza döndür
        private void DataGridViewTarifler_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Geçerli bir satýr varsa
            {
                var row = dataGridViewTarifler.Rows[e.RowIndex];
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.ForeColor = Color.White; // Yazýyý beyaza döndür
                }
            }
        }

        // Fare ile satýrdan ayrýldýðýnda yazýyý tekrar siyaha döndür
        private void DataGridViewTarifler_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Geçerli bir satýr varsa
            {
                var row = dataGridViewTarifler.Rows[e.RowIndex];
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.ForeColor = Color.Black; // Yazýyý tekrar siyaha döndür
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Enter tuþuna basýldýðýnda
            {
                btnAra.PerformClick(); // Ara butonuna týkla (fonksiyonu çaðýr)
                e.Handled = true; // Tuþ olayýný iþlediðimizi belirtiyoruz
            }
        }

        private void dataGridViewTarifler_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Geçerli bir satýr seçildi mi kontrol et
            {
                // Seçilen satýrdaki Tarif ID'sini al
                long tarifId = Convert.ToInt64(dataGridViewTarifler.Rows[e.RowIndex].Cells["TarifID"].Value);
                ShowTarifDetails(tarifId); // Tarif detaylarýný göster
            }
        }


        private void pictureBoxYenile_Click(object sender, EventArgs e)
        {
            LoadTarifler();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            LoadTarifler();
        }


       
        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }
    }
}
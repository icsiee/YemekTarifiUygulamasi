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
        private TarifDetayForm tarifDetayForm;

        public Form1()
        {
            InitializeComponent();

            // DataGridView'e sütun ekle
            dataGridViewTarifler.Columns.Clear();
            dataGridViewTarifler.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Numaralandýrma sütununu ekle
            dataGridViewTarifler.Columns.Add("No", "No");
            dataGridViewTarifler.Columns.Add("Yuzde", "Yuzde");

            // Görsel sütunu
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "Gorsel";
            imageColumn.HeaderText = "Görsel";
            dataGridViewTarifler.Columns.Add(imageColumn);
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Resmi orantýlý þekilde küçültüp büyüt



            // TarifID sütununu ekle
            DataGridViewTextBoxColumn tarifIdColumn = new DataGridViewTextBoxColumn();
            tarifIdColumn.Name = "TarifID";
            tarifIdColumn.HeaderText = "Tarif ID";
            tarifIdColumn.Visible = false;
            dataGridViewTarifler.Columns.Add(tarifIdColumn);

            dataGridViewTarifler.SelectionMode = DataGridViewSelectionMode.CellSelect; // Sadece hücreler seçilebilir
            dataGridViewTarifler.MultiSelect = false; // Çoklu hücre seçimi kapalý
            dataGridViewTarifler.ClearSelection(); // Varsayýlan olarak seçili hücreleri kaldýr

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

            // "Sil" buton sütunu
            DataGridViewButtonColumn silButtonColumn = new DataGridViewButtonColumn();
            silButtonColumn.Name = "Sil";
            silButtonColumn.HeaderText = "Sil";
            silButtonColumn.Text = "Sil";
            silButtonColumn.UseColumnTextForButtonValue = true;
            dataGridViewTarifler.Columns.Add(silButtonColumn);

            // "Detay" buton sütunu
            DataGridViewButtonColumn detayButtonColumn = new DataGridViewButtonColumn();
            detayButtonColumn.Name = "Detay";
            detayButtonColumn.HeaderText = "Detay Göster";
            detayButtonColumn.Text = "Detay";
            detayButtonColumn.UseColumnTextForButtonValue = true; // Buton üzerinde yazý gözüksün
            dataGridViewTarifler.Columns.Add(detayButtonColumn);

            minMalzemeSayisi.Minimum = 1;  // Minimum malzeme sayýsý
            maxMalzemeSayisi.Minimum = 1;  // Minimum malzeme sayýsý


            // Event Handlers
            cmbFiltrele.SelectedIndexChanged += cmbFiltrele_SelectedIndexChanged;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);

            malzemeEkleForm = new MalzemeEkleForm(this);

            // Form yüklendiðinde tarifleri yükle
            LoadTarifler();

            // DataGridView için CellFormatting olayý
            dataGridViewTarifler.CellFormatting += DataGridViewTarifler_CellFormatting;
        }

        private void DataGridViewTarifler_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // "Sil" butonunun rengini kýrmýzý yapma
            if (dataGridViewTarifler.Columns[e.ColumnIndex].Name == "Sil" && e.RowIndex >= 0)
            {
                e.CellStyle.BackColor = Color.Red; // Kýrmýzý arka plan
                e.CellStyle.ForeColor = Color.White; // Beyaz yazý rengi
            }
        }




        public void LoadTarifler()
        {
            List<string> selectedMalzemeler = new List<string>();

            foreach (var item in checkedListBoxMalzemeler.CheckedItems)
            {
                selectedMalzemeler.Add(item.ToString());
            }

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
                    dataGridViewTarifler.Rows.Clear();

                    List<TarifInfo> tarifList = new List<TarifInfo>();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
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

                                double matchPercentage = CalculateMatchPercentage(tarifId, selectedMalzemeler);

                                // Tarif bilgilerini listeye ekle
                                tarifList.Add(new TarifInfo
                                {
                                    TarifID = tarifId,
                                    TarifAdi = tarifAdi,
                                    HazirlamaSuresi = hazirlamaSuresi,
                                    ToplamMaliyet = maliyet,
                                    EksikMaliyet = eksikMaliyet,
                                    GorselAdi = gorselAdi,
                                    MatchPercentage = matchPercentage
                                });
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Satýr iþleme hatasý: " + ex.Message);
                            }
                        }
                    }

                    // Yüzde deðerine göre sýralama
                    var sortedTarifList = tarifList.OrderByDescending(t => t.MatchPercentage).ToList();

                    int rowNumber = 1; // Numaralandýrma için sayaç

                    foreach (var tarif in sortedTarifList)
                    {
                        // Resmi yükle
                        Image tarifImage = null;
                        string imagePath = Path.Combine(@"C:\Users\iclal dere\source\YemekTarifiUygulamasi\YemekTarifiUygulamasi\Resources", tarif.GorselAdi);
                        if (!string.IsNullOrEmpty(tarif.GorselAdi) && File.Exists(imagePath))
                        {
                            tarifImage = Image.FromFile(imagePath);
                        }

                        // Yüzde deðerini formatla (virgülden sonra 3 basamak)
                        string formattedPercentage = tarif.MatchPercentage.ToString("0.000");

                        // Verileri DataGridView'e ekle
                        int rowIndex = dataGridViewTarifler.Rows.Add(rowNumber, formattedPercentage, tarifImage, tarif.TarifID, tarif.TarifAdi, tarif.HazirlamaSuresi, tarif.ToplamMaliyet);

                        // EksikMaliyet sütununa veri ekle
                        var row = dataGridViewTarifler.Rows[rowIndex];
                        row.Cells["EksikMaliyet"].Value = tarif.EksikMaliyet.HasValue ? tarif.EksikMaliyet.Value.ToString("C") : "Maliyet Yok";

                        // Numaralandýrma sütununa deðer ekle
                        row.Cells["No"].Value = rowNumber++; // Sýra numarasýný ekle

                        // Tarifin durumuna göre renk ayarla
                        if (tarif.EksikMaliyet.HasValue)
                        {
                            row.DefaultCellStyle.BackColor = Color.Red; // Eksik malzeme var
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = Color.Green; // Tüm malzemeler yeterli
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

        // Tarif bilgilerini tutan sýnýf
        private class TarifInfo
        {
            public long TarifID { get; set; }
            public string TarifAdi { get; set; }
            public int HazirlamaSuresi { get; set; }
            public decimal ToplamMaliyet { get; set; }
            public decimal? EksikMaliyet { get; set; }
            public string GorselAdi { get; set; }
            public double MatchPercentage { get; set; }
        }


        // DataGridView'in CellContentClick olay?n? yakala
        private void dataGridViewTarifler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // "Detay" butonu týklandýðýnda
            if (e.ColumnIndex == dataGridViewTarifler.Columns["Detay"].Index && e.RowIndex >= 0)
            {
                long tarifId = Convert.ToInt64(dataGridViewTarifler.Rows[e.RowIndex].Cells["TarifID"].Value);
                tarifDetayForm = new TarifDetayForm(tarifId, this);
                tarifDetayForm.ShowDialog();
            }

            // "Sil" butonu týklandýðýnda
            if (e.ColumnIndex == dataGridViewTarifler.Columns["Sil"].Index && e.RowIndex >= 0)
            {
                long tarifId = Convert.ToInt64(dataGridViewTarifler.Rows[e.RowIndex].Cells["TarifID"].Value);

                // Veritabanýndan silme iþlemi
                DialogResult dialogResult = MessageBox.Show("Bu tarifi silmek istediðinize emin misiniz?", "Tarif Sil", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();

                            // Ýlk olarak tarifin iliþkilerini sil
                            string deleteRelationQuery = "DELETE FROM tarifmalzemeiliskisi WHERE TarifID = @TarifID";
                            MySqlCommand deleteRelationCommand = new MySqlCommand(deleteRelationQuery, connection);
                            deleteRelationCommand.Parameters.AddWithValue("@TarifID", tarifId);
                            deleteRelationCommand.ExecuteNonQuery();

                            // Ardýndan tarifin kendisini sil
                            string deleteQuery = "DELETE FROM tarifler WHERE TarifID = @TarifID";
                            MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection);
                            deleteCommand.Parameters.AddWithValue("@TarifID", tarifId);
                            deleteCommand.ExecuteNonQuery();

                            MessageBox.Show("Tarif ve iliþkileri baþarýyla silindi.");
                            LoadTarifler(); // Silmeden sonra tarifleri yeniden yükle
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Tarif silinirken bir hata oluþtu: " + ex.Message);
                        }
                    }
                }
            }

        }


        private void btnMalzemeEkle_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            MalzemeEkleForm malzemeEkleForm = new MalzemeEkleForm(this);
            malzemeEkleForm.ShowDialog(); // Formu modal olarak a?

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

            // TarifEkleForm'u Form1 referans? ile a?
            TarifEkleForm tarifEkleForm = new TarifEkleForm(this, malzemeEkleForm); // Form1 referans?n? ge?iyoruz
            tarifEkleForm.ShowDialog(); // Modal olarak a??yoruz
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            string aramaKriteri = txtAra.Text.Trim();
            string filtreKriteri = cmbFiltrele.SelectedItem?.ToString();

            LoadTarifler(aramaKriteri, filtreKriteri); // Tarife y?kleme fonksiyonunu ?a??r
        }


        private void LoadTarifler(string aramaKriteri, string filtreKriteri)
        {
            List<string> selectedMalzemeler = new List<string>();

            foreach (var item in checkedListBoxMalzemeler.CheckedItems)
            {
                selectedMalzemeler.Add(item.ToString());
            }

            string connectionString = "Server=localhost;Database=yemektarifidb;Uid=root;Pwd=1234;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
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

                // Filtre kriteri "Tümü" deðilse kategori filtresi ekle
                if (!string.IsNullOrEmpty(filtreKriteri) && filtreKriteri != "Tümü")
                {
                    query += " AND t.Kategori = @filtreKriteri";
                }

                query += " GROUP BY t.TarifID, t.TarifAdi, t.HazirlamaSuresi, t.GorselAdi";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@aramaKriteri", "%" + aramaKriteri + "%");

                if (!string.IsNullOrEmpty(filtreKriteri) && filtreKriteri != "Tümü")
                {
                    command.Parameters.AddWithValue("@filtreKriteri", filtreKriteri);
                }

                // DataGridView'i temizle
                dataGridViewTarifler.Rows.Clear();
                List<TarifInfo> tarifList = new List<TarifInfo>();

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

                        // Tarif bilgilerini listeye ekle
                        tarifList.Add(new TarifInfo
                        {
                            TarifID = tarifId,
                            TarifAdi = tarifAdi,
                            HazirlamaSuresi = hazirlamaSuresi,
                            ToplamMaliyet = maliyet,
                            EksikMaliyet = eksikMaliyet,
                            GorselAdi = gorselAdi,
                            MatchPercentage = CalculateMatchPercentage(tarifId, selectedMalzemeler)
                        });
                    }
                }

                // Yüzde deðerine göre sýralama
                var sortedTarifList = tarifList.OrderByDescending(t => t.MatchPercentage).ToList();

                int rowNumber = 1; // Numaralandýrma için sayaç

                foreach (var tarif in sortedTarifList)
                {
                    // Resmi yükle
                    Image tarifImage = null;
                    string imagePath = Path.Combine(@"C:\Users\iclal dere\source\YemekTarifiUygulamasi\YemekTarifiUygulamasi\Resources", tarif.GorselAdi);
                    if (!string.IsNullOrEmpty(tarif.GorselAdi) && File.Exists(imagePath))
                    {
                        tarifImage = Image.FromFile(imagePath);
                    }

                    // Yüzde deðerini formatla (virgülden sonra 3 basamak)
                    string formattedPercentage = tarif.MatchPercentage.ToString("0.000");

                    // Verileri DataGridView'e ekle
                    int rowIndex = dataGridViewTarifler.Rows.Add(rowNumber, formattedPercentage, tarifImage, tarif.TarifID, tarif.TarifAdi, tarif.HazirlamaSuresi, tarif.ToplamMaliyet);

                    // EksikMaliyet sütununa veri ekle
                    var row = dataGridViewTarifler.Rows[rowIndex];
                    row.Cells["EksikMaliyet"].Value = tarif.EksikMaliyet.HasValue ? tarif.EksikMaliyet.Value.ToString("C") : "Maliyet Yok";

                    // Numaralandýrma sütununa deðer ekle
                    row.Cells["No"].Value = rowNumber++; // Sýra numarasýný ekle

                    // Tarifin durumuna göre renk ayarla
                    if (tarif.EksikMaliyet.HasValue)
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





        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Enter tu?una bas?ld???nda
            {
                btnAra.PerformClick(); // Ara butonuna t?kla (fonksiyonu ?a??r)
                e.Handled = true; // Tu? olay?n? i?ledi?imizi belirtiyoruz
            }
        }

        private void pictureBoxYenile_Click(object sender, EventArgs e)
        {
            LoadTarifler();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            LoadTarifler();
            LoadMalzemeler();

        }

        private void LoadMalzemeler()
        {
            string connectionString = "Server=localhost;Database=yemektarifidb;Uid=root;Pwd=1234;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT MalzemeAdi FROM malzemeler", conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    checkedListBoxMalzemeler.Items.Add(reader["MalzemeAdi"].ToString());
                }

                conn.Close();
            }
        }

        private double CalculateMatchPercentage(long tarifID, List<string> selectedMalzemeler)
        {
            // Tarif malzemelerini veritabanýndan çekin
            string connectionString = "Server=localhost;Database=yemektarifidb;Uid=root;Pwd=1234;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT MalzemeID FROM tarifmalzemeiliskisi WHERE TarifID = @TarifID", conn);
                cmd.Parameters.AddWithValue("@TarifID", tarifID);
                MySqlDataReader reader = cmd.ExecuteReader();

                List<int> tarifMalzemeleri = new List<int>();
                while (reader.Read())
                {
                    tarifMalzemeleri.Add(reader.GetInt32(0));
                }

                conn.Close();

                // Eþleþme yüzdesini hesaplayýn
                int matchCount = tarifMalzemeleri.Count(m => selectedMalzemeler.Contains(GetMalzemeAdi(m)));
                double percentage = (double)matchCount / tarifMalzemeleri.Count * 100;
                return percentage;
            }
        }

        private string GetMalzemeAdi(int malzemeID)
        {
            string connectionString = "Server=localhost;Database=yemektarifidb;Uid=root;Pwd=1234;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT MalzemeAdi FROM malzemeler WHERE MalzemeID = @MalzemeID", conn);
                cmd.Parameters.AddWithValue("@MalzemeID", malzemeID);
                return cmd.ExecuteScalar().ToString();
            }
        }


        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }

        private void btnAra1_Click(object sender, EventArgs e)
        {
            LoadTarifler();

        }


        private void LoadTarifler(int minCount = 0, int maxCount = int.MaxValue)
        {
            List<string> selectedMalzemeler = new List<string>();

            foreach (var item in checkedListBoxMalzemeler.CheckedItems)
            {
                selectedMalzemeler.Add(item.ToString());
            }

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
     WHERE tm2.TarifID = t.TarifID AND m2.ToplamMiktar < tm2.Malzememiktar) AS EksikMaliyet,
    COUNT(tm.MalzemeID) AS MalzemeSayisi
FROM 
    tarifler t
LEFT JOIN 
    tarifmalzemeiliskisi tm ON t.TarifID = tm.TarifID
LEFT JOIN 
    malzemeler m ON tm.MalzemeID = m.MalzemeID
GROUP BY 
    t.TarifID, t.TarifAdi, t.HazirlamaSuresi, t.GorselAdi
HAVING 
    COUNT(tm.MalzemeID) BETWEEN @minCount AND @maxCount";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@minCount", minCount);
                    command.Parameters.AddWithValue("@maxCount", maxCount);

                    dataGridViewTarifler.Rows.Clear();
                    List<TarifInfo> tarifList = new List<TarifInfo>();


                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
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

                                double matchPercentage = CalculateMatchPercentage(tarifId, selectedMalzemeler);

                                // Tarif bilgilerini listeye ekle
                                tarifList.Add(new TarifInfo
                                {
                                    TarifID = tarifId,
                                    TarifAdi = tarifAdi,
                                    HazirlamaSuresi = hazirlamaSuresi,
                                    ToplamMaliyet = maliyet,
                                    EksikMaliyet = eksikMaliyet,
                                    GorselAdi = gorselAdi,
                                    MatchPercentage = matchPercentage
                                });
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Sat?r i?leme hatas?: " + ex.Message);
                            }
                        }
                    }

                    // Yüzde de?erine göre s?ralama
                    var sortedTarifList = tarifList.OrderByDescending(t => t.MatchPercentage).ToList();

                    int rowNumber = 1; // Numaraland?rma için sayaç

                    foreach (var tarif in sortedTarifList)
                    {
                        // Resmi yükle
                        Image tarifImage = null;
                        string imagePath = Path.Combine(@"C:\Users\iclal dere\source\YemekTarifiUygulamasi\YemekTarifiUygulamasi\Resources", tarif.GorselAdi);
                        if (!string.IsNullOrEmpty(tarif.GorselAdi) && File.Exists(imagePath))
                        {
                            tarifImage = Image.FromFile(imagePath);
                        }

                        // Yüzde de?erini formatla (virgülden sonra 3 basamak)
                        string formattedPercentage = tarif.MatchPercentage.ToString("0.000");

                        // Verileri DataGridView'e ekle
                        int rowIndex = dataGridViewTarifler.Rows.Add(rowNumber, formattedPercentage, tarifImage, tarif.TarifID, tarif.TarifAdi, tarif.HazirlamaSuresi, tarif.ToplamMaliyet);

                        // EksikMaliyet sütununa veri ekle
                        var row = dataGridViewTarifler.Rows[rowIndex];
                        row.Cells["EksikMaliyet"].Value = tarif.EksikMaliyet.HasValue ? tarif.EksikMaliyet.Value.ToString("C") : "Maliyet Yok";

                        // Numaraland?rma sütununa de?er ekle
                        row.Cells["No"].Value = rowNumber++; // S?ra numaras?n? ekle

                        // Tarifin durumuna göre renk ayarla
                        if (tarif.EksikMaliyet.HasValue)
                        {
                            row.DefaultCellStyle.BackColor = Color.Red; // Eksik malzeme var
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = Color.Green; // Tüm malzemeler yeterli
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Veritaban?na ba?lan?rken bir hata olu?tu: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Beklenmeyen hata: " + ex.Message);
                }
            }
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
{
    int minCount = (int)minMalzemeSayisi.Value; // Minimum malzeme sayýsý
    int maxCount = (int)maxMalzemeSayisi.Value; // Maksimum malzeme sayýsý

    // Giriþ kontrolü: minCount maksimumdan büyükse veya maxCount minimumdan küçükse hata mesajý göster
    if (minCount > maxCount)
    {
        MessageBox.Show("Hata: Minimum malzeme sayýsý, maksimumdan büyük olamaz.", "Hatalý Giriþ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return; // Hata durumunda iþlemi sonlandýr
    }

    // Eðer deðerler uygunsa tarifleri yükle
    LoadTarifler(minCount, maxCount); 
}

    }
}
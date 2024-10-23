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
            // DataGridView'e s?tun ekle
            dataGridViewTarifler.Columns.Clear();

            // G?rsel s?tunu
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "Gorsel";
            imageColumn.HeaderText = "G?rsel";
            dataGridViewTarifler.Columns.Add(imageColumn);
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Resmi orant?l? ?ekilde k???lt?p b?y?t?r


            // TarifID s?tununu ekle
            DataGridViewTextBoxColumn tarifIdColumn = new DataGridViewTextBoxColumn();
            tarifIdColumn.Name = "TarifID";
            tarifIdColumn.HeaderText = "Tarif ID";
            tarifIdColumn.Visible = false;

            dataGridViewTarifler.Columns.Add(tarifIdColumn);

            dataGridViewTarifler.SelectionMode = DataGridViewSelectionMode.CellSelect; // Sadece h?creler se?ilebilir, sat?r se?imi kapal?
            dataGridViewTarifler.MultiSelect = false; // ?oklu h?cre se?imi kapal?
            dataGridViewTarifler.ClearSelection(); // Varsay?lan olarak se?ili h?creleri kald?r

            // Di?er s?tunlar? ekle
            dataGridViewTarifler.Columns.Add("TarifAdi", "Tarif Ad?");
            dataGridViewTarifler.Columns.Add("HazirlamaSuresi", "Haz?rlama S?resi (dk)");
            dataGridViewTarifler.Columns.Add("ToplamMaliyet", "Toplam Maliyet");
            // Eksik Maliyet s?tununu ekleyelim
            DataGridViewTextBoxColumn eksikMaliyetColumn = new DataGridViewTextBoxColumn();
            eksikMaliyetColumn.Name = "EksikMaliyet";
            eksikMaliyetColumn.HeaderText = "Eksik Maliyet";
            eksikMaliyetColumn.ReadOnly = true;
            dataGridViewTarifler.Columns.Add(eksikMaliyetColumn);
            // Di?er ayarlar
            dataGridViewTarifler.AllowUserToAddRows = false;

            // "Sil" buton sütunu
            DataGridViewButtonColumn silButtonColumn = new DataGridViewButtonColumn();
            silButtonColumn.Name = "Sil";
            silButtonColumn.HeaderText = "Sil";
            silButtonColumn.Text = "Sil";
            silButtonColumn.UseColumnTextForButtonValue = true;
            dataGridViewTarifler.Columns.Add(silButtonColumn);

            // DataGridView'e buton s?tunu ekle
            DataGridViewButtonColumn detayButtonColumn = new DataGridViewButtonColumn();
            detayButtonColumn.Name = "Detay";
            detayButtonColumn.HeaderText = "Detay G?ster";
            detayButtonColumn.Text = "Detay";
            detayButtonColumn.UseColumnTextForButtonValue = true; // Buton ?zerinde yaz? g?z?ks?n
            dataGridViewTarifler.Columns.Add(detayButtonColumn);

            cmbFiltrele.SelectedIndexChanged += cmbFiltrele_SelectedIndexChanged;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);

            malzemeEkleForm = new MalzemeEkleForm(this);


            // Form y?klendi?inde tarifleri y?kle
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

                                // Resmi y?kle
                                Image tarifImage = null;
                                string imagePath = Path.Combine(@"C:\Users\iclal dere\source\YemekTarifiUygulamasi\YemekTarifiUygulamasi\Resources", gorselAdi);
                                if (!string.IsNullOrEmpty(gorselAdi) && File.Exists(imagePath))
                                {
                                    tarifImage = Image.FromFile(imagePath);
                                }

                                // Verileri DataGridView'e ekle
                                int rowIndex = dataGridViewTarifler.Rows.Add(tarifImage, tarifId, tarifAdi, hazirlamaSuresi, maliyet);

                                // EksikMaliyet s?tununa veri ekle
                                var row = dataGridViewTarifler.Rows[rowIndex];
                                row.Cells["EksikMaliyet"].Value = eksikMaliyet.HasValue ? eksikMaliyet.Value.ToString("C") : "Eksik Maliyet Yok";

                                // Tarifin durumuna g?re renk ayarla
                                if (eksikMaliyet.HasValue)
                                {
                                    row.DefaultCellStyle.BackColor = Color.Red; // Eksik malzeme var
                                }
                                else
                                {
                                    row.DefaultCellStyle.BackColor = Color.Green; // T?m malzemeler yeterli
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Sat?r i?leme hatas?: " + ex.Message);
                            }
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
                            string deleteQuery = "DELETE FROM tarifler WHERE TarifID = @TarifID";
                            MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection);
                            deleteCommand.Parameters.AddWithValue("@TarifID", tarifId);
                            deleteCommand.ExecuteNonQuery();

                            MessageBox.Show("Tarif baþarýyla silindi.");
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
                            string imagePath = Path.Combine(@"C:\Users\iclal dere\source\YemekTarifiUygulamasi\YemekTarifiUygulamasi\Resources", gorselAdi);
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
        }



        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }



    }
}
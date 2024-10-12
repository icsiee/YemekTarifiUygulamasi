using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // MySQL i�in ADO.NET k�t�phanesi

namespace YemekTarifiUygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); // Formu ve kontrolleri ba�lat

            // DataGridView'e s�tun ekle
            dataGridViewTarifler.Columns.Clear(); // �nceki s�tunlar� temizle

            // Gorsel s�tunu (Image t�r� i�in)
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "Gorsel";
            imageColumn.HeaderText = "G�rsel";
            dataGridViewTarifler.Columns.Add(imageColumn);

            // TarifID s�tununu ekle
            DataGridViewTextBoxColumn tarifIdColumn = new DataGridViewTextBoxColumn();
            tarifIdColumn.Name = "TarifID"; // Bu ismi kullanmal�s�n�z
            tarifIdColumn.HeaderText = "Tarif ID";
            tarifIdColumn.Visible = false; // G�r�nmez yapabilirsiniz
            dataGridViewTarifler.Columns.Add(tarifIdColumn);

            // Di�er s�tunlar� ekle
            dataGridViewTarifler.Columns.Add("TarifAdi", "Tarif Ad�");
            dataGridViewTarifler.Columns.Add("HazirlamaSuresi", "Haz�rlama S�resi (dk)");
            dataGridViewTarifler.Columns.Add("ToplamMaliyet", "Toplam Maliyet");

            // Di�er ayarlar (iste�e ba�l�)
            dataGridViewTarifler.AllowUserToAddRows = false; // Kullan�c�n�n yeni sat�r eklemesine izin verme

            // Form y�klendi�inde tarifleri y�kle
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

                            // Resmi y�kle, e�er yol ge�ersizse null olacak
                            Image tarifImage = null;
                            if (!string.IsNullOrEmpty(gorselYolu) && System.IO.File.Exists(gorselYolu))
                            {
                                try
                                {
                                    tarifImage = Image.FromFile(gorselYolu);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Resim y�klenemedi: " + ex.Message);
                                }
                            }

                            // Verileri DataGridView'e ekle
                            dataGridViewTarifler.Rows.Add(tarifImage, tarifId, tarifAdi, hazirlamaSuresi, maliyet);
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

        // DataGridView sat�r�na t�klay�nca detaylar� g�ster
        private void dataGridViewTarifler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ge�erli bir sat�r se�ildi mi kontrol et
            {
                // Se�ilen sat�rdaki Tarif ID'sini al
                long tarifId = Convert.ToInt64(dataGridViewTarifler.Rows[e.RowIndex].Cells["TarifID"].Value);
                ShowTarifDetails(tarifId); // Tarif detaylar�n� g�ster
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
    }
}

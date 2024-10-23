using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace YemekTarifiUygulamasi
{
    public partial class MalzemeEkleForm : Form
    {
        string connectionString = "Server=localhost;Database=yemektarifidb;Uid=ezgi;Pwd=Ke1994+-7645@;";
        private Form1 form1; // Form1 referansı


        public MalzemeEkleForm(Form1 form1)
        {
            InitializeComponent();
            cmbBirim.Items.Add("Kilogram");
            cmbBirim.Items.Add("Gram");
            cmbBirim.Items.Add("Litre");
            this.form1 = form1;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadMalzemeler();
        }

        private void LoadMalzemeler()
        {
            cmbMalzemeAdi.Items.Clear();
            List<string> malzemeListesi = new List<string>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT MalzemeAdi FROM Malzemeler ORDER BY MalzemeAdi ASC"; // Sıralı sorgu
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string malzemeAdi = reader["MalzemeAdi"].ToString();
                        malzemeListesi.Add(malzemeAdi);
                    }
                }

                // ComboBox'a malzemeleri ekleyelim
                cmbMalzemeAdi.Items.AddRange(malzemeListesi.ToArray());
                cmbMalzemeAdi.AutoCompleteMode = AutoCompleteMode.SuggestAppend; // Öneri modunu etkinleştir
                cmbMalzemeAdi.AutoCompleteSource = AutoCompleteSource.ListItems; // AutoComplete kaynaklarını belirle
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veritabanı bağlantısı sırasında hata oluştu: {ex.Message}");
            }
        }


        private float ConvertToGrams(float miktar, string birim)
        {
            switch (birim)
            {
                case "Kilogram":
                    return miktar * 1000;
                case "Gram":
                    return miktar;
                case "Litre":
                    return miktar * 1000;
                default:
                    throw new ArgumentException("Geçersiz birim.");
            }
        }

        // Yeni malzeme eklendiğinde çağrılacak metod
        private void YeniMalzemeEklendi(object sender, EventArgs e)
        {
            LoadMalzemeler(); // Malzeme listesini yeniden yükle
        }

        private void btnMalzemeEkle_Click_1(object sender, EventArgs e)
        {
            if (cmbMalzemeAdi.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir malzeme seçin.");
                return;
            }

            string malzemeAdi = cmbMalzemeAdi.SelectedItem.ToString();
            string birim = cmbBirim.SelectedItem.ToString();
            float miktar;

            if (!float.TryParse(txtMiktar.Text.Trim(), out miktar))
            {
                MessageBox.Show("Lütfen geçerli bir miktar girin.");
                return;
            }

            float miktarGrama = ConvertToGrams(miktar, birim);

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string updateQuery = "UPDATE Malzemeler SET ToplamMiktar = ToplamMiktar + @eklenenMiktar WHERE MalzemeAdi = @malzemeAdi";
                using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                {
                    updateCmd.Parameters.AddWithValue("@eklenenMiktar", miktarGrama);
                    updateCmd.Parameters.AddWithValue("@malzemeAdi", malzemeAdi);
                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Malzeme başarıyla güncellendi.");
                    }
                    else
                    {
                        MessageBox.Show("Malzeme güncellenemedi. Lütfen tekrar deneyin.");
                    }
                }
            }
            this.Close();
            form1.Show();

        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Hide();
            form1.ShowDialog();
        }

        private void btnYeniMalzemeEkle_Click_1(object sender, EventArgs e)
        {

            this.Hide();
            YeniMalzemeEkleForm yeniMalzemeEkleForm = new YeniMalzemeEkleForm(form1, this);

            // Olay dinleyicisi ekleyin
            yeniMalzemeEkleForm.MalzemeEklendi += YeniMalzemeEklendi;

            yeniMalzemeEkleForm.ShowDialog(); // Formu modals olarak aç
        }

        // Kullanıcının ComboBox'a yazdığı metne göre malzemeleri filtreleyen event
        private void cmbMalzemeAdi_TextChanged(object sender, EventArgs e)
        {
            string input = cmbMalzemeAdi.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(input))
            {
                var filteredItems = new List<string>();

                foreach (var item in cmbMalzemeAdi.Items)
                {
                    if (item.ToString().ToLower().Contains(input))
                    {
                        filteredItems.Add(item.ToString());
                    }
                }

                // Filtrelenmiş malzemeleri ComboBox'a güncelle
                cmbMalzemeAdi.Items.Clear();
                cmbMalzemeAdi.Items.AddRange(filteredItems.ToArray());
            }
            else
            {
                // Boşsa yeniden tüm malzemeleri yükle
                LoadMalzemeler();
            }
        }


        private void MalzemeEkleForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            form1.Show();
        }
    }
}

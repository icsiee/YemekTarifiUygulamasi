using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace YemekTarifiUygulamasi
{
    public partial class TarifeYeniMalzemeEkleForm : Form
    {
        string connectionString = "Server=localhost;Database=yemektarifidb;Uid=root;Pwd=1234;";
        private TarifMalzemeIliskisiForm tarifMalzemeIliskisiForm;
        public Tuple<int, string, float> MalzemeBilgileri { get; private set; }

        public TarifeYeniMalzemeEkleForm(TarifMalzemeIliskisiForm parentForm)
        {
            InitializeComponent(); // İlk önce bileşenleri başlat
            this.tarifMalzemeIliskisiForm = parentForm;

            // Birimleri cmbBirim'e ekle
            cmbBirim.Items.Add("Kilogram");
            cmbBirim.Items.Add("Gram");
            cmbBirim.Items.Add("Litre");
        }

        private float ConvertToGrams(float miktar, string birim)
        {
            switch (birim)
            {
                case "Kilogram":
                    return miktar * 1000; // 1 kg = 1000 gram
                case "Gram":
                    return miktar; // 1 gram = 1 gram
                case "Litre":
                    return miktar * 1000; // 1 litre su = 1000 gram
                default:
                    throw new ArgumentException("Geçersiz birim.");
            }
        }



        private void btnIptal_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            tarifMalzemeIliskisiForm.Show();
        }


        private void btnEkle_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; // Formu OK olarak kapat

            string malzemeAdi = txtMalzemeAdi.Text.Trim();
            string birim = cmbBirim.SelectedItem?.ToString(); // null kontrolü yapıldı
            float miktar; // Tarif için kullanılacak miktar
            decimal birimFiyat;

            // Eksik alanları kontrol et
            List<string> eksikAlanlar = new List<string>();

            if (string.IsNullOrEmpty(malzemeAdi))
            {
                eksikAlanlar.Add("Malzeme adı");
            }

            if (string.IsNullOrEmpty(birim))
            {
                eksikAlanlar.Add("Birim");
            }

            if (!float.TryParse(txtMiktar.Text.Trim(), out miktar))
            {
                eksikAlanlar.Add("Miktar");
            }

            if (!decimal.TryParse(txtBirimFiyat.Text.Trim(), out birimFiyat))
            {
                eksikAlanlar.Add("Birim fiyatı");
            }

            if (eksikAlanlar.Count > 0)
            {
                string eksikAlanlarMesaji = "Lütfen aşağıdaki alanları doldurun:\n- " + string.Join("\n- ", eksikAlanlar);
                MessageBox.Show(eksikAlanlarMesaji);
                return;
            }

            // Miktarı grama çevir
            float miktarGrams = ConvertToGrams(miktar, birim);

            // Malzeme adının veritabanında olup olmadığını kontrol et ve ekle
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string checkQuery = "SELECT COUNT(*) FROM Malzemeler WHERE MalzemeAdi = @malzemeAdi";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@malzemeAdi", malzemeAdi);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Bu malzeme zaten mevcut.");
                        return;
                    }
                }

                // Malzeme bilgilerini veritabanına ekle
                string insertQuery = "INSERT INTO Malzemeler (MalzemeAdi, ToplamMiktar, MalzemeBirim, BirimFiyat) VALUES (@malzemeAdi, @toplamMiktar, @malzemeBirim, @birimFiyat)";
                using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn))
                {
                    insertCmd.Parameters.AddWithValue("@malzemeAdi", malzemeAdi);
                    insertCmd.Parameters.AddWithValue("@toplamMiktar", 0); // Yeni malzeme başlangıçta 0 miktar
                    insertCmd.Parameters.AddWithValue("@malzemeBirim", "gram"); // Tüm birimler grama çevriliyor
                    insertCmd.Parameters.AddWithValue("@birimFiyat", birimFiyat);
                    insertCmd.ExecuteNonQuery();
                }

                // Yeni eklenen malzemenin ID'sini al
                string idQuery = "SELECT LAST_INSERT_ID()"; // Son eklenen ID'yi al
                using (MySqlCommand idCmd = new MySqlCommand(idQuery, conn))
                {
                    int malzemeId = Convert.ToInt32(idCmd.ExecuteScalar());

                    // Yeni malzemeyi tarifte kullanılacak miktar ile birlikte set et
                    MalzemeBilgileri = new Tuple<int, string, float>(malzemeId, malzemeAdi, miktarGrams);
                }

                // Başarılı ekleme mesajı
                MessageBox.Show("Malzeme başarıyla eklendi.");

                // Tarife eklenecek malzemeleri ComboBox'ta güncelle
                tarifMalzemeIliskisiForm.LoadMalzeme();
            }

            this.Hide(); // Formu kapat
            tarifMalzemeIliskisiForm.Show();
        }



    }
}

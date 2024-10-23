using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // MySQL için ADO.NET kütüphanesi

namespace YemekTarifiUygulamasi
{
    public partial class YeniMalzemeEkleForm : Form
    {
        public event EventHandler MalzemeEklendi;

        string connectionString = "Server=localhost;Database=yemektarifidb;Uid=ezgi;Pwd=Ke1994+-7645;";
        private Form1 form1; // Form1 referansı
        private MalzemeEkleForm malzemeEkleForm;

        public YeniMalzemeEkleForm(Form1 form1, MalzemeEkleForm malzemeEkleForm)
        {
            InitializeComponent();
            cmbBirim.Items.Add("Kilogram");
            cmbBirim.Items.Add("Gram");
            cmbBirim.Items.Add("Litre");
            this.form1 = form1;
            this.malzemeEkleForm = malzemeEkleForm;
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
                    // Litreyi gram cinsine çevirmek için yoğunluk bilgisi gerekiyor, örnek olarak 1 litre su 1000 gramdır
                    return miktar * 1000; // 1 litre su = 1000 gram
                default:
                    throw new ArgumentException("Geçersiz birim.");
            }
        }



        private void btnEkle_Click(object sender, EventArgs e)
        {
            string malzemeAdi = txtMalzemeAdi.Text.Trim();
            string birim = cmbBirim.SelectedItem?.ToString(); // null kontrolü yapıldı
            float miktar;
            decimal birimFiyat;

            // Kontroller
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

            // Miktar ve birim fiyatı kontrolü
            if (!float.TryParse(txtMiktar.Text.Trim(), out miktar) || !decimal.TryParse(txtBirimFiyat.Text.Trim(), out birimFiyat))
            {
                MessageBox.Show("Lütfen geçerli bir miktar ve birim fiyatı girin.");
                return;
            }

            // Malzeme adının veritabanında olup olmadığını kontrol et
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
                        this.Close();

                    }
                }

                // Miktarı gram cinsine çevir
                float miktarGrama = ConvertToGrams(miktar, birim);

                // Malzemeyi veritabanına ekle
                string insertQuery = "INSERT INTO Malzemeler (MalzemeAdi, ToplamMiktar, MalzemeBirim, BirimFiyat) VALUES (@malzemeAdi, @toplamMiktar, @malzemeBirim, @birimFiyat)";
                using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn))
                {
                    insertCmd.Parameters.AddWithValue("@malzemeAdi", malzemeAdi);
                    insertCmd.Parameters.AddWithValue("@toplamMiktar", miktarGrama);
                    insertCmd.Parameters.AddWithValue("@malzemeBirim", "Gram");
                    insertCmd.Parameters.AddWithValue("@birimFiyat", birimFiyat);
                    insertCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Malzeme başarıyla eklendi.");
            }

            MalzemeEklendi?.Invoke(this, EventArgs.Empty);

            this.Close();
            form1.Show();

        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
            malzemeEkleForm.Show();
        }


            
        private void YeniMalzemeEkleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Show();
        }

       
    }
}

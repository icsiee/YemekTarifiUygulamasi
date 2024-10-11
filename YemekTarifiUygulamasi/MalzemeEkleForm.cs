using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace YemekTarifiUygulamasi
{
    public partial class MalzemeEkleForm : Form
    {
        string connectionString = "server=localhost;Database=yemektarifidb;Uid=root;Pwd='1234';";

        public MalzemeEkleForm()
        {
            InitializeComponent();
            cmbBirim.Items.Add("Kilogram");
            cmbBirim.Items.Add("Gram");
            cmbBirim.Items.Add("Litre");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadMalzemeler();
        }

        private void LoadMalzemeler()
        {
            cmbMalzemeAdi.Items.Clear();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT MalzemeAdi FROM Malzemeler";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbMalzemeAdi.Items.Add(reader["MalzemeAdi"].ToString());
                }
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
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYeniMalzemeEkle_Click_1(object sender, EventArgs e)
        {
            YeniMalzemeEkleForm yeniMalzemeEkleForm = new YeniMalzemeEkleForm();

            // Olay dinleyicisi ekleyin
            yeniMalzemeEkleForm.MalzemeEklendi += YeniMalzemeEklendi;

            yeniMalzemeEkleForm.ShowDialog(); // Formu modals olarak aç
        }
    }
}

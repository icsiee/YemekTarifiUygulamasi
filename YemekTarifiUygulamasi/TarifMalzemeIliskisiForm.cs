using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace YemekTarifiUygulamasi
{
    public partial class TarifMalzemeIliskisiForm : Form
    {
        private string connectionString = "Server=localhost;Database=yemektarifidb;Uid=root;Pwd=1234;";
        private int tarifId;

        private List<Tuple<int, string, float>> malzemeler = new List<Tuple<int, string, float>>();

        public TarifMalzemeIliskisiForm(int tarifId)
        {
            InitializeComponent();
            this.tarifId = tarifId;
            LoadMalzemeler();
        }

        private void LoadMalzemeler()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT MalzemeID, MalzemeAdi FROM Malzemeler", connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    cmbMalzeme.Items.Add(new { ID = reader.GetInt32(0), Name = reader.GetString(1) });
                }
            }

            cmbMalzeme.DisplayMember = "Name"; // ComboBox'da görünecek olan alan
            cmbMalzeme.ValueMember = "ID"; // Seçilen nesnenin değeri
        }



        private void btnEkleMalzeme_Click_1(object sender, EventArgs e)
        {
            if (cmbMalzeme.SelectedItem != null && float.TryParse(txtMalzemeMiktar.Text, out float miktar))
            {
                var selectedMalzeme = (dynamic)cmbMalzeme.SelectedItem;
                int malzemeId = selectedMalzeme.ID;

                // Malzeme ve miktar bilgilerini listeye ekle
                malzemeler.Add(new Tuple<int, string, float>(malzemeId, selectedMalzeme.Name, miktar));

                // DataGridView'e ekle
                dataGridViewMalzemeler.Rows.Add(selectedMalzeme.Name, miktar);

                // Formu temizle
                txtMalzemeMiktar.Clear();
                cmbMalzeme.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Lütfen malzeme ve miktar bilgilerini doldurun.");
            }
        }

        private void btnKaydet_Click_1(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                foreach (var malzeme in malzemeler)
                {
                    MySqlCommand command = new MySqlCommand("INSERT INTO tarifmalzemeiliskisi (TarifID, MalzemeID, MalzemeMiktar) VALUES (@TarifID, @MalzemeID, @MalzemeMiktar)", connection);
                    command.Parameters.AddWithValue("@TarifID", tarifId);
                    command.Parameters.AddWithValue("@MalzemeID", malzeme.Item1);
                    command.Parameters.AddWithValue("@MalzemeMiktar", malzeme.Item3);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Malzemeler başarıyla kaydedildi.");
            this.Close(); // Formu kapat
                          // Form1'e geri dön
            Form1 form1 = new Form1();
            form1.Show();
            this.Close(); // Bu formu kapat
        }

        private void TarifMalzemeIliskisiForm_Load(object sender, EventArgs e)
        {

            // DataGridView'e sütun ekle
            dataGridViewMalzemeler.ColumnCount = 2; // İki sütun ekliyoruz
            dataGridViewMalzemeler.Columns[0].Name = "Malzeme"; // İlk sütun malzeme adı
            dataGridViewMalzemeler.Columns[1].Name = "Miktar";  // İkinci sütun malzeme miktarı
        }
    }
}

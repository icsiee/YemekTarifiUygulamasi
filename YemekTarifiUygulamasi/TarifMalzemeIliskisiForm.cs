using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace YemekTarifiUygulamasi
{
    public partial class TarifMalzemeIliskisiForm : Form
    {
        string connectionString = "Server=localhost;Database=yemektarifidb;Uid=root;Pwd=1234;";
        private int tarifId;
        private List<Tuple<int, string, float>> malzemeler = new List<Tuple<int, string, float>>();
        private Form1 form1; // Form1 referansını ekliyoruz

        public TarifMalzemeIliskisiForm(Form1 parentForm, int tarifId)
        {
            InitializeComponent();
            this.form1 = parentForm;  // Form1 referansını alıyoruz
            this.tarifId = tarifId;
            LoadMalzeme();
        }

        private void LoadMalzeme()
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

            cmbMalzeme.DisplayMember = "Name";
            cmbMalzeme.ValueMember = "ID";
        }

        private void btnEkleMalzeme_Click_1(object sender, EventArgs e)
        {
            if (cmbMalzeme.SelectedItem != null && float.TryParse(txtMalzemeMiktar.Text, out float miktar))
            {
                var selectedMalzeme = (dynamic)cmbMalzeme.SelectedItem;
                int malzemeId = selectedMalzeme.ID;
                string malzemeAdi = selectedMalzeme.Name;

                // Malzemenin zaten listede olup olmadığını kontrol et
                var existingMalzeme = malzemeler.Find(m => m.Item1 == malzemeId);
                if (existingMalzeme != null)
                {
                    MessageBox.Show("Bu malzeme zaten eklenmiş. Miktarı güncellemek için tabloyu düzenleyebilirsiniz.");
                    return;
                }

                // Yeni malzeme ve miktar bilgilerini listeye ekle
                malzemeler.Add(new Tuple<int, string, float>(malzemeId, malzemeAdi, miktar));

                // DataGridView'e ekle
                dataGridViewMalzemeler.Rows.Add(malzemeAdi, miktar);

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

                // Tüm malzemeleri veritabanına kaydet
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

            
            this.Hide(); // Formu gizler

            form1.Show();

            // Formu kapat
        }


        private void TarifMalzemeIliskisiForm_Load(object sender, EventArgs e)
        {
            // DataGridView'e sütun ekle
            dataGridViewMalzemeler.ColumnCount = 3; // Üç sütun ekliyoruz
            dataGridViewMalzemeler.Columns[0].Name = "Malzeme"; // İlk sütun malzeme adı
            dataGridViewMalzemeler.Columns[1].Name = "Miktar";  // İkinci sütun malzeme miktarı
            dataGridViewMalzemeler.Columns[2].Name = "İşlem";   // Üçüncü sütun silme işlemi için buton olacak

            // İşlem butonları ekle
            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "btnDelete";
            deleteButton.Text = "Sil";
            deleteButton.UseColumnTextForButtonValue = true;
            dataGridViewMalzemeler.Columns.Add(deleteButton);

            // DataGridView satır silme işlemi
            dataGridViewMalzemeler.CellClick += (s, e) =>
            {
                if (e.ColumnIndex == dataGridViewMalzemeler.Columns["btnDelete"].Index && e.RowIndex >= 0)
                {
                    var malzemeAdi = dataGridViewMalzemeler.Rows[e.RowIndex].Cells[0].Value.ToString();

                    // Miktarı stringten float'a dönüştürürken try-catch kullanmak
                    if (float.TryParse(dataGridViewMalzemeler.Rows[e.RowIndex].Cells[1].Value.ToString(), out float miktar))
                    {
                        // Listeden malzemeyi kaldır
                        malzemeler.RemoveAll(m => m.Item2 == malzemeAdi && m.Item3 == miktar);

                        // DataGridView'den satırı sil
                        dataGridViewMalzemeler.Rows.RemoveAt(e.RowIndex);
                    }
                    else
                    {
                        MessageBox.Show("Miktar verisi geçerli değil.");
                    }
                }
            };
        }
    }

}


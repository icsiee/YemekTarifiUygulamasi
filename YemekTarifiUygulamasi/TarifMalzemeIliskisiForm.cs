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

            InitializeDataGridView(); // DataGridView'i başlat
            LoadMalzeme();            // Malzemeleri yükle

            // CellClick olayını ekleyelim
            dataGridViewMalzemeler.CellClick += new DataGridViewCellEventHandler(dataGridViewMalzemeler_CellClick);
        }



        private void InitializeDataGridView()
        {
            dataGridViewMalzemeler.Columns.Clear(); // Mevcut sütunları temizle
            dataGridViewMalzemeler.Columns.Add("MalzemeAdi", "Malzeme Adı");
            dataGridViewMalzemeler.Columns.Add("Miktar", "Miktar (gram)");

            // Sil buton sütunu ekleyelim
            DataGridViewButtonColumn btnSil = new DataGridViewButtonColumn();
            btnSil.HeaderText = "Sil"; // Sütun başlığı
            btnSil.Name = "btnSil";    // Buton sütununun ismi
            btnSil.Text = "Sil";       // Her hücrede görünecek yazı
            btnSil.UseColumnTextForButtonValue = true; // Her hücrede "Sil" yazısı olsun
            dataGridViewMalzemeler.Columns.Add(btnSil); // Sütunu ekle
        }


        // LoadMalzeme metodu, ComboBox'a eklemeler için
        public void LoadMalzeme()
        {
            cmbMalzeme.Items.Clear(); // Yeni malzemeyi görebilmek için önce temizle
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

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridViewMalzemeler.CurrentRow != null)
            {
                // Kullanıcıdan silme işlemi için onay alalım
                DialogResult dialogResult = MessageBox.Show("Seçili malzemeyi silmek istediğinizden emin misiniz?", "Onay", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int index = dataGridViewMalzemeler.CurrentRow.Index;

                    // İlgili malzemeyi listeden çıkar
                    var silinenMalzeme = malzemeler[index];
                    malzemeler.RemoveAt(index);

                    // DataGridView'den sil
                    dataGridViewMalzemeler.Rows.RemoveAt(index);

                    // Eğer veritabanında da kayıtlıysa, veritabanından sil
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        MySqlCommand command = new MySqlCommand("DELETE FROM tarifmalzemeiliskisi WHERE TarifID = @tarifId AND MalzemeID = @malzemeId", connection);
                        command.Parameters.AddWithValue("@tarifId", tarifId);
                        command.Parameters.AddWithValue("@malzemeId", silinenMalzeme.Item1);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Malzeme başarıyla silindi.");
                }
            }
            else
            {
                MessageBox.Show("Silmek için bir malzeme seçin.");
            }
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
                    MySqlCommand command = new MySqlCommand("INSERT INTO tarifmalzemeiliskisi (TarifID, MalzemeID, MalzemeMiktar) VALUES (@tarifId, @malzemeId, @miktar)", connection);
                    command.Parameters.AddWithValue("@tarifId", tarifId);
                    command.Parameters.AddWithValue("@malzemeId", malzeme.Item1);
                    command.Parameters.AddWithValue("@miktar", malzeme.Item3);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Malzeme ilişkileri kaydedildi.");
            this.Close(); // Formu kapat
            form1.Show(); // Form1'i tekrar göster
        }

        private void btnYeniMalzemeEkle_Click(object sender, EventArgs e)
        {
            TarifeYeniMalzemeEkleForm yeniMalzemeForm = new TarifeYeniMalzemeEkleForm(this);
            this.Hide();
            if (yeniMalzemeForm.ShowDialog() == DialogResult.OK)
            {
                
                // Yeni malzeme eklendikten sonra bilgileri alalım
                var malzemeBilgileri = yeniMalzemeForm.MalzemeBilgileri;

                if (malzemeBilgileri != null)
                {
                    // Yeni malzeme bilgilerini alalım (ID, malzeme adı, tarifte kullanılacak miktar)
                    malzemeler.Add(malzemeBilgileri); // Listeye ekle
                    dataGridViewMalzemeler.Rows.Add(malzemeBilgileri.Item2, malzemeBilgileri.Item3); // DataGridView'e ekle
                }
            }
        }

        private void dataGridViewMalzemeler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Eğer tıklanan hücre sil butonuna aitse
            if (e.ColumnIndex == dataGridViewMalzemeler.Columns["btnSil"].Index && e.RowIndex >= 0)
            {
                // Silme işlemi için kullanıcıdan onay alalım
                DialogResult dialogResult = MessageBox.Show("Seçili malzemeyi silmek istediğinizden emin misiniz?", "Onay", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    // Satır indeksini alalım
                    int rowIndex = e.RowIndex;

                    // İlgili malzemeyi listeden çıkaralım
                    var silinenMalzeme = malzemeler[rowIndex];
                    malzemeler.RemoveAt(rowIndex);

                    // DataGridView'den satırı kaldıralım
                    dataGridViewMalzemeler.Rows.RemoveAt(rowIndex);

                    // Eğer veritabanında da kayıtlıysa, veritabanından sil
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        MySqlCommand command = new MySqlCommand("DELETE FROM tarifmalzemeiliskisi WHERE TarifID = @tarifId AND MalzemeID = @malzemeId", connection);
                        command.Parameters.AddWithValue("@tarifId", tarifId);
                        command.Parameters.AddWithValue("@malzemeId", silinenMalzeme.Item1);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Malzeme başarıyla silindi.");
                }
            }
        }



    }
}

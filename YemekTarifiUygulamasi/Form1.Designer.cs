namespace YemekTarifiUygulamasi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnMalzemeEkle = new Button();
            btnTarifEkle = new Button();
            dataGridViewTarifler = new DataGridView();
            tarifImage = new DataGridViewImageColumn();
            TarifID = new DataGridViewTextBoxColumn();
            tarifAdi = new DataGridViewTextBoxColumn();
            hazirlamaSuresi = new DataGridViewTextBoxColumn();
            maliyet = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTarifler).BeginInit();
            SuspendLayout();
            // 
            // btnMalzemeEkle
            // 
            btnMalzemeEkle.Location = new Point(177, 120);
            btnMalzemeEkle.Name = "btnMalzemeEkle";
            btnMalzemeEkle.Size = new Size(94, 29);
            btnMalzemeEkle.TabIndex = 0;
            btnMalzemeEkle.Text = "Malzeme";
            btnMalzemeEkle.UseVisualStyleBackColor = true;
            btnMalzemeEkle.Click += btnMalzemeEkle_Click_1;
            // 
            // btnTarifEkle
            // 
            btnTarifEkle.Location = new Point(409, 120);
            btnTarifEkle.Name = "btnTarifEkle";
            btnTarifEkle.Size = new Size(94, 29);
            btnTarifEkle.TabIndex = 1;
            btnTarifEkle.Text = "Tarif";
            btnTarifEkle.UseVisualStyleBackColor = true;
            btnTarifEkle.Click += btnTarifEkle_Click;
            // 
            // dataGridViewTarifler
            // 
            dataGridViewTarifler.AutoGenerateColumns = false; // Sütunların otomatik olarak üretilmesini engelle
            dataGridViewTarifler.AllowUserToAddRows = false;
            dataGridViewTarifler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTarifler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTarifler.Columns.AddRange(new DataGridViewColumn[] { TarifID, tarifImage, tarifAdi, hazirlamaSuresi, maliyet });
            dataGridViewTarifler.Location = new Point(12, 172);
            dataGridViewTarifler.Name = "dataGridViewTarifler";
            dataGridViewTarifler.ReadOnly = true;
            dataGridViewTarifler.RowHeadersWidth = 51;
            dataGridViewTarifler.RowTemplate.Height = 150;
            dataGridViewTarifler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTarifler.Size = new Size(776, 441);
            dataGridViewTarifler.TabIndex = 0;
            dataGridViewTarifler.CellClick += dataGridViewTarifler_CellClick;
            // 
            // tarifImage
            // 
            tarifImage.HeaderText = "tarifImage";
            tarifImage.MinimumWidth = 6;
            tarifImage.Name = "tarifImage";
            tarifImage.ReadOnly = true;
            // 
            // TarifID
            // 
            TarifID.HeaderText = "Column1";
            TarifID.MinimumWidth = 6;
            TarifID.Name = "TarifID";
            TarifID.ReadOnly = true;
            TarifID.Visible = false;
            // 
            // tarifAdi
            // 
            tarifAdi.HeaderText = "Tarif Adı";
            tarifAdi.MinimumWidth = 6;
            tarifAdi.Name = "tarifAdi";
            tarifAdi.ReadOnly = true;
            // 
            // hazirlamaSuresi
            // 
            hazirlamaSuresi.HeaderText = "Hazırlama Süresi";
            hazirlamaSuresi.MinimumWidth = 6;
            hazirlamaSuresi.Name = "hazirlamaSuresi";
            hazirlamaSuresi.ReadOnly = true;
            // 
            // maliyet
            // 
            maliyet.HeaderText = "Maliyet";
            maliyet.MinimumWidth = 6;
            maliyet.Name = "maliyet";
            maliyet.ReadOnly = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 625);
            Controls.Add(dataGridViewTarifler);
            Controls.Add(btnTarifEkle);
            Controls.Add(btnMalzemeEkle);
            Name = "Form1";
            Text = "Yemek Tarifleri Uygulaması";
            ((System.ComponentModel.ISupportInitialize)dataGridViewTarifler).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnMalzemeEkle;
        private Button btnTarifEkle;
        private DataGridView dataGridViewTarifler;
        private DataGridViewImageColumn tarifImage;
        private DataGridViewTextBoxColumn TarifID;
        private DataGridViewTextBoxColumn tarifAdi;
        private DataGridViewTextBoxColumn hazirlamaSuresi;
        private DataGridViewTextBoxColumn maliyet;
    }
}

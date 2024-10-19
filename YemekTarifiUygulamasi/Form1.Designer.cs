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
            TarifID = new DataGridViewTextBoxColumn();
            tarifImageColumn = new DataGridViewImageColumn();
            tarifAdi = new DataGridViewTextBoxColumn();
            hazirlamaSuresi = new DataGridViewTextBoxColumn();
            maliyet = new DataGridViewTextBoxColumn();
            eksikMaliyetColumn = new DataGridViewTextBoxColumn();
            tarifImage = new DataGridViewImageColumn();
            txtAra = new TextBox();
            btnAra = new Button();
            cmbFiltrele = new ComboBox();
            pictureBoxYenile = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTarifler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxYenile).BeginInit();
            SuspendLayout();
            // 
            // btnMalzemeEkle
            // 
            btnMalzemeEkle.Location = new Point(177, 120);
            btnMalzemeEkle.Name = "btnMalzemeEkle";
            btnMalzemeEkle.Size = new Size(94, 29);
            btnMalzemeEkle.TabIndex = 0;
            btnMalzemeEkle.Text = "Malzeme Ekle";
            btnMalzemeEkle.UseVisualStyleBackColor = true;
            btnMalzemeEkle.Click += btnMalzemeEkle_Click_1;
            // 
            // btnTarifEkle
            // 
            btnTarifEkle.Location = new Point(409, 120);
            btnTarifEkle.Name = "btnTarifEkle";
            btnTarifEkle.Size = new Size(94, 29);
            btnTarifEkle.TabIndex = 1;
            btnTarifEkle.Text = "TarifEkle";
            btnTarifEkle.UseVisualStyleBackColor = true;
            btnTarifEkle.Click += btnTarifEkle_Click;
            // 
            // dataGridViewTarifler
            // 
            dataGridViewTarifler.AllowUserToAddRows = false;
            dataGridViewTarifler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTarifler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTarifler.Columns.AddRange(new DataGridViewColumn[] { TarifID, tarifImageColumn, tarifAdi, hazirlamaSuresi, maliyet, eksikMaliyetColumn });
            dataGridViewTarifler.Location = new Point(12, 172);
            dataGridViewTarifler.Name = "dataGridViewTarifler";
            dataGridViewTarifler.ReadOnly = true;
            dataGridViewTarifler.RowHeadersWidth = 51;
            dataGridViewTarifler.RowTemplate.Height = 100;
            dataGridViewTarifler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTarifler.Size = new Size(776, 441);
            dataGridViewTarifler.TabIndex = 0;
            dataGridViewTarifler.CellContentDoubleClick += dataGridViewTarifler_CellContentDoubleClick;
            // 
            // TarifID
            // 
            TarifID.HeaderText = "Column1";
            TarifID.MinimumWidth = 6;
            TarifID.Name = "TarifID";
            TarifID.ReadOnly = true;
            TarifID.Visible = false;
            // 
            // tarifImageColumn
            // 
            tarifImageColumn.HeaderText = "Tarif Resmi";
            tarifImageColumn.MinimumWidth = 6;
            tarifImageColumn.Name = "tarifImageColumn";
            tarifImageColumn.ReadOnly = true;
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
            // eksikMaliyetColumn
            // 
            eksikMaliyetColumn.HeaderText = "Eksik Maliyet";
            eksikMaliyetColumn.MinimumWidth = 6;
            eksikMaliyetColumn.Name = "eksikMaliyetColumn";
            eksikMaliyetColumn.ReadOnly = true;
            // 
            // tarifImage
            // 
            tarifImage.HeaderText = "tarifImage";
            tarifImage.MinimumWidth = 6;
            tarifImage.Name = "tarifImage";
            tarifImage.ReadOnly = true;
            tarifImage.Width = 125;
            // 
            // txtAra
            // 
            txtAra.Location = new Point(12, 12);
            txtAra.Name = "txtAra";
            txtAra.Size = new Size(200, 27);
            txtAra.TabIndex = 0;
            // 
            // btnAra
            // 
            btnAra.Location = new Point(220, 10);
            btnAra.Name = "btnAra";
            btnAra.Size = new Size(75, 25);
            btnAra.TabIndex = 1;
            btnAra.Text = "Ara";
            btnAra.UseVisualStyleBackColor = true;
            btnAra.Click += btnAra_Click;
            // 
            // cmbFiltrele
            // 
            cmbFiltrele.FormattingEnabled = true;
            cmbFiltrele.Items.AddRange(new object[] { "Atıştırmalıklar", "Tatlılar", "İçecekler", "Sebze Yemekleri", "Kahvaltılıklar", "Ana Yemekler", "Tümü" });
            cmbFiltrele.Location = new Point(310, 12);
            cmbFiltrele.Name = "cmbFiltrele";
            cmbFiltrele.Size = new Size(150, 28);
            cmbFiltrele.TabIndex = 2;
            // 
            // pictureBoxYenile
            // 
            pictureBoxYenile.Image = Properties.Resources.indir;
            pictureBoxYenile.Location = new Point(748, 12);
            pictureBoxYenile.Name = "pictureBoxYenile";
            pictureBoxYenile.Size = new Size(40, 37);
            pictureBoxYenile.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxYenile.TabIndex = 4;
            pictureBoxYenile.TabStop = false;
            pictureBoxYenile.Click += pictureBoxYenile_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 625);
            Controls.Add(pictureBoxYenile);
            Controls.Add(cmbFiltrele);
            Controls.Add(btnAra);
            Controls.Add(txtAra);
            Controls.Add(dataGridViewTarifler);
            Controls.Add(btnTarifEkle);
            Controls.Add(btnMalzemeEkle);
            Name = "Form1";
            Text = "Yemek Tarifleri Uygulaması";
            FormClosing += Form1_FormClosing_1;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTarifler).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxYenile).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnMalzemeEkle;
        private Button btnTarifEkle;
        private DataGridView dataGridViewTarifler;
        private TextBox txtAra;
        private Button btnAra;
        private ComboBox cmbFiltrele;
        private DataGridViewTextBoxColumn TarifID;
        private DataGridViewImageColumn tarifImage;
        private DataGridViewTextBoxColumn tarifAdi;
        private DataGridViewTextBoxColumn hazirlamaSuresi;
        private DataGridViewTextBoxColumn maliyet;
        private DataGridViewImageColumn tarifImageColumn;
        private DataGridViewTextBoxColumn eksikMaliyetColumn;
        private PictureBox pictureBoxYenile;
    }
}

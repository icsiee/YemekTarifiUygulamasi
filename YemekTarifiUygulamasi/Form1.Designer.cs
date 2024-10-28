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
            checkedListBoxMalzemeler = new CheckedListBox();
            btnAra1 = new Button();
            minMalzemeSayisi = new NumericUpDown();
            maxMalzemeSayisi = new NumericUpDown();
            btnFiltrele = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTarifler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxYenile).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minMalzemeSayisi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maxMalzemeSayisi).BeginInit();
            SuspendLayout();
            // 
            // btnMalzemeEkle
            // 
            btnMalzemeEkle.Location = new Point(164, 118);
            btnMalzemeEkle.Name = "btnMalzemeEkle";
            btnMalzemeEkle.Size = new Size(157, 29);
            btnMalzemeEkle.TabIndex = 0;
            btnMalzemeEkle.Text = "MALZEME EKLE";
            btnMalzemeEkle.UseVisualStyleBackColor = true;
            btnMalzemeEkle.Click += btnMalzemeEkle_Click_1;
            // 
            // btnTarifEkle
            // 
            btnTarifEkle.Location = new Point(21, 118);
            btnTarifEkle.Name = "btnTarifEkle";
            btnTarifEkle.Size = new Size(137, 29);
            btnTarifEkle.TabIndex = 1;
            btnTarifEkle.Text = "TARİF EKLE";
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
            dataGridViewTarifler.Size = new Size(828, 823);
            dataGridViewTarifler.TabIndex = 0;
            dataGridViewTarifler.CellContentClick += dataGridViewTarifler_CellContentClick;
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
            cmbFiltrele.Location = new Point(108, 60);
            cmbFiltrele.Name = "cmbFiltrele";
            cmbFiltrele.Size = new Size(150, 28);
            cmbFiltrele.TabIndex = 2;
            // 
            // pictureBoxYenile
            // 
            pictureBoxYenile.Image = Properties.Resources.indir;
            pictureBoxYenile.Location = new Point(800, 129);
            pictureBoxYenile.Name = "pictureBoxYenile";
            pictureBoxYenile.Size = new Size(40, 37);
            pictureBoxYenile.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxYenile.TabIndex = 4;
            pictureBoxYenile.TabStop = false;
            pictureBoxYenile.Click += pictureBoxYenile_Click;
            // 
            // checkedListBoxMalzemeler
            // 
            checkedListBoxMalzemeler.FormattingEnabled = true;
            checkedListBoxMalzemeler.Location = new Point(846, 196);
            checkedListBoxMalzemeler.Name = "checkedListBoxMalzemeler";
            checkedListBoxMalzemeler.Size = new Size(304, 356);
            checkedListBoxMalzemeler.TabIndex = 5;
            // 
            // btnAra1
            // 
            btnAra1.Location = new Point(934, 127);
            btnAra1.Name = "btnAra1";
            btnAra1.Size = new Size(131, 48);
            btnAra1.TabIndex = 6;
            btnAra1.Text = "FİLTRELE";
            btnAra1.UseVisualStyleBackColor = true;
            btnAra1.Click += btnAra1_Click;
            // 
            // minMalzemeSayisi
            // 
            minMalzemeSayisi.Location = new Point(390, 35);
            minMalzemeSayisi.Name = "minMalzemeSayisi";
            minMalzemeSayisi.Size = new Size(150, 27);
            minMalzemeSayisi.TabIndex = 7;
            // 
            // maxMalzemeSayisi
            // 
            maxMalzemeSayisi.Location = new Point(390, 81);
            maxMalzemeSayisi.Name = "maxMalzemeSayisi";
            maxMalzemeSayisi.Size = new Size(150, 27);
            maxMalzemeSayisi.TabIndex = 8;
            // 
            // btnFiltrele
            // 
            btnFiltrele.Location = new Point(422, 127);
            btnFiltrele.Name = "btnFiltrele";
            btnFiltrele.Size = new Size(94, 29);
            btnFiltrele.TabIndex = 9;
            btnFiltrele.Text = "seç";
            btnFiltrele.UseVisualStyleBackColor = true;
            btnFiltrele.Click += btnFiltrele_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(319, 12);
            label1.Name = "label1";
            label1.Size = new Size(310, 20);
            label1.TabIndex = 10;
            label1.Text = "Minimum ve Maksimum malzeme adeti seçin.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 63);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 11;
            label2.Text = "KATEGORİ:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(347, 42);
            label3.Name = "label3";
            label3.Size = new Size(37, 20);
            label3.TabIndex = 12;
            label3.Text = "MİN";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(343, 88);
            label4.Name = "label4";
            label4.Size = new Size(41, 20);
            label4.TabIndex = 13;
            label4.Text = "MAX";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._94a41fc4_ffb8_46d3_a793_82056157e088;
            ClientSize = new Size(1188, 1055);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnFiltrele);
            Controls.Add(maxMalzemeSayisi);
            Controls.Add(minMalzemeSayisi);
            Controls.Add(btnAra1);
            Controls.Add(checkedListBoxMalzemeler);
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
            ((System.ComponentModel.ISupportInitialize)minMalzemeSayisi).EndInit();
            ((System.ComponentModel.ISupportInitialize)maxMalzemeSayisi).EndInit();
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
        private CheckedListBox checkedListBoxMalzemeler;
        private Button btnAra1;
        private NumericUpDown minMalzemeSayisi;
        private NumericUpDown maxMalzemeSayisi;
        private Button btnFiltrele;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}

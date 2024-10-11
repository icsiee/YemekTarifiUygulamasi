namespace YemekTarifiUygulamasi
{
    partial class YeniMalzemeEkleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnEkle = new Button();
            btnIptal = new Button();
            txtMalzemeAdi = new TextBox();
            txtMiktar = new TextBox();
            txtBirimFiyat = new TextBox();
            cmbBirim = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 78);
            label1.Name = "label1";
            label1.Size = new Size(100, 20);
            label1.TabIndex = 0;
            label1.Text = "Malzeme Adı:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 142);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 1;
            label2.Text = "Birim:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 199);
            label3.Name = "label3";
            label3.Size = new Size(120, 20);
            label3.TabIndex = 2;
            label3.Text = "Eklenecek Miktar";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(38, 264);
            label4.Name = "label4";
            label4.Size = new Size(183, 20);
            label4.TabIndex = 3;
            label4.Text = "Birim Fiyat (100 gram için)";
            // 
            // btnEkle
            // 
            btnEkle.Location = new Point(129, 328);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(94, 29);
            btnEkle.TabIndex = 4;
            btnEkle.Text = "btnEkle";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // btnIptal
            // 
            btnIptal.Location = new Point(290, 326);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(94, 29);
            btnIptal.TabIndex = 5;
            btnIptal.Text = "btnIptal";
            btnIptal.UseVisualStyleBackColor = true;
            btnIptal.Click += btnIptal_Click;
            // 
            // txtMalzemeAdi
            // 
            txtMalzemeAdi.Location = new Point(192, 84);
            txtMalzemeAdi.Name = "txtMalzemeAdi";
            txtMalzemeAdi.Size = new Size(125, 27);
            txtMalzemeAdi.TabIndex = 6;
            // 
            // txtMiktar
            // 
            txtMiktar.Location = new Point(197, 199);
            txtMiktar.Name = "txtMiktar";
            txtMiktar.Size = new Size(125, 27);
            txtMiktar.TabIndex = 7;
            // 
            // txtBirimFiyat
            // 
            txtBirimFiyat.Location = new Point(227, 257);
            txtBirimFiyat.Name = "txtBirimFiyat";
            txtBirimFiyat.Size = new Size(125, 27);
            txtBirimFiyat.TabIndex = 8;
            // 
            // cmbBirim
            // 
            cmbBirim.FormattingEnabled = true;
            cmbBirim.Location = new Point(193, 144);
            cmbBirim.Name = "cmbBirim";
            cmbBirim.Size = new Size(151, 28);
            cmbBirim.TabIndex = 9;
            // 
            // YeniMalzemeEkleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbBirim);
            Controls.Add(txtBirimFiyat);
            Controls.Add(txtMiktar);
            Controls.Add(txtMalzemeAdi);
            Controls.Add(btnIptal);
            Controls.Add(btnEkle);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "YeniMalzemeEkleForm";
            Text = "YeniMalzemeEkleForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnEkle;
        private Button btnIptal;
        private TextBox txtMalzemeAdi;
        private TextBox txtMiktar;
        private TextBox txtBirimFiyat;
        private ComboBox cmbBirim;
    }
}
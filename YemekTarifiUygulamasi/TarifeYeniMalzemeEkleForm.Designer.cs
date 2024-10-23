namespace YemekTarifiUygulamasi
{
    partial class TarifeYeniMalzemeEkleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TarifeYeniMalzemeEkleForm));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtMalzemeAdi = new TextBox();
            cmbBirim = new ComboBox();
            txtMiktar = new TextBox();
            txtBirimFiyat = new TextBox();
            btnEkle = new Button();
            btnIptal = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.PeachPuff;
            label1.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(189, 121);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(157, 29);
            label1.TabIndex = 1;
            label1.Text = "Malzeme Adı:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.PeachPuff;
            label2.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(189, 189);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(82, 29);
            label2.TabIndex = 2;
            label2.Text = "Birim:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.PeachPuff;
            label3.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(189, 256);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(208, 29);
            label3.TabIndex = 3;
            label3.Text = "Eklenecek Miktar:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.PeachPuff;
            label4.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(189, 326);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(313, 29);
            label4.TabIndex = 4;
            label4.Text = "Birim Fiyat (100 gram için):";
            // 
            // txtMalzemeAdi
            // 
            txtMalzemeAdi.Location = new Point(525, 121);
            txtMalzemeAdi.Margin = new Padding(5, 4, 5, 4);
            txtMalzemeAdi.Name = "txtMalzemeAdi";
            txtMalzemeAdi.Size = new Size(147, 27);
            txtMalzemeAdi.TabIndex = 7;
            // 
            // cmbBirim
            // 
            cmbBirim.BackColor = SystemColors.HighlightText;
            cmbBirim.FormattingEnabled = true;
            cmbBirim.Location = new Point(525, 189);
            cmbBirim.Margin = new Padding(5, 4, 5, 4);
            cmbBirim.Name = "cmbBirim";
            cmbBirim.Size = new Size(147, 28);
            cmbBirim.TabIndex = 10;
            // 
            // txtMiktar
            // 
            txtMiktar.BackColor = SystemColors.HighlightText;
            txtMiktar.Location = new Point(525, 256);
            txtMiktar.Margin = new Padding(5, 4, 5, 4);
            txtMiktar.Name = "txtMiktar";
            txtMiktar.Size = new Size(147, 27);
            txtMiktar.TabIndex = 11;
            // 
            // txtBirimFiyat
            // 
            txtBirimFiyat.Location = new Point(525, 326);
            txtBirimFiyat.Margin = new Padding(5, 4, 5, 4);
            txtBirimFiyat.Name = "txtBirimFiyat";
            txtBirimFiyat.Size = new Size(147, 27);
            txtBirimFiyat.TabIndex = 12;
            // 
            // btnEkle
            // 
            btnEkle.BackColor = Color.Red;
            btnEkle.Font = new Font("Sitka Small", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnEkle.ForeColor = SystemColors.ButtonHighlight;
            btnEkle.Location = new Point(208, 450);
            btnEkle.Margin = new Padding(5, 4, 5, 4);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(170, 54);
            btnEkle.TabIndex = 13;
            btnEkle.Text = "KAYDET";
            btnEkle.UseVisualStyleBackColor = false;
            btnEkle.Click += btnEkle_Click_1;
            // 
            // btnIptal
            // 
            btnIptal.BackColor = Color.Red;
            btnIptal.Font = new Font("Sitka Small", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnIptal.ForeColor = SystemColors.ButtonHighlight;
            btnIptal.Location = new Point(468, 450);
            btnIptal.Margin = new Padding(5, 4, 5, 4);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(170, 54);
            btnIptal.TabIndex = 14;
            btnIptal.Text = "İPTAL";
            btnIptal.UseVisualStyleBackColor = false;
            btnIptal.Click += btnIptal_Click_1;
            // 
            // TarifeYeniMalzemeEkleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(782, 753);
            Controls.Add(btnIptal);
            Controls.Add(btnEkle);
            Controls.Add(txtBirimFiyat);
            Controls.Add(txtMiktar);
            Controls.Add(cmbBirim);
            Controls.Add(txtMalzemeAdi);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TarifeYeniMalzemeEkleForm";
            Text = "TarifeYeniMalzemeEkleForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtMalzemeAdi;
        private ComboBox cmbBirim;
        private TextBox txtMiktar;
        private TextBox txtBirimFiyat;
        private Button btnEkle;
        private Button btnIptal;
    }
}
namespace YemekTarifiUygulamasi
{
    partial class MalzemeEkleForm
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
            cmbMalzemeAdi = new ComboBox();
            cmbBirim = new ComboBox();
            txtMiktar = new TextBox();
            btnMalzemeEkle = new Button();
            btnIptal = new Button();
            btnYeniMalzemeEkle = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.PeachPuff;
            label1.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(113, 99);
            label1.Name = "label1";
            label1.Size = new Size(157, 29);
            label1.TabIndex = 0;
            label1.Text = "Malzeme Adı:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.PeachPuff;
            label2.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(113, 145);
            label2.Name = "label2";
            label2.Size = new Size(82, 29);
            label2.TabIndex = 1;
            label2.Text = "Birim:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.PeachPuff;
            label3.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(113, 188);
            label3.Name = "label3";
            label3.Size = new Size(208, 29);
            label3.TabIndex = 2;
            label3.Text = "Eklenecek Miktar:";
            // 
            // cmbMalzemeAdi
            // 
            cmbMalzemeAdi.BackColor = SystemColors.ButtonHighlight;
            cmbMalzemeAdi.FormattingEnabled = true;
            cmbMalzemeAdi.Location = new Point(366, 100);
            cmbMalzemeAdi.Name = "cmbMalzemeAdi";
            cmbMalzemeAdi.Size = new Size(141, 28);
            cmbMalzemeAdi.TabIndex = 3;
            // 
            // cmbBirim
            // 
            cmbBirim.FormattingEnabled = true;
            cmbBirim.Location = new Point(366, 145);
            cmbBirim.Name = "cmbBirim";
            cmbBirim.Size = new Size(141, 28);
            cmbBirim.TabIndex = 4;
            // 
            // txtMiktar
            // 
            txtMiktar.Location = new Point(366, 188);
            txtMiktar.Name = "txtMiktar";
            txtMiktar.Size = new Size(141, 27);
            txtMiktar.TabIndex = 5;
            // 
            // btnMalzemeEkle
            // 
            btnMalzemeEkle.BackColor = Color.Red;
            btnMalzemeEkle.Font = new Font("Sitka Small", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnMalzemeEkle.ForeColor = SystemColors.ButtonHighlight;
            btnMalzemeEkle.Location = new Point(134, 274);
            btnMalzemeEkle.Name = "btnMalzemeEkle";
            btnMalzemeEkle.Size = new Size(167, 56);
            btnMalzemeEkle.TabIndex = 6;
            btnMalzemeEkle.Text = "KAYDET";
            btnMalzemeEkle.UseVisualStyleBackColor = false;
            btnMalzemeEkle.Click += btnMalzemeEkle_Click_1;
            // 
            // btnIptal
            // 
            btnIptal.BackColor = Color.Red;
            btnIptal.Font = new Font("Sitka Small", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnIptal.ForeColor = SystemColors.ButtonHighlight;
            btnIptal.Location = new Point(226, 348);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(167, 57);
            btnIptal.TabIndex = 7;
            btnIptal.Text = "İPTAL";
            btnIptal.UseVisualStyleBackColor = false;
            btnIptal.Click += btnIptal_Click;
            // 
            // btnYeniMalzemeEkle
            // 
            btnYeniMalzemeEkle.BackColor = Color.Red;
            btnYeniMalzemeEkle.Font = new Font("Sitka Small", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnYeniMalzemeEkle.ForeColor = SystemColors.ButtonHighlight;
            btnYeniMalzemeEkle.Location = new Point(316, 274);
            btnYeniMalzemeEkle.Name = "btnYeniMalzemeEkle";
            btnYeniMalzemeEkle.Size = new Size(167, 56);
            btnYeniMalzemeEkle.TabIndex = 8;
            btnYeniMalzemeEkle.Text = "YENİ MALZEME";
            btnYeniMalzemeEkle.UseVisualStyleBackColor = false;
            btnYeniMalzemeEkle.Click += btnYeniMalzemeEkle_Click_1;
            // 
            // MalzemeEkleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.af32c285_45df_4497_995a_c54cc1976a93;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(582, 553);
            Controls.Add(btnYeniMalzemeEkle);
            Controls.Add(btnIptal);
            Controls.Add(btnMalzemeEkle);
            Controls.Add(txtMiktar);
            Controls.Add(cmbBirim);
            Controls.Add(cmbMalzemeAdi);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MalzemeEkleForm";
            Text = "MalzemeEkleForm";
            FormClosing += MalzemeEkleForm_FormClosing_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox cmbMalzemeAdi;
        private ComboBox cmbBirim;
        private TextBox txtMiktar;
        private Button btnMalzemeEkle;
        private Button btnIptal;
        private Button btnYeniMalzemeEkle;
    }
}
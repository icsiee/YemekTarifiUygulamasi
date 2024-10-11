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
            label1.Location = new Point(32, 42);
            label1.Name = "label1";
            label1.Size = new Size(93, 20);
            label1.TabIndex = 0;
            label1.Text = "Malzeme Ad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 94);
            label2.Name = "label2";
            label2.Size = new Size(44, 20);
            label2.TabIndex = 1;
            label2.Text = "Birim";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 147);
            label3.Name = "label3";
            label3.Size = new Size(120, 20);
            label3.TabIndex = 2;
            label3.Text = "Eklenecek Miktar";
            // 
            // cmbMalzemeAdi
            // 
            cmbMalzemeAdi.FormattingEnabled = true;
            cmbMalzemeAdi.Location = new Point(133, 42);
            cmbMalzemeAdi.Name = "cmbMalzemeAdi";
            cmbMalzemeAdi.Size = new Size(151, 28);
            cmbMalzemeAdi.TabIndex = 3;
            // 
            // cmbBirim
            // 
            cmbBirim.FormattingEnabled = true;
            cmbBirim.Location = new Point(132, 100);
            cmbBirim.Name = "cmbBirim";
            cmbBirim.Size = new Size(151, 28);
            cmbBirim.TabIndex = 4;
            // 
            // txtMiktar
            // 
            txtMiktar.Location = new Point(172, 144);
            txtMiktar.Name = "txtMiktar";
            txtMiktar.Size = new Size(125, 27);
            txtMiktar.TabIndex = 5;
            // 
            // btnMalzemeEkle
            // 
            btnMalzemeEkle.Location = new Point(55, 256);
            btnMalzemeEkle.Name = "btnMalzemeEkle";
            btnMalzemeEkle.Size = new Size(94, 29);
            btnMalzemeEkle.TabIndex = 6;
            btnMalzemeEkle.Text = "btnEkle";
            btnMalzemeEkle.UseVisualStyleBackColor = true;
            btnMalzemeEkle.Click += btnMalzemeEkle_Click_1;
            // 
            // btnIptal
            // 
            btnIptal.Location = new Point(203, 252);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(94, 29);
            btnIptal.TabIndex = 7;
            btnIptal.Text = "btnIptal";
            btnIptal.UseVisualStyleBackColor = true;
            btnIptal.Click += btnIptal_Click;
            // 
            // btnYeniMalzemeEkle
            // 
            btnYeniMalzemeEkle.Location = new Point(350, 110);
            btnYeniMalzemeEkle.Name = "btnYeniMalzemeEkle";
            btnYeniMalzemeEkle.Size = new Size(94, 29);
            btnYeniMalzemeEkle.TabIndex = 8;
            btnYeniMalzemeEkle.Text = "yeni malzeme";
            btnYeniMalzemeEkle.UseVisualStyleBackColor = true;
            btnYeniMalzemeEkle.Click += btnYeniMalzemeEkle_Click_1;
            // 
            // MalzemeEkleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
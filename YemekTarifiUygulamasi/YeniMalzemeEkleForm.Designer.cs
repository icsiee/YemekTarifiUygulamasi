﻿namespace YemekTarifiUygulamasi
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
            label1.BackColor = Color.PeachPuff;
            label1.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(99, 102);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(157, 29);
            label1.TabIndex = 0;
            label1.Text = "Malzeme Adı:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(99, 149);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(82, 29);
            label2.TabIndex = 1;
            label2.Text = "Birim:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(99, 200);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(208, 29);
            label3.TabIndex = 2;
            label3.Text = "Eklenecek Miktar:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(99, 250);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(313, 29);
            label4.TabIndex = 3;
            label4.Text = "Birim Fiyat (100 gram için):";
            // 
            // btnEkle
            // 
            btnEkle.BackColor = Color.Red;
            btnEkle.Font = new Font("Sitka Small", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnEkle.ForeColor = SystemColors.ButtonHighlight;
            btnEkle.Location = new Point(109, 345);
            btnEkle.Margin = new Padding(5, 4, 5, 4);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(170, 54);
            btnEkle.TabIndex = 4;
            btnEkle.Text = "KAYDET";
            btnEkle.UseVisualStyleBackColor = false;
            btnEkle.Click += btnEkle_Click;
            // 
            // btnIptal
            // 
            btnIptal.BackColor = Color.Red;
            btnIptal.Font = new Font("Sitka Small", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnIptal.ForeColor = SystemColors.ButtonHighlight;
            btnIptal.Location = new Point(308, 345);
            btnIptal.Margin = new Padding(5, 4, 5, 4);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(170, 54);
            btnIptal.TabIndex = 5;
            btnIptal.Text = "İPTAL";
            btnIptal.UseVisualStyleBackColor = false;
            btnIptal.Click += btnIptal_Click;
            // 
            // txtMalzemeAdi
            // 
            txtMalzemeAdi.Location = new Point(422, 102);
            txtMalzemeAdi.Margin = new Padding(5, 4, 5, 4);
            txtMalzemeAdi.Name = "txtMalzemeAdi";
            txtMalzemeAdi.Size = new Size(98, 29);
            txtMalzemeAdi.TabIndex = 6;
            // 
            // txtMiktar
            // 
            txtMiktar.BackColor = SystemColors.HighlightText;
            txtMiktar.Location = new Point(422, 201);
            txtMiktar.Margin = new Padding(5, 4, 5, 4);
            txtMiktar.Name = "txtMiktar";
            txtMiktar.Size = new Size(98, 29);
            txtMiktar.TabIndex = 7;
            // 
            // txtBirimFiyat
            // 
            txtBirimFiyat.Location = new Point(422, 251);
            txtBirimFiyat.Margin = new Padding(5, 4, 5, 4);
            txtBirimFiyat.Name = "txtBirimFiyat";
            txtBirimFiyat.Size = new Size(98, 29);
            txtBirimFiyat.TabIndex = 8;
            // 
            // cmbBirim
            // 
            cmbBirim.BackColor = SystemColors.HighlightText;
            cmbBirim.FormattingEnabled = true;
            cmbBirim.Location = new Point(422, 150);
            cmbBirim.Margin = new Padding(5, 4, 5, 4);
            cmbBirim.Name = "cmbBirim";
            cmbBirim.Size = new Size(98, 32);
            cmbBirim.TabIndex = 9;
            // 
            // YeniMalzemeEkleForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PeachPuff;
            BackgroundImage = Properties.Resources.af32c285_45df_4497_995a_c54cc1976a93;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(582, 553);
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
            Font = new Font("Sitka Small", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 162);
            ForeColor = SystemColors.ActiveCaptionText;
            Margin = new Padding(5, 4, 5, 4);
            Name = "YeniMalzemeEkleForm";
            Text = "YeniMalzemeEkleForm";
            FormClosing += YeniMalzemeEkleForm_FormClosing;
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
﻿namespace YemekTarifiUygulamasi
{
    partial class TarifMalzemeIliskisiForm
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
            cmbMalzeme = new ComboBox();
            txtMalzemeMiktar = new TextBox();
            btnEkleMalzeme = new Button();
            btnKaydet = new Button();
            dataGridViewMalzemeler = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            btnYeniMalzemeEkle = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMalzemeler).BeginInit();
            SuspendLayout();
            // 
            // cmbMalzeme
            // 
            cmbMalzeme.FormattingEnabled = true;
            cmbMalzeme.Location = new Point(191, 35);
            cmbMalzeme.Name = "cmbMalzeme";
            cmbMalzeme.Size = new Size(151, 28);
            cmbMalzeme.TabIndex = 0;
            // 
            // txtMalzemeMiktar
            // 
            txtMalzemeMiktar.Location = new Point(191, 109);
            txtMalzemeMiktar.Name = "txtMalzemeMiktar";
            txtMalzemeMiktar.Size = new Size(125, 27);
            txtMalzemeMiktar.TabIndex = 1;
            // 
            // btnEkleMalzeme
            // 
            btnEkleMalzeme.Location = new Point(517, 166);
            btnEkleMalzeme.Name = "btnEkleMalzeme";
            btnEkleMalzeme.Size = new Size(94, 29);
            btnEkleMalzeme.TabIndex = 2;
            btnEkleMalzeme.Text = "btnEkleMalzeme";
            btnEkleMalzeme.UseVisualStyleBackColor = true;
            btnEkleMalzeme.Click += btnEkleMalzeme_Click_1;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(124, 270);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(94, 29);
            btnKaydet.TabIndex = 3;
            btnKaydet.Text = "btnKaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click_1;
            // 
            // dataGridViewMalzemeler
            // 
            dataGridViewMalzemeler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMalzemeler.Location = new Point(334, 211);
            dataGridViewMalzemeler.Name = "dataGridViewMalzemeler";
            dataGridViewMalzemeler.RowHeadersWidth = 51;
            dataGridViewMalzemeler.Size = new Size(438, 227);
            dataGridViewMalzemeler.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(72, 38);
            label1.Name = "label1";
            label1.Size = new Size(87, 20);
            label1.TabIndex = 5;
            label1.Text = "Malzemeler";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(108, 116);
            label2.Name = "label2";
            label2.Size = new Size(51, 20);
            label2.TabIndex = 6;
            label2.Text = "Miktar";
            // 
            // btnYeniMalzemeEkle
            // 
            btnYeniMalzemeEkle.Location = new Point(429, 70);
            btnYeniMalzemeEkle.Name = "btnYeniMalzemeEkle";
            btnYeniMalzemeEkle.Size = new Size(94, 29);
            btnYeniMalzemeEkle.TabIndex = 7;
            btnYeniMalzemeEkle.Text = "button1";
            btnYeniMalzemeEkle.UseVisualStyleBackColor = true;
            btnYeniMalzemeEkle.Click += btnYeniMalzemeEkle_Click;
            // 
            // TarifMalzemeIliskisiForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnYeniMalzemeEkle);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridViewMalzemeler);
            Controls.Add(btnKaydet);
            Controls.Add(btnEkleMalzeme);
            Controls.Add(txtMalzemeMiktar);
            Controls.Add(cmbMalzeme);
            Name = "TarifMalzemeIliskisiForm";
            Text = "TarifMalzemeIliskisiForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewMalzemeler).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbMalzeme;
        private TextBox txtMalzemeMiktar;
        private Button btnEkleMalzeme;
        private Button btnKaydet;
        private DataGridView dataGridViewMalzemeler;
        private Label label1;
        private Label label2;
        private Button btnYeniMalzemeEkle;
    }
}
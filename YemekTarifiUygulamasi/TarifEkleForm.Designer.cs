namespace YemekTarifiUygulamasi
{
    partial class TarifEkleForm
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
            txtTarifAdi = new TextBox();
            txtHazirlamaSuresi = new TextBox();
            txtTalimatlar = new TextBox();
            btnEkle = new Button();
            cmbKategori = new ComboBox();
            pbGorsel = new PictureBox();
            btnResimSec = new Button();
            ofdResimSec = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)pbGorsel).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 81);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 0;
            label1.Text = "Tarif Adı";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 135);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 1;
            label2.Text = "Kategori";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 197);
            label3.Name = "label3";
            label3.Size = new Size(161, 20);
            label3.TabIndex = 2;
            label3.Text = "Hazırlama Süresi (saat)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(47, 255);
            label4.Name = "label4";
            label4.Size = new Size(74, 20);
            label4.TabIndex = 3;
            label4.Text = "Talimatlar";
            // 
            // txtTarifAdi
            // 
            txtTarifAdi.Location = new Point(171, 90);
            txtTarifAdi.Name = "txtTarifAdi";
            txtTarifAdi.Size = new Size(125, 27);
            txtTarifAdi.TabIndex = 4;
            // 
            // txtHazirlamaSuresi
            // 
            txtHazirlamaSuresi.Location = new Point(222, 194);
            txtHazirlamaSuresi.Name = "txtHazirlamaSuresi";
            txtHazirlamaSuresi.Size = new Size(125, 27);
            txtHazirlamaSuresi.TabIndex = 5;
            // 
            // txtTalimatlar
            // 
            txtTalimatlar.Location = new Point(172, 255);
            txtTalimatlar.Name = "txtTalimatlar";
            txtTalimatlar.Size = new Size(125, 27);
            txtTalimatlar.TabIndex = 6;
            // 
            // btnEkle
            // 
            btnEkle.Location = new Point(135, 329);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(94, 29);
            btnEkle.TabIndex = 7;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // cmbKategori
            // 
            cmbKategori.FormattingEnabled = true;
            cmbKategori.Location = new Point(177, 139);
            cmbKategori.Name = "cmbKategori";
            cmbKategori.Size = new Size(151, 28);
            cmbKategori.TabIndex = 8;
            // 
            // pbGorsel
            // 
            pbGorsel.Location = new Point(387, 12);
            pbGorsel.Name = "pbGorsel";
            pbGorsel.Size = new Size(285, 263);
            pbGorsel.TabIndex = 9;
            pbGorsel.TabStop = false;
            // 
            // btnResimSec
            // 
            btnResimSec.Location = new Point(489, 294);
            btnResimSec.Name = "btnResimSec";
            btnResimSec.Size = new Size(94, 29);
            btnResimSec.TabIndex = 10;
            btnResimSec.Text = "resim ekle";
            btnResimSec.UseVisualStyleBackColor = true;
            btnResimSec.Click += btnResimSec_Click_1;
            // 
            // ofdResimSec
            // 
            ofdResimSec.FileName = "openFileDialog1";
            // 
            // TarifEkleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnResimSec);
            Controls.Add(pbGorsel);
            Controls.Add(cmbKategori);
            Controls.Add(btnEkle);
            Controls.Add(txtTalimatlar);
            Controls.Add(txtHazirlamaSuresi);
            Controls.Add(txtTarifAdi);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TarifEkleForm";
            Text = "TarifEkleForm";
            ((System.ComponentModel.ISupportInitialize)pbGorsel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtTarifAdi;
        private TextBox txtHazirlamaSuresi;
        private TextBox txtTalimatlar;
        private Button btnEkle;
        private ComboBox cmbKategori;
        private PictureBox pbGorsel;
        private Button btnResimSec;
        private OpenFileDialog ofdResimSec;
    }
}
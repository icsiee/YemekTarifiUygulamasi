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
            btnEkle = new Button();
            cmbKategori = new ComboBox();
            pbGorsel = new PictureBox();
            ofdResimSec = new OpenFileDialog();
            lstTalimatlar = new ListBox();
            btnMaddeEkle = new Button();
            txtMadde = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pbGorsel).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.PeachPuff;
            label1.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(115, 29);
            label1.TabIndex = 0;
            label1.Text = "Tarif Adı:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.PeachPuff;
            label2.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(14, 66);
            label2.Name = "label2";
            label2.Size = new Size(113, 29);
            label2.TabIndex = 1;
            label2.Text = "Kategori:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.PeachPuff;
            label3.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(12, 110);
            label3.Name = "label3";
            label3.Size = new Size(277, 29);
            label3.TabIndex = 2;
            label3.Text = "Hazırlama Süresi (saat):";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.PeachPuff;
            label4.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label4.Location = new Point(14, 152);
            label4.Name = "label4";
            label4.Size = new Size(134, 29);
            label4.TabIndex = 3;
            label4.Text = "Talimatlar:";
            // 
            // txtTarifAdi
            // 
            txtTarifAdi.Location = new Point(133, 26);
            txtTarifAdi.Name = "txtTarifAdi";
            txtTarifAdi.Size = new Size(125, 27);
            txtTarifAdi.TabIndex = 4;
            // 
            // txtHazirlamaSuresi
            // 
            txtHazirlamaSuresi.Location = new Point(295, 114);
            txtHazirlamaSuresi.Name = "txtHazirlamaSuresi";
            txtHazirlamaSuresi.Size = new Size(125, 27);
            txtHazirlamaSuresi.TabIndex = 5;
            // 
            // btnEkle
            // 
            btnEkle.BackColor = Color.Red;
            btnEkle.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnEkle.Location = new Point(72, 375);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(160, 52);
            btnEkle.TabIndex = 7;
            btnEkle.Text = "KAYDET";
            btnEkle.UseVisualStyleBackColor = false;
            btnEkle.Click += btnEkle_Click;
            // 
            // cmbKategori
            // 
            cmbKategori.FormattingEnabled = true;
            cmbKategori.Location = new Point(133, 67);
            cmbKategori.Name = "cmbKategori";
            cmbKategori.Size = new Size(125, 28);
            cmbKategori.TabIndex = 8;
            // 
            // pbGorsel
            // 
            pbGorsel.BackgroundImageLayout = ImageLayout.Center;
            pbGorsel.BorderStyle = BorderStyle.Fixed3D;
            pbGorsel.Location = new Point(72, 235);
            pbGorsel.Name = "pbGorsel";
            pbGorsel.Size = new Size(148, 134);
            pbGorsel.TabIndex = 9;
            pbGorsel.TabStop = false;
            pbGorsel.Paint += pbGorsel_Paint;
            // 
            // ofdResimSec
            // 
            ofdResimSec.FileName = "openFileDialog1";
            // 
            // lstTalimatlar
            // 
            lstTalimatlar.FormattingEnabled = true;
            lstTalimatlar.Location = new Point(355, 225);
            lstTalimatlar.Name = "lstTalimatlar";
            lstTalimatlar.Size = new Size(215, 204);
            lstTalimatlar.TabIndex = 12;
            // 
            // btnMaddeEkle
            // 
            btnMaddeEkle.Location = new Point(307, 156);
            btnMaddeEkle.Name = "btnMaddeEkle";
            btnMaddeEkle.Size = new Size(40, 29);
            btnMaddeEkle.TabIndex = 14;
            btnMaddeEkle.Text = "button1";
            btnMaddeEkle.UseVisualStyleBackColor = true;
            btnMaddeEkle.Click += btnMaddeEkle_Click_1;
            // 
            // txtMadde
            // 
            txtMadde.Location = new Point(164, 156);
            txtMadde.Name = "txtMadde";
            txtMadde.Size = new Size(125, 27);
            txtMadde.TabIndex = 15;
            // 
            // TarifEkleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(582, 553);
            Controls.Add(txtMadde);
            Controls.Add(btnMaddeEkle);
            Controls.Add(lstTalimatlar);
            Controls.Add(pbGorsel);
            Controls.Add(cmbKategori);
            Controls.Add(btnEkle);
            Controls.Add(txtHazirlamaSuresi);
            Controls.Add(txtTarifAdi);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TarifEkleForm";
            Text = "TarifEkleForm";
            FormClosing += TarifEkleForm_FormClosing;
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
        private Button btnEkle;
        private ComboBox cmbKategori;
        private PictureBox pbGorsel;
        private OpenFileDialog ofdResimSec;
        private ListBox lstTalimatlar;
        private Button btnMaddeEkle;
        private TextBox txtMadde;
    }
}
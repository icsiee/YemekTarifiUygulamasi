namespace YemekTarifiUygulamasi
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
            cmbMalzeme.Location = new Point(433, 118);
            cmbMalzeme.Name = "cmbMalzeme";
            cmbMalzeme.Size = new Size(166, 28);
            cmbMalzeme.TabIndex = 0;
            // 
            // txtMalzemeMiktar
            // 
            txtMalzemeMiktar.Location = new Point(433, 175);
            txtMalzemeMiktar.Name = "txtMalzemeMiktar";
            txtMalzemeMiktar.Size = new Size(166, 27);
            txtMalzemeMiktar.TabIndex = 1;
            // 
            // btnEkleMalzeme
            // 
            btnEkleMalzeme.BackColor = Color.Red;
            btnEkleMalzeme.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnEkleMalzeme.Location = new Point(424, 235);
            btnEkleMalzeme.Name = "btnEkleMalzeme";
            btnEkleMalzeme.Size = new Size(234, 49);
            btnEkleMalzeme.TabIndex = 2;
            btnEkleMalzeme.Text = " Ekle";
            btnEkleMalzeme.UseVisualStyleBackColor = false;
            btnEkleMalzeme.Click += btnEkleMalzeme_Click_1;
            // 
            // btnKaydet
            // 
            btnKaydet.BackColor = Color.Chartreuse;
            btnKaydet.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnKaydet.Location = new Point(188, 285);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(154, 49);
            btnKaydet.TabIndex = 3;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = false;
            btnKaydet.Click += btnKaydet_Click_1;
            // 
            // dataGridViewMalzemeler
            // 
            dataGridViewMalzemeler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMalzemeler.Location = new Point(124, 357);
            dataGridViewMalzemeler.Name = "dataGridViewMalzemeler";
            dataGridViewMalzemeler.RowHeadersWidth = 51;
            dataGridViewMalzemeler.Size = new Size(436, 188);
            dataGridViewMalzemeler.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.PeachPuff;
            label1.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(238, 118);
            label1.Name = "label1";
            label1.Size = new Size(147, 29);
            label1.TabIndex = 5;
            label1.Text = "Malzemeler:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.PeachPuff;
            label2.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(238, 175);
            label2.Name = "label2";
            label2.Size = new Size(94, 29);
            label2.TabIndex = 6;
            label2.Text = "Miktar:";
            // 
            // btnYeniMalzemeEkle
            // 
            btnYeniMalzemeEkle.BackColor = Color.Red;
            btnYeniMalzemeEkle.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnYeniMalzemeEkle.Location = new Point(424, 295);
            btnYeniMalzemeEkle.Name = "btnYeniMalzemeEkle";
            btnYeniMalzemeEkle.Size = new Size(234, 39);
            btnYeniMalzemeEkle.TabIndex = 7;
            btnYeniMalzemeEkle.Text = "Yeni Malzeme Ekle";
            btnYeniMalzemeEkle.UseVisualStyleBackColor = false;
            btnYeniMalzemeEkle.Click += btnYeniMalzemeEkle_Click;
            // 
            // TarifMalzemeIliskisiForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.af32c285_45df_4497_995a_c54cc1976a93;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(782, 753);
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
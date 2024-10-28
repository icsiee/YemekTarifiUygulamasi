namespace YemekTarifiUygulamasi
{
    partial class TarifDetayForm
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
            lblTarifAdi = new Label();
            pictureBoxTarif = new PictureBox();
            txtTalimatlar = new TextBox();
            button1 = new Button();
            dataGridViewMalzemeler = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTarif).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMalzemeler).BeginInit();
            SuspendLayout();
            // 
            // lblTarifAdi
            // 
            lblTarifAdi.AutoSize = true;
            lblTarifAdi.Location = new Point(324, 85);
            lblTarifAdi.Name = "lblTarifAdi";
            lblTarifAdi.Size = new Size(50, 20);
            lblTarifAdi.TabIndex = 0;
            lblTarifAdi.Text = "label1";
            // 
            // pictureBoxTarif
            // 
            pictureBoxTarif.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBoxTarif.Location = new Point(168, 120);
            pictureBoxTarif.Name = "pictureBoxTarif";
            pictureBoxTarif.Size = new Size(173, 166);
            pictureBoxTarif.TabIndex = 1;
            pictureBoxTarif.TabStop = false;
            // 
            // txtTalimatlar
            // 
            txtTalimatlar.Location = new Point(347, 120);
            txtTalimatlar.Multiline = true;
            txtTalimatlar.Name = "txtTalimatlar";
            txtTalimatlar.Size = new Size(218, 166);
            txtTalimatlar.TabIndex = 2;
            txtTalimatlar.TextChanged += txtTalimatlar_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(306, 466);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 3;
            button1.Text = "KAYDET";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridViewMalzemeler
            // 
            dataGridViewMalzemeler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMalzemeler.Location = new Point(168, 292);
            dataGridViewMalzemeler.Name = "dataGridViewMalzemeler";
            dataGridViewMalzemeler.RowHeadersWidth = 51;
            dataGridViewMalzemeler.Size = new Size(336, 168);
            dataGridViewMalzemeler.TabIndex = 4;
            dataGridViewMalzemeler.CellContentClick += dataGridViewMalzemeler_CellContentClick;
            // 
            // TarifDetayForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.af32c285_45df_4497_995a_c54cc1976a93;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(710, 621);
            Controls.Add(dataGridViewMalzemeler);
            Controls.Add(button1);
            Controls.Add(txtTalimatlar);
            Controls.Add(pictureBoxTarif);
            Controls.Add(lblTarifAdi);
            Name = "TarifDetayForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TarifDetayForm";
            ((System.ComponentModel.ISupportInitialize)pictureBoxTarif).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMalzemeler).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTarifAdi;
        private PictureBox pictureBoxTarif;
        private TextBox txtTalimatlar;
        private Button button1;
        private DataGridView dataGridViewMalzemeler;
    }
}
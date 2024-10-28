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
            lblTarifAdi.Location = new Point(61, 68);
            lblTarifAdi.Name = "lblTarifAdi";
            lblTarifAdi.Size = new Size(50, 20);
            lblTarifAdi.TabIndex = 0;
            lblTarifAdi.Text = "label1";
            // 
            // pictureBoxTarif
            // 
            pictureBoxTarif.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBoxTarif.Location = new Point(526, 27);
            pictureBoxTarif.Name = "pictureBoxTarif";
            pictureBoxTarif.Size = new Size(174, 135);
            pictureBoxTarif.TabIndex = 1;
            pictureBoxTarif.TabStop = false;
            // 
            // txtTalimatlar
            // 
            txtTalimatlar.Location = new Point(61, 121);
            txtTalimatlar.Multiline = true;
            txtTalimatlar.Name = "txtTalimatlar";
            txtTalimatlar.Size = new Size(238, 207);
            txtTalimatlar.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(61, 381);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 3;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridViewMalzemeler
            // 
            dataGridViewMalzemeler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMalzemeler.Location = new Point(405, 231);
            dataGridViewMalzemeler.Name = "dataGridViewMalzemeler";
            dataGridViewMalzemeler.RowHeadersWidth = 51;
            dataGridViewMalzemeler.Size = new Size(300, 188);
            dataGridViewMalzemeler.TabIndex = 4;
            dataGridViewMalzemeler.CellContentClick += dataGridViewMalzemeler_CellContentClick;
            // 
            // TarifDetayForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewMalzemeler);
            Controls.Add(button1);
            Controls.Add(txtTalimatlar);
            Controls.Add(pictureBoxTarif);
            Controls.Add(lblTarifAdi);
            Name = "TarifDetayForm";
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
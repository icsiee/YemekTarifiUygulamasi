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
            ((System.ComponentModel.ISupportInitialize)pictureBoxTarif).BeginInit();
            SuspendLayout();
            // 
            // lblTarifAdi
            // 
            lblTarifAdi.AutoSize = true;
            lblTarifAdi.Location = new Point(67, 72);
            lblTarifAdi.Name = "lblTarifAdi";
            lblTarifAdi.Size = new Size(50, 20);
            lblTarifAdi.TabIndex = 0;
            lblTarifAdi.Text = "label1";
            // 
            // pictureBoxTarif
            // 
            pictureBoxTarif.Location = new Point(493, 12);
            pictureBoxTarif.Name = "pictureBoxTarif";
            pictureBoxTarif.Size = new Size(275, 238);
            pictureBoxTarif.TabIndex = 1;
            pictureBoxTarif.TabStop = false;
            // 
            // txtTalimatlar
            // 
            txtTalimatlar.Location = new Point(61, 121);
            txtTalimatlar.Multiline = true;
            txtTalimatlar.Name = "txtTalimatlar";
            txtTalimatlar.Size = new Size(125, 34);
            txtTalimatlar.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(67, 266);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 3;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // TarifDetayForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(txtTalimatlar);
            Controls.Add(pictureBoxTarif);
            Controls.Add(lblTarifAdi);
            Name = "TarifDetayForm";
            Text = "TarifDetayForm";
            FormClosing += TarifDetayForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pictureBoxTarif).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTarifAdi;
        private PictureBox pictureBoxTarif;
        private TextBox txtTalimatlar;
        private Button button1;
    }
}
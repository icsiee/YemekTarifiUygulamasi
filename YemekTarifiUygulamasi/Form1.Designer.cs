namespace YemekTarifiUygulamasi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flowLayoutPanelTarifler = new FlowLayoutPanel();
            btnMalzemeEkle = new Button();
            btnTarifEkle = new Button();
            flowLayoutPanelTarifler.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanelTarifler
            // 
            flowLayoutPanelTarifler.Controls.Add(btnMalzemeEkle);
            flowLayoutPanelTarifler.Controls.Add(btnTarifEkle);
            flowLayoutPanelTarifler.Location = new Point(12, 15);
            flowLayoutPanelTarifler.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanelTarifler.Name = "flowLayoutPanelTarifler";
            flowLayoutPanelTarifler.Size = new Size(776, 532);
            flowLayoutPanelTarifler.TabIndex = 0;
            // 
            // btnMalzemeEkle
            // 
            btnMalzemeEkle.Location = new Point(3, 3);
            btnMalzemeEkle.Name = "btnMalzemeEkle";
            btnMalzemeEkle.Size = new Size(94, 29);
            btnMalzemeEkle.TabIndex = 0;
            btnMalzemeEkle.Text = "malzeme ekle";
            btnMalzemeEkle.UseVisualStyleBackColor = true;
            btnMalzemeEkle.Click += btnMalzemeEkle_Click;
            // 
            // btnTarifEkle
            // 
            btnTarifEkle.Location = new Point(103, 3);
            btnTarifEkle.Name = "btnTarifEkle";
            btnTarifEkle.Size = new Size(94, 29);
            btnTarifEkle.TabIndex = 1;
            btnTarifEkle.Text = "tarif ekle";
            btnTarifEkle.UseVisualStyleBackColor = true;
            btnTarifEkle.Click += btnTarifEkle_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 625);
            Controls.Add(flowLayoutPanelTarifler);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Yemek Tarifleri Uygulaması";
            flowLayoutPanelTarifler.ResumeLayout(false);
            ResumeLayout(false);
        }


        #endregion

        private FlowLayoutPanel flowLayoutPanel2;
        private Label labelTitle;
        private Button btnMalzemeEkle;
        private Button btnTarifEkle;
    }
}

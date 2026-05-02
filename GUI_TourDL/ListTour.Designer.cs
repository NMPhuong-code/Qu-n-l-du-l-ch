namespace GUI_TourDL
{
    partial class ListTour
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTenTour = new System.Windows.Forms.Label();
            this.lblGiaTien = new System.Windows.Forms.Label();
            this.lblThoiGian = new System.Windows.Forms.Label();
            this.picTour = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picTour)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTenTour
            // 
            this.lblTenTour.AutoSize = true;
            this.lblTenTour.BackColor = System.Drawing.Color.Transparent;
            this.lblTenTour.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenTour.Location = new System.Drawing.Point(182, 25);
            this.lblTenTour.Name = "lblTenTour";
            this.lblTenTour.Size = new System.Drawing.Size(50, 16);
            this.lblTenTour.TabIndex = 1;
            this.lblTenTour.Text = "label1";
            // 
            // lblGiaTien
            // 
            this.lblGiaTien.AutoSize = true;
            this.lblGiaTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiaTien.ForeColor = System.Drawing.Color.Red;
            this.lblGiaTien.Location = new System.Drawing.Point(182, 53);
            this.lblGiaTien.Name = "lblGiaTien";
            this.lblGiaTien.Size = new System.Drawing.Size(50, 16);
            this.lblGiaTien.TabIndex = 2;
            this.lblGiaTien.Text = "label2";
            // 
            // lblThoiGian
            // 
            this.lblThoiGian.AutoSize = true;
            this.lblThoiGian.Location = new System.Drawing.Point(182, 84);
            this.lblThoiGian.Name = "lblThoiGian";
            this.lblThoiGian.Size = new System.Drawing.Size(44, 16);
            this.lblThoiGian.TabIndex = 3;
            this.lblThoiGian.Text = "label3";
            // 
            // picTour
            // 
            this.picTour.Location = new System.Drawing.Point(37, 26);
            this.picTour.Name = "picTour";
            this.picTour.Size = new System.Drawing.Size(123, 75);
            this.picTour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTour.TabIndex = 0;
            this.picTour.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button1.Location = new System.Drawing.Point(279, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 31);
            this.button1.TabIndex = 4;
            this.button1.Text = "Đặt ngay";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // ListTour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblThoiGian);
            this.Controls.Add(this.lblGiaTien);
            this.Controls.Add(this.lblTenTour);
            this.Controls.Add(this.picTour);
            this.Name = "ListTour";
            this.Size = new System.Drawing.Size(413, 170);
            this.Load += new System.EventHandler(this.ListTour_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picTour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picTour;
        private System.Windows.Forms.Label lblTenTour;
        private System.Windows.Forms.Label lblGiaTien;
        private System.Windows.Forms.Label lblThoiGian;
        private System.Windows.Forms.Button button1;
    }
}

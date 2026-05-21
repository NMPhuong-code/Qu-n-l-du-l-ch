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
            this.picTour = new System.Windows.Forms.PictureBox();
            this.btn_datNgay = new System.Windows.Forms.Button();
            this.SoChoCon = new System.Windows.Forms.Label();
            this.lbl_ngayKHanh = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picTour)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTenTour
            // 
            this.lblTenTour.AutoSize = true;
            this.lblTenTour.BackColor = System.Drawing.Color.Transparent;
            this.lblTenTour.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenTour.Location = new System.Drawing.Point(231, 22);
            this.lblTenTour.Name = "lblTenTour";
            this.lblTenTour.Size = new System.Drawing.Size(57, 20);
            this.lblTenTour.TabIndex = 1;
            this.lblTenTour.Text = "label1";
            // 
            // lblGiaTien
            // 
            this.lblGiaTien.AutoSize = true;
            this.lblGiaTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiaTien.ForeColor = System.Drawing.Color.Red;
            this.lblGiaTien.Location = new System.Drawing.Point(234, 50);
            this.lblGiaTien.Name = "lblGiaTien";
            this.lblGiaTien.Size = new System.Drawing.Size(57, 20);
            this.lblGiaTien.TabIndex = 2;
            this.lblGiaTien.Text = "label2";
            // 
            // picTour
            // 
            this.picTour.Location = new System.Drawing.Point(42, 32);
            this.picTour.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picTour.Name = "picTour";
            this.picTour.Size = new System.Drawing.Size(161, 87);
            this.picTour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTour.TabIndex = 0;
            this.picTour.TabStop = false;
            // 
            // btn_datNgay
            // 
            this.btn_datNgay.BackColor = System.Drawing.Color.Red;
            this.btn_datNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_datNgay.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btn_datNgay.Location = new System.Drawing.Point(240, 144);
            this.btn_datNgay.Name = "btn_datNgay";
            this.btn_datNgay.Size = new System.Drawing.Size(151, 43);
            this.btn_datNgay.TabIndex = 4;
            this.btn_datNgay.Text = "Đặt ngay";
            this.btn_datNgay.UseVisualStyleBackColor = false;
            this.btn_datNgay.Click += new System.EventHandler(this.btn_datNgay_Click);
            // 
            // SoChoCon
            // 
            this.SoChoCon.AutoSize = true;
            this.SoChoCon.Location = new System.Drawing.Point(234, 75);
            this.SoChoCon.Name = "SoChoCon";
            this.SoChoCon.Size = new System.Drawing.Size(91, 16);
            this.SoChoCon.TabIndex = 5;
            this.SoChoCon.Text = "Số chỗ còn lại";
            // 
            // lbl_ngayKHanh
            // 
            this.lbl_ngayKHanh.AutoSize = true;
            this.lbl_ngayKHanh.Location = new System.Drawing.Point(237, 97);
            this.lbl_ngayKHanh.Name = "lbl_ngayKHanh";
            this.lbl_ngayKHanh.Size = new System.Drawing.Size(97, 16);
            this.lbl_ngayKHanh.TabIndex = 6;
            this.lbl_ngayKHanh.Text = "ngày khởi hành";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button1.Location = new System.Drawing.Point(409, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 43);
            this.button1.TabIndex = 7;
            this.button1.Text = "Chi tiết tour";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // ListTour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_ngayKHanh);
            this.Controls.Add(this.SoChoCon);
            this.Controls.Add(this.btn_datNgay);
            this.Controls.Add(this.lblGiaTien);
            this.Controls.Add(this.lblTenTour);
            this.Controls.Add(this.picTour);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ListTour";
            this.Size = new System.Drawing.Size(628, 275);
            this.Load += new System.EventHandler(this.ListTour_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picTour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picTour;
        private System.Windows.Forms.Label lblTenTour;
        private System.Windows.Forms.Label lblGiaTien;
        private System.Windows.Forms.Button btn_datNgay;
        private System.Windows.Forms.Label SoChoCon;
        private System.Windows.Forms.Label lbl_ngayKHanh;
        private System.Windows.Forms.Button button1;
    }
}

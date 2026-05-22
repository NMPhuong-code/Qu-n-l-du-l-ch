namespace GUI_TourDL
{
    partial class Form_HuyTour
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
            this.lblThongTin = new System.Windows.Forms.Label();
            this.txtLyDoHuy = new System.Windows.Forms.TextBox();
            this.btnGuiYeuCau = new System.Windows.Forms.Button();
            this.txtMaDonDatTour = new System.Windows.Forms.TextBox();
            this.txtTenTour = new System.Windows.Forms.TextBox();
            this.dtpNgayKhoiHanh = new System.Windows.Forms.DateTimePicker();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            this.btnTraCuuTrangThai = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpNgayYeuCau = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lblThongTin
            // 
            this.lblThongTin.AutoSize = true;
            this.lblThongTin.Location = new System.Drawing.Point(14, 325);
            this.lblThongTin.Name = "lblThongTin";
            this.lblThongTin.Size = new System.Drawing.Size(107, 20);
            this.lblThongTin.TabIndex = 0;
            this.lblThongTin.Text = "Lý do hủy đơn";
            // 
            // txtLyDoHuy
            // 
            this.txtLyDoHuy.Location = new System.Drawing.Point(159, 280);
            this.txtLyDoHuy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLyDoHuy.Multiline = true;
            this.txtLyDoHuy.Name = "txtLyDoHuy";
            this.txtLyDoHuy.Size = new System.Drawing.Size(412, 88);
            this.txtLyDoHuy.TabIndex = 1;
            // 
            // btnGuiYeuCau
            // 
            this.btnGuiYeuCau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGuiYeuCau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuiYeuCau.ForeColor = System.Drawing.Color.White;
            this.btnGuiYeuCau.Location = new System.Drawing.Point(159, 424);
            this.btnGuiYeuCau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGuiYeuCau.Name = "btnGuiYeuCau";
            this.btnGuiYeuCau.Size = new System.Drawing.Size(169, 44);
            this.btnGuiYeuCau.TabIndex = 2;
            this.btnGuiYeuCau.Text = "Gởi yêu cầu";
            this.btnGuiYeuCau.UseVisualStyleBackColor = false;
            this.btnGuiYeuCau.Click += new System.EventHandler(this.btnGuiYeuCau_Click);
            // 
            // txtMaDonDatTour
            // 
            this.txtMaDonDatTour.Location = new System.Drawing.Point(159, 99);
            this.txtMaDonDatTour.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaDonDatTour.Name = "txtMaDonDatTour";
            this.txtMaDonDatTour.Size = new System.Drawing.Size(112, 26);
            this.txtMaDonDatTour.TabIndex = 3;
            // 
            // txtTenTour
            // 
            this.txtTenTour.Location = new System.Drawing.Point(159, 154);
            this.txtTenTour.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenTour.Name = "txtTenTour";
            this.txtTenTour.Size = new System.Drawing.Size(112, 26);
            this.txtTenTour.TabIndex = 4;
            // 
            // dtpNgayKhoiHanh
            // 
            this.dtpNgayKhoiHanh.Enabled = false;
            this.dtpNgayKhoiHanh.Location = new System.Drawing.Point(159, 199);
            this.dtpNgayKhoiHanh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpNgayKhoiHanh.Name = "dtpNgayKhoiHanh";
            this.dtpNgayKhoiHanh.Size = new System.Drawing.Size(224, 26);
            this.dtpNgayKhoiHanh.TabIndex = 5;
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.Location = new System.Drawing.Point(159, 376);
            this.txtTrangThai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.Size = new System.Drawing.Size(112, 26);
            this.txtTrangThai.TabIndex = 7;
            // 
            // btnTraCuuTrangThai
            // 
            this.btnTraCuuTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraCuuTrangThai.Location = new System.Drawing.Point(363, 424);
            this.btnTraCuuTrangThai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTraCuuTrangThai.Name = "btnTraCuuTrangThai";
            this.btnTraCuuTrangThai.Size = new System.Drawing.Size(177, 44);
            this.btnTraCuuTrangThai.TabIndex = 8;
            this.btnTraCuuTrangThai.Text = "Tra cứu trạng thái";
            this.btnTraCuuTrangThai.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ngày gởi yêu cầu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Ngày khởi hành";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tên tour";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Mã đặt tour";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 376);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Trạng thái";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(227, 32);
            this.label6.TabIndex = 15;
            this.label6.Text = "Yêu cầu hủy tour";
            // 
            // dtpNgayYeuCau
            // 
            this.dtpNgayYeuCau.Enabled = false;
            this.dtpNgayYeuCau.Location = new System.Drawing.Point(159, 245);
            this.dtpNgayYeuCau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpNgayYeuCau.Name = "dtpNgayYeuCau";
            this.dtpNgayYeuCau.Size = new System.Drawing.Size(224, 26);
            this.dtpNgayYeuCau.TabIndex = 16;
            // 
            // Form_HuyTour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 501);
            this.Controls.Add(this.dtpNgayYeuCau);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTraCuuTrangThai);
            this.Controls.Add(this.txtTrangThai);
            this.Controls.Add(this.dtpNgayKhoiHanh);
            this.Controls.Add(this.txtTenTour);
            this.Controls.Add(this.txtMaDonDatTour);
            this.Controls.Add(this.btnGuiYeuCau);
            this.Controls.Add(this.txtLyDoHuy);
            this.Controls.Add(this.lblThongTin);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form_HuyTour";
            this.Text = "Form_YeuCauHuyTour";
            this.Load += new System.EventHandler(this.Form_HuyTour_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblThongTin;
        private System.Windows.Forms.TextBox txtLyDoHuy;
        private System.Windows.Forms.Button btnGuiYeuCau;
        private System.Windows.Forms.TextBox txtMaDonDatTour;
        private System.Windows.Forms.TextBox txtTenTour;
        private System.Windows.Forms.DateTimePicker dtpNgayKhoiHanh;
        private System.Windows.Forms.TextBox txtTrangThai;
        private System.Windows.Forms.Button btnTraCuuTrangThai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpNgayYeuCau;
    }
}
namespace GUI_TourDL
{
    partial class Form_HoiVien
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
            this.btnDong = new System.Windows.Forms.Button();
            this.lblTienDoTitle = new System.Windows.Forms.Label();
            this.progressHang = new System.Windows.Forms.ProgressBar();
            this.panelTienDo = new System.Windows.Forms.Panel();
            this.lblTienDo = new System.Windows.Forms.Label();
            this.lblUuDaiTitle = new System.Windows.Forms.Label();
            this.lblUuDai = new System.Windows.Forms.Label();
            this.lblTenLabel = new System.Windows.Forms.Label();
            this.lblTenDangNhap = new System.Windows.Forms.Label();
            this.lblVaiTroLabel = new System.Windows.Forms.Label();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.panelUuDai = new System.Windows.Forms.Panel();
            this.lblTrangThaiLabel = new System.Windows.Forms.Label();
            this.lblSoTourLabel = new System.Windows.Forms.Label();
            this.lblSoTour = new System.Windows.Forms.Label();
            this.lblHangHoiVien = new System.Windows.Forms.Label();
            this.lblHangLabel = new System.Windows.Forms.Label();
            this.panelThongTin = new System.Windows.Forms.Panel();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelNoi = new System.Windows.Forms.Panel();
            this.panelTienDo.SuspendLayout();
            this.panelUuDai.SuspendLayout();
            this.panelThongTin.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelNoi.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.btnDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(175, 415);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(130, 32);
            this.btnDong.TabIndex = 4;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            // 
            // lblTienDoTitle
            // 
            this.lblTienDoTitle.AutoSize = true;
            this.lblTienDoTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTienDoTitle.Location = new System.Drawing.Point(10, 8);
            this.lblTienDoTitle.Name = "lblTienDoTitle";
            this.lblTienDoTitle.Size = new System.Drawing.Size(137, 18);
            this.lblTienDoTitle.TabIndex = 0;
            this.lblTienDoTitle.Text = "Tiến độ lên hạng:";
            // 
            // progressHang
            // 
            this.progressHang.Location = new System.Drawing.Point(10, 28);
            this.progressHang.Name = "progressHang";
            this.progressHang.Size = new System.Drawing.Size(430, 18);
            this.progressHang.TabIndex = 1;
            // 
            // panelTienDo
            // 
            this.panelTienDo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTienDo.Controls.Add(this.lblTienDoTitle);
            this.panelTienDo.Controls.Add(this.progressHang);
            this.panelTienDo.Controls.Add(this.lblTienDo);
            this.panelTienDo.Location = new System.Drawing.Point(15, 330);
            this.panelTienDo.Name = "panelTienDo";
            this.panelTienDo.Size = new System.Drawing.Size(450, 75);
            this.panelTienDo.TabIndex = 3;
            // 
            // lblTienDo
            // 
            this.lblTienDo.AutoSize = true;
            this.lblTienDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblTienDo.ForeColor = System.Drawing.Color.Gray;
            this.lblTienDo.Location = new System.Drawing.Point(10, 52);
            this.lblTienDo.Name = "lblTienDo";
            this.lblTienDo.Size = new System.Drawing.Size(23, 17);
            this.lblTienDo.TabIndex = 2;
            this.lblTienDo.Text = "---";
            // 
            // lblUuDaiTitle
            // 
            this.lblUuDaiTitle.AutoSize = true;
            this.lblUuDaiTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblUuDaiTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.lblUuDaiTitle.Location = new System.Drawing.Point(10, 10);
            this.lblUuDaiTitle.Name = "lblUuDaiTitle";
            this.lblUuDaiTitle.Size = new System.Drawing.Size(188, 20);
            this.lblUuDaiTitle.TabIndex = 0;
            this.lblUuDaiTitle.Text = "🎁 Quyền lợi hội viên:";
            // 
            // lblUuDai
            // 
            this.lblUuDai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblUuDai.Location = new System.Drawing.Point(10, 35);
            this.lblUuDai.Name = "lblUuDai";
            this.lblUuDai.Size = new System.Drawing.Size(430, 70);
            this.lblUuDai.TabIndex = 1;
            this.lblUuDai.Text = "---";
            // 
            // lblTenLabel
            // 
            this.lblTenLabel.AutoSize = true;
            this.lblTenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTenLabel.Location = new System.Drawing.Point(10, 12);
            this.lblTenLabel.Name = "lblTenLabel";
            this.lblTenLabel.Size = new System.Drawing.Size(123, 18);
            this.lblTenLabel.TabIndex = 0;
            this.lblTenLabel.Text = "Tên đăng nhập:";
            // 
            // lblTenDangNhap
            // 
            this.lblTenDangNhap.AutoSize = true;
            this.lblTenDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblTenDangNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.lblTenDangNhap.Location = new System.Drawing.Point(180, 12);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Size = new System.Drawing.Size(23, 18);
            this.lblTenDangNhap.TabIndex = 1;
            this.lblTenDangNhap.Text = "---";
            // 
            // lblVaiTroLabel
            // 
            this.lblVaiTroLabel.AutoSize = true;
            this.lblVaiTroLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblVaiTroLabel.Location = new System.Drawing.Point(10, 38);
            this.lblVaiTroLabel.Name = "lblVaiTroLabel";
            this.lblVaiTroLabel.Size = new System.Drawing.Size(62, 18);
            this.lblVaiTroLabel.TabIndex = 2;
            this.lblVaiTroLabel.Text = "Vai trò:";
            // 
            // lblVaiTro
            // 
            this.lblVaiTro.AutoSize = true;
            this.lblVaiTro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblVaiTro.Location = new System.Drawing.Point(180, 38);
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblVaiTro.Size = new System.Drawing.Size(23, 18);
            this.lblVaiTro.TabIndex = 3;
            this.lblVaiTro.Text = "---";
            // 
            // panelUuDai
            // 
            this.panelUuDai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.panelUuDai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUuDai.Controls.Add(this.lblUuDaiTitle);
            this.panelUuDai.Controls.Add(this.lblUuDai);
            this.panelUuDai.Location = new System.Drawing.Point(15, 210);
            this.panelUuDai.Name = "panelUuDai";
            this.panelUuDai.Size = new System.Drawing.Size(450, 110);
            this.panelUuDai.TabIndex = 2;
            // 
            // lblTrangThaiLabel
            // 
            this.lblTrangThaiLabel.AutoSize = true;
            this.lblTrangThaiLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTrangThaiLabel.Location = new System.Drawing.Point(10, 64);
            this.lblTrangThaiLabel.Name = "lblTrangThaiLabel";
            this.lblTrangThaiLabel.Size = new System.Drawing.Size(88, 18);
            this.lblTrangThaiLabel.TabIndex = 4;
            this.lblTrangThaiLabel.Text = "Trạng thái:";
            // 
            // lblSoTourLabel
            // 
            this.lblSoTourLabel.AutoSize = true;
            this.lblSoTourLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblSoTourLabel.Location = new System.Drawing.Point(10, 90);
            this.lblSoTourLabel.Name = "lblSoTourLabel";
            this.lblSoTourLabel.Size = new System.Drawing.Size(120, 18);
            this.lblSoTourLabel.TabIndex = 6;
            this.lblSoTourLabel.Text = "Số tour đã đặt:";
            // 
            // lblSoTour
            // 
            this.lblSoTour.AutoSize = true;
            this.lblSoTour.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblSoTour.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblSoTour.Location = new System.Drawing.Point(180, 90);
            this.lblSoTour.Name = "lblSoTour";
            this.lblSoTour.Size = new System.Drawing.Size(17, 18);
            this.lblSoTour.TabIndex = 7;
            this.lblSoTour.Text = "0";
            // 
            // lblHangHoiVien
            // 
            this.lblHangHoiVien.AutoSize = true;
            this.lblHangHoiVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.lblHangHoiVien.Location = new System.Drawing.Point(15, 35);
            this.lblHangHoiVien.Name = "lblHangHoiVien";
            this.lblHangHoiVien.Size = new System.Drawing.Size(63, 39);
            this.lblHangHoiVien.TabIndex = 11;
            this.lblHangHoiVien.Text = "--- ";
            // 
            // lblHangLabel
            // 
            this.lblHangLabel.AutoSize = true;
            this.lblHangLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblHangLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblHangLabel.Location = new System.Drawing.Point(15, 15);
            this.lblHangLabel.Name = "lblHangLabel";
            this.lblHangLabel.Size = new System.Drawing.Size(130, 20);
            this.lblHangLabel.TabIndex = 10;
            this.lblHangLabel.Text = "Hạng hội viên:";
            // 
            // panelThongTin
            // 
            this.panelThongTin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelThongTin.Controls.Add(this.lblTenLabel);
            this.panelThongTin.Controls.Add(this.lblTenDangNhap);
            this.panelThongTin.Controls.Add(this.lblVaiTroLabel);
            this.panelThongTin.Controls.Add(this.lblVaiTro);
            this.panelThongTin.Controls.Add(this.lblTrangThaiLabel);
            this.panelThongTin.Controls.Add(this.lblTrangThai);
            this.panelThongTin.Controls.Add(this.lblSoTourLabel);
            this.panelThongTin.Controls.Add(this.lblSoTour);
            this.panelThongTin.Location = new System.Drawing.Point(15, 80);
            this.panelThongTin.Name = "panelThongTin";
            this.panelThongTin.Size = new System.Drawing.Size(450, 120);
            this.panelThongTin.TabIndex = 1;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblTrangThai.ForeColor = System.Drawing.Color.Green;
            this.lblTrangThai.Location = new System.Drawing.Point(180, 64);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(23, 18);
            this.lblTrangThai.TabIndex = 5;
            this.lblTrangThai.Text = "---";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(0, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(506, 70);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "🏅 Thông tin Hội Viên";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.panelHeader.Controls.Add(this.lblTieuDe);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(506, 70);
            this.panelHeader.TabIndex = 2;
            // 
            // panelNoi
            // 
            this.panelNoi.Controls.Add(this.lblHangHoiVien);
            this.panelNoi.Controls.Add(this.lblHangLabel);
            this.panelNoi.Controls.Add(this.panelThongTin);
            this.panelNoi.Controls.Add(this.panelUuDai);
            this.panelNoi.Controls.Add(this.panelTienDo);
            this.panelNoi.Controls.Add(this.btnDong);
            this.panelNoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNoi.Location = new System.Drawing.Point(0, 0);
            this.panelNoi.Name = "panelNoi";
            this.panelNoi.Padding = new System.Windows.Forms.Padding(15);
            this.panelNoi.Size = new System.Drawing.Size(506, 504);
            this.panelNoi.TabIndex = 3;
            // 
            // Form_HoiVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 504);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelNoi);
            this.Name = "Form_HoiVien";
            this.Text = "Form_HoiVien";
            this.panelTienDo.ResumeLayout(false);
            this.panelTienDo.PerformLayout();
            this.panelUuDai.ResumeLayout(false);
            this.panelUuDai.PerformLayout();
            this.panelThongTin.ResumeLayout(false);
            this.panelThongTin.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelNoi.ResumeLayout(false);
            this.panelNoi.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Label lblTienDoTitle;
        private System.Windows.Forms.ProgressBar progressHang;
        private System.Windows.Forms.Panel panelTienDo;
        private System.Windows.Forms.Label lblTienDo;
        private System.Windows.Forms.Label lblUuDaiTitle;
        private System.Windows.Forms.Label lblUuDai;
        private System.Windows.Forms.Label lblTenLabel;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.Label lblVaiTroLabel;
        private System.Windows.Forms.Label lblVaiTro;
        private System.Windows.Forms.Panel panelUuDai;
        private System.Windows.Forms.Label lblTrangThaiLabel;
        private System.Windows.Forms.Label lblSoTourLabel;
        private System.Windows.Forms.Label lblSoTour;
        private System.Windows.Forms.Label lblHangHoiVien;
        private System.Windows.Forms.Label lblHangLabel;
        private System.Windows.Forms.Panel panelThongTin;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelNoi;
    }
}
namespace GUI_TourDL
{
    partial class Form_YeuCauGhepTachTour
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
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.grxThongTinDonDat = new System.Windows.Forms.GroupBox();
            this.txtMaDatTourThucTe = new System.Windows.Forms.TextBox();
            this.txtIdDonDatTour = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.grxNoiDungYC = new System.Windows.Forms.GroupBox();
            this.txtSoLuongPhanBo = new System.Windows.Forms.TextBox();
            this.cbHinhThucXuLy = new System.Windows.Forms.ComboBox();
            this.cbLichKhoiHanhThucTe = new System.Windows.Forms.ComboBox();
            this.cbLoaiYeuCau = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnGuiYeuCau = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnKiemTraDon = new System.Windows.Forms.Button();
            this.grxThongTinDonDat.SuspendLayout();
            this.grxNoiDungYC.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.Location = new System.Drawing.Point(20, 15);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(850, 45);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "YÊU CẦU GHÉP / TÁCH TOUR";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grxThongTinDonDat
            // 
            this.grxThongTinDonDat.Controls.Add(this.txtMaDatTourThucTe);
            this.grxThongTinDonDat.Controls.Add(this.txtIdDonDatTour);
            this.grxThongTinDonDat.Controls.Add(this.label2);
            this.grxThongTinDonDat.Controls.Add(this.label1);
            this.grxThongTinDonDat.Location = new System.Drawing.Point(30, 70);
            this.grxThongTinDonDat.Name = "grxThongTinDonDat";
            this.grxThongTinDonDat.Size = new System.Drawing.Size(820, 110);
            this.grxThongTinDonDat.TabIndex = 1;
            this.grxThongTinDonDat.TabStop = false;
            this.grxThongTinDonDat.Text = "Thông tin đơn đặt tour";
            // 
            // txtMaDatTourThucTe
            // 
            this.txtMaDatTourThucTe.Location = new System.Drawing.Point(540, 32);
            this.txtMaDatTourThucTe.Name = "txtMaDatTourThucTe";
            this.txtMaDatTourThucTe.ReadOnly = true;
            this.txtMaDatTourThucTe.Size = new System.Drawing.Size(220, 26);
            this.txtMaDatTourThucTe.TabIndex = 3;
            // 
            // txtIdDonDatTour
            // 
            this.txtIdDonDatTour.Location = new System.Drawing.Point(170, 32);
            this.txtIdDonDatTour.Name = "txtIdDonDatTour";
            this.txtIdDonDatTour.Size = new System.Drawing.Size(220, 26);
            this.txtIdDonDatTour.TabIndex = 2;
            this.txtIdDonDatTour.Leave += new System.EventHandler(this.txtIdDonDatTour_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(430, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã yêu cầu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã đơn đặt tour:";
            // 
            // grxNoiDungYC
            // 
            this.grxNoiDungYC.Controls.Add(this.txtSoLuongPhanBo);
            this.grxNoiDungYC.Controls.Add(this.cbHinhThucXuLy);
            this.grxNoiDungYC.Controls.Add(this.cbLichKhoiHanhThucTe);
            this.grxNoiDungYC.Controls.Add(this.cbLoaiYeuCau);
            this.grxNoiDungYC.Controls.Add(this.label7);
            this.grxNoiDungYC.Controls.Add(this.label6);
            this.grxNoiDungYC.Controls.Add(this.label5);
            this.grxNoiDungYC.Controls.Add(this.label4);
            this.grxNoiDungYC.Controls.Add(this.label3);
            this.grxNoiDungYC.Location = new System.Drawing.Point(30, 195);
            this.grxNoiDungYC.Name = "grxNoiDungYC";
            this.grxNoiDungYC.Size = new System.Drawing.Size(820, 201);
            this.grxNoiDungYC.TabIndex = 2;
            this.grxNoiDungYC.TabStop = false;
            this.grxNoiDungYC.Text = "Nội dung yêu cầu";
            // 
            // txtSoLuongPhanBo
            // 
            this.txtSoLuongPhanBo.Location = new System.Drawing.Point(570, 90);
            this.txtSoLuongPhanBo.Name = "txtSoLuongPhanBo";
            this.txtSoLuongPhanBo.Size = new System.Drawing.Size(220, 26);
            this.txtSoLuongPhanBo.TabIndex = 7;
            // 
            // cbHinhThucXuLy
            // 
            this.cbHinhThucXuLy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHinhThucXuLy.FormattingEnabled = true;
            this.cbHinhThucXuLy.Location = new System.Drawing.Point(570, 37);
            this.cbHinhThucXuLy.Name = "cbHinhThucXuLy";
            this.cbHinhThucXuLy.Size = new System.Drawing.Size(220, 28);
            this.cbHinhThucXuLy.TabIndex = 6;
            this.cbHinhThucXuLy.SelectedIndexChanged += new System.EventHandler(this.cbHinhThucXuLy_SelectedIndexChanged);
            // 
            // cbLichKhoiHanhThucTe
            // 
            this.cbLichKhoiHanhThucTe.FormattingEnabled = true;
            this.cbLichKhoiHanhThucTe.Location = new System.Drawing.Point(170, 87);
            this.cbLichKhoiHanhThucTe.Name = "cbLichKhoiHanhThucTe";
            this.cbLichKhoiHanhThucTe.Size = new System.Drawing.Size(220, 28);
            this.cbLichKhoiHanhThucTe.TabIndex = 5;
            // 
            // cbLoaiYeuCau
            // 
            this.cbLoaiYeuCau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoaiYeuCau.FormattingEnabled = true;
            this.cbLoaiYeuCau.Location = new System.Drawing.Point(170, 37);
            this.cbLoaiYeuCau.Name = "cbLoaiYeuCau";
            this.cbLoaiYeuCau.Size = new System.Drawing.Size(220, 28);
            this.cbLoaiYeuCau.TabIndex = 3;
            this.cbLoaiYeuCau.SelectedIndexChanged += new System.EventHandler(this.cbLoaiYeuCau_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(6, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(486, 60);
            this.label7.TabIndex = 4;
            this.label7.Text = "Lưu ý: Nếu chọn tách đi lẻ hoặc tách đoàn giữa tour, \r\nnhân viên sẽ liên hệ để xá" +
    "c nhận chính sách hoàn tiền/phí phát sinh.\r\n\r\n";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(430, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Số Lượng Người:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Lịch Muốn Chuyển:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(430, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Hình Thức Xử Lý:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Loại yêu cầu:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(30, 413);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(820, 80);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hướng Dẫn";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(25, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(411, 40);
            this.label8.TabIndex = 0;
            this.label8.Text = "Sau khi gửi yêu cầu, nhân viên sẽ kiểm tra lịch khởi hành, \r\nsố lượng chỗ còn lại" +
    " và liên hệ với quý khách để xác nhận.\r\n";
            // 
            // btnGuiYeuCau
            // 
            this.btnGuiYeuCau.BackColor = System.Drawing.Color.Navy;
            this.btnGuiYeuCau.ForeColor = System.Drawing.Color.White;
            this.btnGuiYeuCau.Location = new System.Drawing.Point(302, 512);
            this.btnGuiYeuCau.Name = "btnGuiYeuCau";
            this.btnGuiYeuCau.Size = new System.Drawing.Size(130, 40);
            this.btnGuiYeuCau.TabIndex = 4;
            this.btnGuiYeuCau.Text = "Gửi Yêu Cầu";
            this.btnGuiYeuCau.UseVisualStyleBackColor = false;
            this.btnGuiYeuCau.Click += new System.EventHandler(this.btnGuiYeuCau_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(40, 512);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(134, 40);
            this.btnLamMoi.TabIndex = 5;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnKiemTraDon
            // 
            this.btnKiemTraDon.Location = new System.Drawing.Point(512, 512);
            this.btnKiemTraDon.Name = "btnKiemTraDon";
            this.btnKiemTraDon.Size = new System.Drawing.Size(213, 40);
            this.btnKiemTraDon.TabIndex = 6;
            this.btnKiemTraDon.Text = "Tra Cứu Trạng Thái";
            this.btnKiemTraDon.UseVisualStyleBackColor = true;
            this.btnKiemTraDon.Click += new System.EventHandler(this.btnKiemTraDon_Click);
            // 
            // Form_YeuCauGhepTachTour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 564);
            this.Controls.Add(this.btnKiemTraDon);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnGuiYeuCau);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grxNoiDungYC);
            this.Controls.Add(this.grxThongTinDonDat);
            this.Controls.Add(this.lblTieuDe);
            this.MaximizeBox = false;
            this.Name = "Form_YeuCauGhepTachTour";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yêu cầu ghép / tách tour";
            this.grxThongTinDonDat.ResumeLayout(false);
            this.grxThongTinDonDat.PerformLayout();
            this.grxNoiDungYC.ResumeLayout(false);
            this.grxNoiDungYC.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.GroupBox grxThongTinDonDat;
        private System.Windows.Forms.TextBox txtMaDatTourThucTe;
        private System.Windows.Forms.TextBox txtIdDonDatTour;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox grxNoiDungYC;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSoLuongPhanBo;
        private System.Windows.Forms.ComboBox cbHinhThucXuLy;
        private System.Windows.Forms.ComboBox cbLichKhoiHanhThucTe;
        private System.Windows.Forms.ComboBox cbLoaiYeuCau;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnGuiYeuCau;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnKiemTraDon;
    }
}
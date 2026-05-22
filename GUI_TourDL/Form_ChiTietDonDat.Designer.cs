namespace GUI_TourDL
{
    partial class Form_ChiTietDonDat
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDonHienTai = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTenKhach = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvLichSu = new System.Windows.Forms.DataGridView();
            this.btnYeuCauHuyTour = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHienTai)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 23);
            this.label1.TabIndex = 22;
            // 
            // dgvDonHienTai
            // 
            this.dgvDonHienTai.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDonHienTai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDonHienTai.Location = new System.Drawing.Point(-1, 100);
            this.dgvDonHienTai.Name = "dgvDonHienTai";
            this.dgvDonHienTai.RowHeadersWidth = 51;
            this.dgvDonHienTai.RowTemplate.Height = 24;
            this.dgvDonHienTai.Size = new System.Drawing.Size(737, 113);
            this.dgvDonHienTai.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Controls.Add(this.lblTenKhach);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(-1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(737, 67);
            this.panel1.TabIndex = 24;
            // 
            // lblTenKhach
            // 
            this.lblTenKhach.AutoSize = true;
            this.lblTenKhach.Location = new System.Drawing.Point(382, 31);
            this.lblTenKhach.Name = "lblTenKhach";
            this.lblTenKhach.Size = new System.Drawing.Size(58, 16);
            this.lblTenKhach.TabIndex = 26;
            this.lblTenKhach.Text = "Xin chào";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 31);
            this.label2.TabIndex = 25;
            this.label2.Text = "Lịch sử đặt tour";
            // 
            // dgvLichSu
            // 
            this.dgvLichSu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichSu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichSu.Location = new System.Drawing.Point(-1, 290);
            this.dgvLichSu.Name = "dgvLichSu";
            this.dgvLichSu.RowHeadersWidth = 51;
            this.dgvLichSu.RowTemplate.Height = 24;
            this.dgvLichSu.Size = new System.Drawing.Size(737, 114);
            this.dgvLichSu.TabIndex = 25;
            // 
            // btnYeuCauHuyTour
            // 
            this.btnYeuCauHuyTour.Location = new System.Drawing.Point(629, 219);
            this.btnYeuCauHuyTour.Name = "btnYeuCauHuyTour";
            this.btnYeuCauHuyTour.Size = new System.Drawing.Size(75, 23);
            this.btnYeuCauHuyTour.TabIndex = 26;
            this.btnYeuCauHuyTour.Text = "Hủy tour";
            this.btnYeuCauHuyTour.UseVisualStyleBackColor = true;
            this.btnYeuCauHuyTour.Click += new System.EventHandler(this.btnYeuCauHuyTour_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "Đơn đăt hiện tại";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 271);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "Đơn đã hoàn thành";
            // 
            // Form_ChiTietDonDat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnYeuCauHuyTour);
            this.Controls.Add(this.dgvLichSu);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvDonHienTai);
            this.Controls.Add(this.label1);
            this.Name = "Form_ChiTietDonDat";
            this.Text = "Form_ChiTietDonDat";
            this.Load += new System.EventHandler(this.Form_ChiTietDonDat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHienTai)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDonHienTai;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTenKhach;
        private System.Windows.Forms.DataGridView dgvLichSu;
        private System.Windows.Forms.Button btnYeuCauHuyTour;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
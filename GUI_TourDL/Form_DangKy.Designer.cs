namespace GUI_TourDL
{
    partial class Form_DangKy
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
            this.btn_xacNhanDK = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtCCCD_DK = new System.Windows.Forms.TextBox();
            this.txtCCCD = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblhoTen = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(174, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 42);
            this.label1.TabIndex = 88;
            this.label1.Text = "Đăng ký";
            // 
            // btn_xacNhanDK
            // 
            this.btn_xacNhanDK.BackColor = System.Drawing.Color.Blue;
            this.btn_xacNhanDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xacNhanDK.ForeColor = System.Drawing.Color.White;
            this.btn_xacNhanDK.Location = new System.Drawing.Point(66, 301);
            this.btn_xacNhanDK.Name = "btn_xacNhanDK";
            this.btn_xacNhanDK.Size = new System.Drawing.Size(373, 55);
            this.btn_xacNhanDK.TabIndex = 87;
            this.btn_xacNhanDK.Text = "Xác nhận đăng ký";
            this.btn_xacNhanDK.UseVisualStyleBackColor = false;
            this.btn_xacNhanDK.Click += new System.EventHandler(this.btn_xacNhanDK_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(236, 209);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(203, 22);
            this.txtEmail.TabIndex = 85;
            // 
            // txtCCCD_DK
            // 
            this.txtCCCD_DK.Location = new System.Drawing.Point(236, 172);
            this.txtCCCD_DK.Name = "txtCCCD_DK";
            this.txtCCCD_DK.Size = new System.Drawing.Size(203, 22);
            this.txtCCCD_DK.TabIndex = 84;
            // 
            // txtCCCD
            // 
            this.txtCCCD.AutoSize = true;
            this.txtCCCD.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCCCD.Location = new System.Drawing.Point(64, 172);
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.Size = new System.Drawing.Size(57, 19);
            this.txtCCCD.TabIndex = 83;
            this.txtCCCD.Text = "CCCD";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(62, 209);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(54, 19);
            this.lblEmail.TabIndex = 82;
            this.lblEmail.Text = "Email";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(236, 130);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(203, 22);
            this.txtSDT.TabIndex = 81;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(236, 90);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(203, 22);
            this.txtHoTen.TabIndex = 80;
            // 
            // lblhoTen
            // 
            this.lblhoTen.AutoSize = true;
            this.lblhoTen.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhoTen.Location = new System.Drawing.Point(66, 90);
            this.lblhoTen.Name = "lblhoTen";
            this.lblhoTen.Size = new System.Drawing.Size(78, 19);
            this.lblhoTen.TabIndex = 79;
            this.lblhoTen.Text = "Họ và tên";
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDT.Location = new System.Drawing.Point(64, 130);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(105, 19);
            this.lblSDT.TabIndex = 78;
            this.lblSDT.Text = "Số điện thoại";
            // 
            // Form_DangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_xacNhanDK);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtCCCD_DK);
            this.Controls.Add(this.txtCCCD);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.lblhoTen);
            this.Controls.Add(this.lblSDT);
            this.Name = "Form_DangKy";
            this.Text = "Form_DangKy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_xacNhanDK;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtCCCD_DK;
        private System.Windows.Forms.Label txtCCCD;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblhoTen;
        private System.Windows.Forms.Label lblSDT;
    }
}
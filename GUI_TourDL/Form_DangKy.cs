using BUS_TourDL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_TourDL
{
    public partial class Form_DangKy : Form
    {
        BUS_TaiKhoan busTK = new BUS_TaiKhoan();

        public Form_DangKy()
        {
            InitializeComponent();
        }
        private void btn_xacNhanDK_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string cccd = txtCCCD_DK.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (hoTen == "")
            {
                MessageBox.Show("Vui lòng nhập họ tên!");
                txtHoTen.Focus();
                return;
            }

            if (sdt == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!");
                txtSDT.Focus();
                return;
            }

            if (cccd == "")
            {
                MessageBox.Show("Vui lòng nhập CCCD!");
                txtCCCD_DK.Focus();
                return;
            }

            if (email == "")
            {
                MessageBox.Show("Vui lòng nhập email!");
                txtEmail.Focus();
                return;
            }

            string tenDangNhap = email;

            if (tenDangNhap == "")
            {
                tenDangNhap = sdt;
            }

            string matKhau = cccd;

            if (busTK.kiemTraTrungTenDangNhap(tenDangNhap))
            {
                MessageBox.Show("Email này đã được đăng ký tài khoản!");
                txtEmail.Focus();
                return;
            }

            bool kq = busTK.dangKyKhachHang(
                tenDangNhap,
                matKhau,
                hoTen,
                email,
                sdt,
                cccd
            );

            if (kq)
            {
                MessageBox.Show(
                    "Đăng ký thành công!\n\n" +
                    "Tài khoản đăng nhập: " + tenDangNhap + "\n" +
                    "Mật khẩu: " + matKhau
                );

                Form1 f = new Form1();
                f.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại! Vui lòng kiểm tra lại dữ liệu.");
            }
        }

    }
}

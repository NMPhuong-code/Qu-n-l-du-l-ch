using BUS_TourDL;
using DTO_TourDL;
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
    public partial class Form_DangNhap : Form
    {
        BUS_TaiKhoan busTK = new BUS_TaiKhoan();

        public Form_DangNhap()
        {
            InitializeComponent();

      
        }
        public DTO_TaiKhoan taiKhoanDangNhap;
        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = textBox1.Text.Trim();
            string matKhau = textBox2.Text.Trim();

            if (tenDangNhap == "")
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!");
                textBox1.Focus();
                return;
            }

            if (matKhau == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                textBox2.Focus();
                return;
            }

            DTO_TaiKhoan tk = busTK.dangNhap(tenDangNhap, matKhau);

            // 2. PHẢI KIỂM TRA NULL TRƯỚC (Nếu sai tài khoản/mật khẩu thì dừng lại luôn)
            if (tk == null)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
                return; // Thoát hàm, chặn không cho chạy xuống các lệnh bên dưới
            }

            // 3. ĐĂNG NHẬP THÀNH CÔNG: Chắc chắn tk đã có dữ liệu (không lo bị null nữa)
            MessageBox.Show("Đăng nhập thành công!");
            taiKhoanDangNhap = tk;

            // 4. Kiểm tra vai trò để điều hướng giao diện phù hợp
            if (tk.VaiTro == "KhachHang")
            {
                this.DialogResult = DialogResult.OK;
            }
            else if (tk.VaiTro == "NhanVien" || tk.VaiTro == "Admin")
            {
                // Nhân viên/Admin thì mở form nhân viên
                Form_NhanVien f = new Form_NhanVien();
                f.Show();

                // Ẩn Form chính phía sau nếu có
                if (this.Owner != null)
                {
                    this.Owner.Hide();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Vai trò tài khoản không hợp lệ!");
            }
        }
        private void linkDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form_DangKy f = new Form_DangKy();

            this.Hide();

            f.ShowDialog();

            this.Show();
        }
    }
 }

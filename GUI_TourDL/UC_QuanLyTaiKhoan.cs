using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_TourDL;
using DTO_TourDL;

namespace GUI_TourDL
{
    
    public partial class UC_QuanLyTaiKhoan : UserControl
    {
        BUS_TaiKhoan busTK = new BUS_TaiKhoan();
        BUS_NhomQuyen busNQ = new BUS_NhomQuyen();
        public UC_QuanLyTaiKhoan()
        {
            InitializeComponent();
            cbVaiTro.Items.Add("Admin");
            cbVaiTro.Items.Add("NhanVien");
            cbVaiTro.Items.Add("KhachHang");

            cbTrangThai.Items.Add("Hoạt động");
            cbTrangThai.Items.Add("Đã khóa");

            LoadNhomQuyen();
            LoadTaiKhoan();

        }
        private void LoadNhomQuyen()
        {
            cbNhomQuyen.DataSource = busNQ.getNhomQuyen();
            cbNhomQuyen.DisplayMember = "TenNhomQuyen";
            cbNhomQuyen.ValueMember = "Id";
        }
        private void LoadTaiKhoan()
        {
            dgvTaiKhoan.DataSource = busTK.getTaiKhoan();
            dgvTaiKhoan.Columns["Id_TKhoan"].HeaderText = "Mã Tài Khoản";
            dgvTaiKhoan.Columns["TenDangNhap"].HeaderText =  "Tên đăng nhập";

            dgvTaiKhoan.Columns["MatKhau"].HeaderText = "Mật khẩu";

            dgvTaiKhoan.Columns["VaiTro"].HeaderText = "Vai trò";

            dgvTaiKhoan.Columns["TrangThai"].HeaderText = "Trạng thái";

            dgvTaiKhoan.Columns["IdNhomQuyen"].HeaderText ="Mã nhóm quyền";

            dgvTaiKhoan.Columns["TenNhomQuyen"].HeaderText = "Tên nhóm quyền";
        }
        private void LamMoi()
        {
            txtId.Clear();

            txtTenDangNhap.Clear();

            txtMatKhau.Clear();

            cbVaiTro.SelectedIndex = -1;

            cbTrangThai.SelectedIndex = -1;

            cbNhomQuyen.SelectedIndex = -1;
        }

        private void dgvTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];
                txtId.Text = row.Cells["Id_TKhoan"].Value.ToString();
                txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
                cbVaiTro.Text = row.Cells["VaiTro"].Value.ToString();
                cbTrangThai.Text = row.Cells["TrangThai"].Value.ToString();
                cbNhomQuyen.SelectedValue = row.Cells["IdNhomQuyen"].Value;
            }

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == "" ||
              txtMatKhau.Text == "" ||
              cbVaiTro.Text == "" ||
              cbTrangThai.Text == "")
            {
                MessageBox.Show("Nhập đầy đủ thông tin");

                return;
            }
            DTO_TaiKhoan tk = new DTO_TaiKhoan();
           tk.TenDangNhap = txtTenDangNhap.Text;
           tk.MatKhau = txtMatKhau.Text;
           tk.VaiTro = cbVaiTro.Text;
           tk.TrangThai = cbTrangThai.Text;
           tk.IdNhomQuyen = Convert.ToInt32(cbNhomQuyen.SelectedValue);
            if (busTK.themTaiKhoan(tk))
            {
                MessageBox.Show("Thêm thành công");

                LoadTaiKhoan();

                LamMoi();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Chọn tài khoản cần sửa");

                return;
            }

            DTO_TaiKhoan tk =new DTO_TaiKhoan();
            tk.Id_TKhoan =Convert.ToInt32(txtId.Text);
            tk.TenDangNhap = txtTenDangNhap.Text;
            tk.MatKhau = txtMatKhau.Text;
            tk.VaiTro =cbVaiTro.Text;
            tk.TrangThai =cbTrangThai.Text;
            tk.IdNhomQuyen = Convert.ToInt32( cbNhomQuyen.SelectedValue);
            if (busTK.suaTaiKhoan(tk))
            {
                MessageBox.Show("Sửa thành công");

                LoadTaiKhoan();

                LamMoi();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Chọn tài khoản cần khóa");

                return;
            }

            int id =
                Convert.ToInt32(txtId.Text);

            if (busTK.xoaTaiKhoan(id))
            {
                MessageBox.Show("Khóa thành công");

                LoadTaiKhoan();

                LamMoi();
            }
            else
            {
                MessageBox.Show("Khóa thất bại");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvTaiKhoan.DataSource =busTK.timKiemTaiKhoan(txtTimKiem.Text);
        }
    }
}

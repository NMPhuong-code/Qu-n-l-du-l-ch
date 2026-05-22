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
using DTO_TourDL;

namespace GUI_TourDL
{
    public partial class UC_QuanLyNguoiDung : UserControl
    {
        BUS_NguoiDung busND = new BUS_NguoiDung();

        public UC_QuanLyNguoiDung()
        {
            InitializeComponent();
            LoadKhachHang();

        }
        private void LoadKhachHang()
        {
            dgvNguoiDung.DataSource = busND.getNguoiDung();
        }
        private void LamMoi()
        {
            txtId.Clear();
            txtMaTK.Clear();
            txtHoTen.Clear();
            txtEmail.Clear();
            txtSDT.Clear();
            txtCCCD.Clear();
            txtTimKiem.Clear();

            LoadKhachHang();
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvNguoiDung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row =
                    dgvNguoiDung.Rows[e.RowIndex];

                txtId.Text =
                    row.Cells["Id"].Value.ToString();

                if (row.Cells["IdTaiKhoan"].Value == null ||
                    row.Cells["IdTaiKhoan"].Value == DBNull.Value)
                {
                    txtMaTK.Text = "";
                }
                else
                {
                    txtMaTK.Text =row.Cells["IdTaiKhoan"].Value.ToString();
                }
                txtHoTen.Text = row.Cells["TenKH"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtSDT.Text =row.Cells["SDT"].Value.ToString();
                txtCCCD.Text = row.Cells["CCCD"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text == "" ||
        txtEmail.Text == "" ||
        txtSDT.Text == "" ||
        txtCCCD.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng");
                return;
            }

            DTO_NguoiDung kh = new DTO_NguoiDung();

            if (txtMaTK.Text == "")
                kh.IdTaiKhoan = null;
            else
                kh.IdTaiKhoan = Convert.ToInt32(txtMaTK.Text);

            kh.TenKH = txtHoTen.Text;
            kh.Email = txtEmail.Text;
            kh.SDT = txtSDT.Text;
            kh.CCCD = txtCCCD.Text;
            if (busND.ThemKhachHang(kh))
            {
                MessageBox.Show("Thêm khách hàng thành công");
                LoadKhachHang();
                LamMoi();
            }
            else
            {
                MessageBox.Show("Thêm khách hàng thất bại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa");
                return;
            }

            DTO_NguoiDung kh = new DTO_NguoiDung();

            kh.Id = Convert.ToInt32(txtId.Text);

            if (txtMaTK.Text == "")
                kh.IdTaiKhoan = null;
            else
                kh.IdTaiKhoan = Convert.ToInt32(txtMaTK.Text);

            kh.TenKH = txtHoTen.Text;
            kh.Email = txtEmail.Text;
            kh.SDT = txtSDT.Text;
            kh.CCCD = txtCCCD.Text;

            if (busND.SuaKhachHang(kh))
            {
                MessageBox.Show("Sửa khách hàng thành công");
                LoadKhachHang();
                LamMoi();
            }
            else
            {
                MessageBox.Show("Sửa khách hàng thất bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa");
                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Bạn có chắc muốn xóa khách hàng này không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int id = Convert.ToInt32(txtId.Text);

                if (busND.XoaKhachHang(id))
                {
                    MessageBox.Show("Xóa khách hàng thành công");
                    LoadKhachHang();
                    LamMoi();
                }
                else
                {
                    MessageBox.Show("Xóa khách hàng thất bại");
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string key = txtTimKiem.Text.Trim();

            if (key == "")
            {
                LoadKhachHang();
            }
            else
            {
                dgvNguoiDung.DataSource =
                    busND.TimKiemKhachHang(key);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();

        }
    }
}

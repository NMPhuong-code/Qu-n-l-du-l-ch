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
    public partial class UC_QuanLyTour : UserControl
    {
        BUS_Tour busTour = new BUS_Tour();

        public UC_QuanLyTour()
        {
            InitializeComponent();
            cbTrangThai.Items.Add("1");
            cbTrangThai.Items.Add("0");
            LoadTour();

        }
        private void LoadTour()
        {
            dgvTour.DataSource = busTour.LayTatCa();
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtIdTour.Clear();
            txtTenTour.Clear();
            txtMoTa.Clear();
            txtGiaCoBan.Clear();
            cbTrangThai.SelectedIndex = -1;
        }
        private void LamMoii()
        {
            txtIdTour.Clear();
            txtTenTour.Clear();
            txtMoTa.Clear();
            txtGiaCoBan.Clear();
            cbTrangThai.SelectedIndex = -1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvTour_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTour.Rows[e.RowIndex];
                txtIdTour.Text= row.Cells["Id"].Value.ToString();
                txtTenTour.Text = row.Cells["TenTour"].Value.ToString();
                txtMoTa.Text= row.Cells["MoTa"].Value.ToString();
                txtGiaCoBan.Text = row.Cells["GiaCoBan"].Value.ToString();
                cbTrangThai.Text = row.Cells["TrangThai"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenTour.Text == "" || txtGiaCoBan.Text == "" || cbTrangThai.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tour");
                return;
            }
            Tourmodel  tour = new Tourmodel();
            tour.TenTour=txtTenTour.Text;
            tour.MoTa= txtMoTa.Text;
            tour.GiaCoBan= Convert.ToDecimal(txtGiaCoBan.Text);
            tour.TrangThai =
                Convert.ToBoolean(cbTrangThai.SelectedValue);
            if (busTour.themTour(tour))
            {
                MessageBox.Show("Thêm tour thành công");
                LoadTour();
                LamMoii();
            }
            else
            {
                MessageBox.Show("Thêm tour thất bại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtIdTour.Text == "")
            {
                MessageBox.Show("Vui lòng chọn tour cần sửa");
                return;
            }
            if(txtIdTour.Text == "" || txtGiaCoBan.Text == "" || cbTrangThai.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tour");
                return;
            }
            Tourmodel tour = new Tourmodel();
            tour.Id=Convert.ToInt32(txtIdTour.Text);
            tour.TenTour = txtTenTour.Text;
            tour.MoTa = txtMoTa.Text;
            tour.GiaCoBan= Convert.ToDecimal(txtGiaCoBan.Text);
            tour.TrangThai =
                Convert.ToBoolean(cbTrangThai.SelectedValue); if (busTour.suaTour(tour))
            {
                MessageBox.Show("Sửa tour thành cônng");
                LoadTour();
                LamMoii();
            }
            else
            {
                MessageBox.Show("Sửa tour thất bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(txtIdTour.Text == "")
            {
                MessageBox.Show("Vui lòng chọn tour cần xóa");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa tour này không?","Xác nhận",
                MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                int Id = Convert.ToInt32(txtIdTour.Text);
                if (busTour.xoaTour(Id))
                {
                    MessageBox.Show("Xóa tour thành công");
                    LoadTour();
                    LamMoii();
                }
                else
                {
                    MessageBox.Show("Xóa tour thất bại");
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            //string key = txtTimKiem.Text.Trim();
            //if (key == "")
            //{
            //    LoadTour();
            //}
            //else
            //{
            //    dgvTour.DataSource = busTour.TimKiemQLyTour(key);
            //}
        }
    }
}

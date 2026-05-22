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
    public partial class UC_QuanLyLichKhoiHanh : UserControl
    {
        BUS_LichKhoiHanh busLich = new BUS_LichKhoiHanh();
        BUS_Tour busTour = new BUS_Tour();
        public UC_QuanLyLichKhoiHanh()
        {
            InitializeComponent();
            cbTrangThai.Items.Add("DangMo");
            cbTrangThai.Items.Add("SapKhoiHanh");
            cbTrangThai.Items.Add("DaDay");
            cbTrangThai.Items.Add("DaHuy");

            cbLoaiNgay.Items.Add("NgayThuong");
            cbLoaiNgay.Items.Add("CuoiTuan");
            cbLoaiNgay.Items.Add("NgayLe");

            LoadComboTour();
            LoadLich();
        }
        private void LoadComboTour()
        {
            cbTour.DataSource = busTour.LayTatCa();
            cbTour.DisplayMember = "TenTour";
            cbTour.ValueMember = "Id";
        }
        public void LamMoi()
        {
            txtId.Clear();
            txtSoChoToiThieu.Clear();
            txtSoChoToiDa.Clear();
            txtGiaThucTe.Clear();
            cbTour.SelectedIndex = 0;
            cbTrangThai.SelectedIndex = 0;
            cbLoaiNgay.SelectedIndex = 0;
            dtpNgayKhoiHanh.Value = DateTime.Now;
            dtpNgayKetThuc.Value = DateTime.Now;
        }
        private void LoadLich()
        {
            dgvLichKhoiHanh.DataSource = busLich.getLichKhoiHanh();
            dgvLichKhoiHanh.Columns["IdTour"].Visible = false;
            dgvLichKhoiHanh.Columns["TenTour"].HeaderText = "Tên Tour";
            dgvLichKhoiHanh.Columns["NgayKhoiHanh"].HeaderText = "Ngày Khởi Hành";
            dgvLichKhoiHanh.Columns["NgayKetThuc"].HeaderText = "Ngày Kết Thúc";
            dgvLichKhoiHanh.Columns["SoChoToiThieu"].HeaderText = "Số Chỗ Tối Thiểu";
            dgvLichKhoiHanh.Columns["SoChoToiDa"].HeaderText = "Số Chỗ Tối Đa";
            dgvLichKhoiHanh.Columns["GiaThucTe"].HeaderText = "Giá Thực Tế";
            dgvLichKhoiHanh.Columns["TrangThai"].HeaderText = "Trạng Thái";
            dgvLichKhoiHanh.Columns["LoaiNgay"].HeaderText = "Loại Ngày";

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void UC_QuanLyLichKhoiHanh_Load(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtSoChoToiThieu.Text==""||txtSoChoToiDa.Text==""||
               txtGiaThucTe.Text == "" || cbTrangThai.Text == "" || cbLoaiNgay.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            if(dtpNgayKetThuc.Value <= dtpNgayKhoiHanh.Value)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn ngày khởi hành");
                return;
            }
            DTO_LichKhoiHanh lich = new DTO_LichKhoiHanh();
            lich.IdTour = Convert.ToInt32(cbTour.SelectedValue);
            lich.NgayKhoiHanh = dtpNgayKhoiHanh.Value;
            lich.NgayKetThuc = dtpNgayKetThuc.Value;
            lich.SoChoToiThieu = Convert.ToInt32(txtSoChoToiThieu.Text);
            lich.SoChoToiDa = Convert.ToInt32(txtSoChoToiDa.Text);
            lich.GiaThucTe = Convert.ToDecimal(txtGiaThucTe.Text);
            lich.TrangThai = cbTrangThai.Text;
            lich.LoaiNgay = cbLoaiNgay.Text;
            if (busLich.themLichKhoiHanh(lich))
            {
                MessageBox.Show("Thêm lịch thành công");
                LoadLich();
                LamMoi();
            }
            else
            {
                MessageBox.Show("Thêm lịch thất bại");
            }
        }

        private void dgvLichKhoiHanh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLichKhoiHanh.Rows[e.RowIndex];
                txtId.Text= row.Cells["Id"].Value.ToString();
                cbTour.SelectedValue = Convert.ToInt32(row.Cells["IdTour"].Value);
                dtpNgayKhoiHanh.Value = Convert.ToDateTime(row.Cells["NgayKhoiHanh"].Value);
                dtpNgayKetThuc.Value = Convert.ToDateTime(row.Cells["NgayKetThuc"].Value);
                txtSoChoToiThieu.Text = row.Cells["SoChoToiThieu"].Value.ToString();
                txtSoChoToiDa.Text = row.Cells["SoChoToiDa"].Value.ToString();
                txtGiaThucTe.Text = row.Cells["GiaThucTe"].Value.ToString();
                cbTrangThai.Text = row.Cells["TrangThai"].Value.ToString();
                cbLoaiNgay.Text = row.Cells["LoaiNgay"].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Vui lòng chọn lịch cần sửa");
                return;
            }
            if (dtpNgayKetThuc.Value <= dtpNgayKhoiHanh.Value)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn ngày khởi hành");
                return;
            }
            DTO_LichKhoiHanh lich = new DTO_LichKhoiHanh();
            lich.Id=Convert.ToInt32(txtId.Text);
            lich.NgayKhoiHanh = dtpNgayKhoiHanh.Value;
            lich.NgayKetThuc = dtpNgayKetThuc.Value;
            lich.SoChoToiThieu=Convert.ToInt32(txtSoChoToiThieu.Text);
            lich.SoChoToiDa = Convert.ToInt32(txtSoChoToiDa.Text);
            lich.GiaThucTe =Convert.ToDecimal(txtGiaThucTe.Text);
            lich.LoaiNgay = cbLoaiNgay.Text;

            if (busLich.suaLichKhoiHanh(lich))
            {
                MessageBox.Show("Sửa lịch thành công");
                LoadLich();
                LamMoi();
            }
            else
            {
                MessageBox.Show("Sửa lịch thất bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);

            if (busLich.xoaLichKhoiHanh(id))
            {
                MessageBox.Show("Đã hủy lịch khởi hành");

                LoadLich();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string key = txtTimKiem.Text.Trim();
            if(key == "")
            {
                LoadLich() ;
            }
            else
            {
                dgvLichKhoiHanh.DataSource= busLich.TimKiemLich(key);
            }
        }
    }
}

using BUS_TourDL;
using DTO_TourDL;
using System;
using System.Data;
using System.Windows.Forms;

namespace GUI_TourDL
{
    public partial class Form_HuyTour : Form
    {
        private int idDonHang;
        private BUS_HuyTour busHT = new BUS_HuyTour();

        public Form_HuyTour()
        {
            InitializeComponent();

            dtpNgayYeuCau.Value = DateTime.Now;
            txtTrangThai.Text = "ChuaHoan";
            txtTrangThai.ReadOnly = true;
            txtTenTour.ReadOnly = true;
            dtpNgayKhoiHanh.Enabled = false;
            dtpNgayYeuCau.Enabled = false;
        }

        public Form_HuyTour(int idDon)
        {
            InitializeComponent();

            idDonHang = idDon;

            dtpNgayYeuCau.Value = DateTime.Now;
            txtTrangThai.Text = "ChuaHoan";
            txtTrangThai.ReadOnly = true;
            txtTenTour.ReadOnly = true;
            dtpNgayKhoiHanh.Enabled = false;
            dtpNgayYeuCau.Enabled = false;
        }
        private void LoadThongTinDonTheoMa(string maDon)
        {
            if (string.IsNullOrWhiteSpace(maDon))
                return;

            DataTable dt = busHT.GetThongTinDonDatTourTheoMa(maDon);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy thông tin đơn đặt tour.");
                return;
            }

            DataRow row = dt.Rows[0];

            txtMaDonDatTour.Text = row["MaDatTourBanDau"].ToString();
            txtTenTour.Text = row["TenTour"].ToString();
            dtpNgayKhoiHanh.Value = Convert.ToDateTime(row["NgayKhoiHanh"]);

            txtTrangThai.Text = "ChuaHoan";
        }

        private void Form_HuyTour_Load(object sender, EventArgs e)
        {
            lblThongTin.Text = "Lý do hủy đơn";

            if (idDonHang > 0)
            {
                txtMaDonDatTour.Text = idDonHang.ToString();
            }
        }

        private void btnGuiYeuCau_Click(object sender, EventArgs e)
        {
            string lyDo = txtLyDoHuy.Text.Trim();

            if (string.IsNullOrEmpty(lyDo))
            {
                MessageBox.Show("Vui lòng nhập lý do hủy tour.");
                return;
            }

            int idDonDatTour = 0;

            if (idDonHang > 0)
            {
                idDonDatTour = idDonHang;
            }
            else
            {
                if (txtMaDonDatTour.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập mã đơn đặt tour.");
                    return;
                }

                idDonDatTour = busHT.GetIdDonDatTourTheoMa(txtMaDonDatTour.Text.Trim());
            }

            if (idDonDatTour == 0)
            {
                MessageBox.Show("Mã đơn đặt tour không hợp lệ hoặc không tồn tại.");
                return;
            }

            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn gửi yêu cầu hủy tour này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr == DialogResult.No)
            {
                return;
            }

            DTO_HuyTour ht = new DTO_HuyTour
            {
                IdDonDatTour = idDonDatTour,
                LyDo = lyDo,
                NgayHuy = DateTime.Now,
                SoTienHoan = 0,
                TrangThaiHoanTien = "ChuaHoan"
            };

            try
            {
                if (busHT.ThemHuyTour(ht))
                {
                    MessageBox.Show("Gửi yêu cầu hủy tour thành công. Vui lòng chờ nhân viên xử lý.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Gửi yêu cầu thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi yêu cầu hủy tour:\n" + ex.Message);
            }
        }
    }
}
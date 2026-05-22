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
    public partial class UC_XuLyTour : UserControl
    {
        BUS_HuyTour busHT = new BUS_HuyTour();
        BUS_PhanBoDatTour busPB = new BUS_PhanBoDatTour();
        public UC_XuLyTour()
        {
            InitializeComponent();
       

            LoadCombo();
            LoadPhanBo();

            LoadComboHuyHoan();
            LoadHuyHoanTour();
        }
        private void LoadCombo()
        {
            cbKieuXuLy.Items.Clear();

            cbKieuXuLy.Items.Add("Ghep_KH");
            cbKieuXuLy.Items.Add("Ghep_NV");
            cbKieuXuLy.Items.Add("Ghep");
            cbKieuXuLy.Items.Add("Tach");
            cbKieuXuLy.Items.Add("BinhThuong");

            cbTrangThai.Items.Clear();

            cbTrangThai.Items.Add("ChoXuLy");
            cbTrangThai.Items.Add("DaPhanBo");
            cbTrangThai.Items.Add("DaHuy");

            cbKieuXuLy.SelectedIndex = 0;
            cbTrangThai.SelectedIndex = 0;
        }
        private void LoadPhanBo()
        {
            dgvPhanBo.DataSource = busPB.GetPhanBoDangXuLy();
            dgvPhanBo.Columns["Id"].HeaderText = "Mã phân bổ";
            dgvPhanBo.Columns["MaDatTourThucTe"].HeaderText = "Mã yêu cầu";
            dgvPhanBo.Columns["IdDonDatTour"].HeaderText = "Mã đơn";
            dgvPhanBo.Columns["IdLichKhoiHanhThucTe"].HeaderText = "Mã lịch thực tế";
            dgvPhanBo.Columns["SoLuongPhanBo"].HeaderText = "Số lượng";
            dgvPhanBo.Columns["KieuXuLy"].HeaderText = "Kiểu xử lý";
            dgvPhanBo.Columns["TrangThai"].HeaderText = "Trạng thái";
        }
        private void LamMoi()
        {
            txtId.Clear();
            txtMaDatTourThucTe.Clear();
            txtIdDonDatTour.Clear();
            txtIdLichKhoiHanhThucTe.Clear();
            txtSoLuongPhanBo.Clear();

            cbKieuXuLy.SelectedIndex = 0;
            cbTrangThai.SelectedIndex = 0;

            LoadPhanBo();
        }
        private void LoadComboHuyHoan()
        {
            cbLoaiXuLyHoan.Items.Clear();
            cbLoaiXuLyHoan.Items.Add("HuyTour");
            cbLoaiXuLyHoan.Items.Add("TachSangLichKhac");
            cbLoaiXuLyHoan.Items.Add("TachDiLeTruocNgayKhoiHanh");
            cbLoaiXuLyHoan.Items.Add("TachDoanGiuaTour");
            cbLoaiXuLyHoan.SelectedIndex = 0;

            cbLoaiNgay.Items.Clear();
            cbLoaiNgay.Items.Add("NgayThuong");
            cbLoaiNgay.Items.Add("LeTet");
            cbLoaiNgay.SelectedIndex = 0;

            cbTrangThaiHoanTien.Items.Clear();
            cbTrangThaiHoanTien.Items.Add("ChuaHoan");
            cbTrangThaiHoanTien.Items.Add("DaHoan");
            cbTrangThaiHoanTien.Items.Add("KhongHoan");
            cbTrangThaiHoanTien.SelectedIndex = 0;
        }
        private void LoadHuyHoanTour()
        {
            dgvHuyHoanTour.DataSource = busHT.GetHuyTourChoXuLy();

            DoiTenCotHuyHoan();
        }

        private void DoiTenCotHuyHoan()
        {
            if (dgvHuyHoanTour.Columns.Count > 0)
            {
                dgvHuyHoanTour.Columns["Id"].HeaderText = "Mã hủy";
                dgvHuyHoanTour.Columns["IdDonDatTour"].HeaderText = "Mã đơn số";
                dgvHuyHoanTour.Columns["MaDatTourBanDau"].HeaderText = "Mã đơn đặt tour";
                dgvHuyHoanTour.Columns["LyDo"].HeaderText = "Lý do";
                dgvHuyHoanTour.Columns["NgayHuy"].HeaderText = "Ngày hủy";
                dgvHuyHoanTour.Columns["SoTienHoan"].HeaderText = "Số tiền hoàn";
                dgvHuyHoanTour.Columns["TrangThaiHoanTien"].HeaderText = "Trạng thái hoàn tiền";
            }
        }
        private void dgvPhanBo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private DTO_PhanBoDatTour LayThongTinTuForm()
        {
            DTO_PhanBoDatTour pb = new DTO_PhanBoDatTour();
            pb.Id = Convert.ToInt32(txtId.Text);
            pb.MaDatTourThucTe = txtMaDatTourThucTe.Text;
            pb.IdDonDatTour =Convert.ToInt32(txtIdDonDatTour.Text);
            pb.IdLichKhoiHanhThucTe = Convert.ToInt32(txtIdLichKhoiHanhThucTe.Text);
            pb.SoLuongPhanBo =Convert.ToInt32(txtSoLuongPhanBo.Text);
            pb.KieuXuLy = cbKieuXuLy.Text;
            pb.TrangThai = cbTrangThai.Text;
            return pb;
        }


        //=====================================================
        private void btnChapNhan_Click(object sender, EventArgs e)
        {
          
        }

        private void btnTuChoi_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {

           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Vui lòng chọn yêu cầu cần xóa");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa yêu cầu này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                int id = Convert.ToInt32(txtId.Text);

                if (busPB.xoaPhanBoDatTour(id))
                {
                    MessageBox.Show("Xóa yêu cầu thành công");
                    LamMoi();
                }
                else
                {
                    MessageBox.Show("Xóa yêu cầu thất bại");
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
        }
        private void UC_XuLyTour_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void cbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void txtSoLuongPhanBo_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtIdDonDatTour_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void txtMaDatTourThucTe_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtIdLichKhoiHanhThucTe_TextChanged(object sender, EventArgs e)
        {

        }
        private void cbKieuXuLy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
  
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
        private void dgvPhanBo_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhanBo.Rows[e.RowIndex];

                txtId.Text = row.Cells["Id"].Value.ToString();
                txtMaDatTourThucTe.Text = row.Cells["MaDatTourThucTe"].Value.ToString();
                txtIdDonDatTour.Text = row.Cells["IdDonDatTour"].Value.ToString();
                txtIdLichKhoiHanhThucTe.Text = row.Cells["IdLichKhoiHanhThucTe"].Value.ToString();
                txtSoLuongPhanBo.Text = row.Cells["SoLuongPhanBo"].Value.ToString();
                cbKieuXuLy.Text = row.Cells["KieuXuLy"].Value.ToString();
                cbTrangThai.Text = row.Cells["TrangThai"].Value.ToString();
            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Vui lòng chọn yêu cầu cần xóa");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa yêu cầu này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                int id = Convert.ToInt32(txtId.Text);

                if (busPB.xoaPhanBoDatTour(id))
                {
                    MessageBox.Show("Xóa yêu cầu thành công");
                    LamMoi();
                }
                else
                {
                    MessageBox.Show("Xóa yêu cầu thất bại");
                }
            }
        }

        private void btnChapNhan_Click_1(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Vui lòng chọn yêu cầu cần xử lý");
                return;
            }

            int id = Convert.ToInt32(txtId.Text);

            if (busPB.CapNhatTrangThaiPhanBo(id, "DaPhanBo"))
            {
                if (cbKieuXuLy.Text == "Tach")
                {
                    MessageBox.Show(
                        "Đã chấp nhận yêu cầu tách tour.\n" +
                        "Vui lòng liên hệ khách hàng để xác nhận chi tiết.\n" +
                        "Nếu phát sinh hoàn tiền, hãy tạo yêu cầu ở tab Hủy / Hoàn tour."
                    );
                }
                else
                {
                    MessageBox.Show("Đã chấp nhận yêu cầu.");
                }

                LamMoi();
                LoadPhanBo();
            }
            else
            {
                MessageBox.Show("Xử lý thất bại");
            }
        }

        private void btnCapNhat_Click_1(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Vui lòng chọn yêu cầu cần cập nhật");
                return;
            }

            DTO_PhanBoDatTour pb = LayThongTinTuForm();

            if (busPB.suaPhanBoDatTour(pb))
            {
                MessageBox.Show("Cập nhật thành công");
                LoadPhanBo();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
        }

        private void btnTuChoi_Click_1(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Vui lòng chọn yêu cầu cần từ chối");
                return;
            }

            int id = Convert.ToInt32(txtId.Text);

            if (busPB.CapNhatTrangThaiPhanBo(id, "DaHuy"))
            {
                MessageBox.Show("Đã từ chối/hủy yêu cầu.");
                LamMoi();
                LoadPhanBo();
            }
            else
            {
                MessageBox.Show("Từ chối thất bại");
            }
        }

        private void btnLamMoi_Click_1(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
              
        }
        private decimal LayTyLePhat( string loaiXuLy,string loaiNgay,DateTime ngayKhoiHanh)
        {
            if (loaiXuLy == "TachSangLichKhac")
            {
                return 0m;
            }

            if (loaiXuLy == "TachDoanGiuaTour")
            {
                return 0.7m;
            }

            int soNgayTruocKhoiHanh =
                (ngayKhoiHanh.Date - DateTime.Now.Date).Days;

            if (loaiNgay == "LeTet")
            {
                if (soNgayTruocKhoiHanh > 30)
                    return 0.1m;

                if (soNgayTruocKhoiHanh > 20)
                    return 0.5m;

                if (soNgayTruocKhoiHanh > 10)
                    return 0.7m;

                return 1.0m;
            }
            else
            {
                if (soNgayTruocKhoiHanh > 15)
                    return 0.1m;

                if (soNgayTruocKhoiHanh > 5)
                    return 0.5m;

                if (soNgayTruocKhoiHanh > 2)
                    return 0.7m;

                return 1.0m;
            }
        }
        private decimal TinhTienHoan(decimal tongTienThanhToan,int tongSoNguoi,int soNguoiHoan,decimal tyLePhat)
        {
            if (tongSoNguoi <= 0 || soNguoiHoan <= 0)
                return 0;

            decimal giaMoiNguoi =
                tongTienThanhToan / tongSoNguoi;

            decimal giaTriHuy =
                giaMoiNguoi * soNguoiHoan;

            decimal tienPhat =
                giaTriHuy * tyLePhat;

            decimal tienHoan =
                giaTriHuy - tienPhat;

            if (tienHoan < 0)
                tienHoan = 0;

            return tienHoan;
        }


        private void btnKiemTraDonHuy_Click(object sender, EventArgs e)
        {
            if (txtMaDonDatTourHuy.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã đơn đặt tour.");
                return;
            }

            string maDon = txtMaDonDatTourHuy.Text.Trim();

            DataTable dt = busHT.GetThongTinDonDatTourTheoMa(maDon);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Mã đơn đặt tour không hợp lệ hoặc không tồn tại.");
                return;
            }

            DataRow row = dt.Rows[0];

            txtTongTienDon.Text =
                Convert.ToDecimal(row["TongTienThanhToan"]).ToString("0");

            txtTongSoNguoi.Text =
                row["SoLuongNguoi"].ToString();

            dtpNgayKhoiHanhHuy.Value =
                Convert.ToDateTime(row["NgayKhoiHanh"]);

            MessageBox.Show("Kiểm tra đơn thành công.");
        }

        private void btnTinhTienHoan_Click(object sender, EventArgs e)
        {
            if (txtTongTienDon.Text.Trim() == "" ||
     txtTongSoNguoi.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng kiểm tra đơn trước khi tính tiền hoàn.");
                return;
            }

            if (cbLoaiXuLyHoan.Text != "HuyTour" &&
                txtSoNguoiHoan.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập số người tách cần hoàn.");
                return;
            }
            decimal tongTien;
            int tongSoNguoi;
            int soNguoiHoan;
            if (!decimal.TryParse(txtTongTienDon.Text.Trim(), out tongTien))
            {
                MessageBox.Show("Tổng tiền đơn không hợp lệ.");
                return;
            }

            if (!int.TryParse(txtTongSoNguoi.Text.Trim(), out tongSoNguoi))
            {
                MessageBox.Show("Tổng số người không hợp lệ.");
                return;
            }
            if (cbLoaiXuLyHoan.Text == "HuyTour")
            {
                soNguoiHoan = tongSoNguoi;
                txtSoNguoiHoan.Text = tongSoNguoi.ToString();
            }
            else
            {
                if (!int.TryParse(txtSoNguoiHoan.Text.Trim(), out soNguoiHoan))
                {
                    MessageBox.Show("Số người tách cần hoàn phải là số.");
                    return;
                }
            }

            if (soNguoiHoan <= 0)
            {
                MessageBox.Show("Số người hủy/tách phải lớn hơn 0.");
                return;
            }

            if (soNguoiHoan > tongSoNguoi)
            {
                MessageBox.Show("Số người hủy/tách không được lớn hơn tổng số người trong đơn.");
                return;
            }

            if (cbLoaiXuLyHoan.Text == "TachSangLichKhac")
            {
                txtTyLePhat.Text = "0%";
                txtSoTienHoan.Text = "0";
                cbTrangThaiHoanTien.Text = "KhongHoan";

                MessageBox.Show("Tách sang lịch/tour khác không phát sinh hoàn tiền.");
                return;
            }

            decimal tyLePhat = LayTyLePhat(
                cbLoaiXuLyHoan.Text,
                cbLoaiNgay.Text,
                dtpNgayKhoiHanhHuy.Value
            );

            decimal soTienHoan = TinhTienHoan(
                tongTien,
                tongSoNguoi,
                soNguoiHoan,
                tyLePhat
            );

            txtTyLePhat.Text = (tyLePhat * 100).ToString("0") + "%";

            txtSoTienHoan.Text = soTienHoan.ToString("0");

            if (soTienHoan <= 0)
            {
                cbTrangThaiHoanTien.Text = "KhongHoan";
            }
            else
            {
                cbTrangThaiHoanTien.Text = "ChuaHoan";
            }
        }

            private void btnLuuHuyHoan_Click(object sender, EventArgs e)
        {
            if (txtMaDonDatTourHuy.Text.Trim() == "" ||
       txtLyDoHuy.Text.Trim() == "" ||
       txtSoTienHoan.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã đơn, lý do và số tiền hoàn.");
                return;
            }

            int idDonDatTour =
                busHT.GetIdDonDatTourTheoMa(txtMaDonDatTourHuy.Text.Trim());

            if (idDonDatTour == 0)
            {
                MessageBox.Show("Mã đơn đặt tour không hợp lệ hoặc không tồn tại.");
                return;
            }

            decimal soTienHoan;

            if (!decimal.TryParse(txtSoTienHoan.Text.Trim(), out soTienHoan))
            {
                MessageBox.Show("Số tiền hoàn phải là số.");
                return;
            }
            DTO_HuyTour ht = new DTO_HuyTour();

            if (txtIdHuy.Text.Trim() != "")
            {
                ht.Id = Convert.ToInt32(txtIdHuy.Text.Trim());
            }

            ht.IdDonDatTour = idDonDatTour;
            ht.LyDo = txtLyDoHuy.Text.Trim();
            ht.NgayHuy = DateTime.Now;
            ht.SoTienHoan = soTienHoan;

            if (soTienHoan <= 0)
            {
                ht.TrangThaiHoanTien = "KhongHoan";
            }
            else
            {
                ht.TrangThaiHoanTien = "ChuaHoan";
            }
            try
            {
                bool ketQua;

                if (txtIdHuy.Text.Trim() == "")
                {
                    // Nhân viên tạo yêu cầu hủy/hoàn mới
                    ketQua = busHT.ThemHuyTour(ht);
                }
                else
                {
                    // Nhân viên cập nhật yêu cầu hủy/hoàn đang chọn
                    ketQua = busHT.CapNhatThongTinHoanTien(ht);
                }

                if (ketQua)
                {
                    MessageBox.Show("Lưu yêu cầu hủy / hoàn thành công.");
                    LamMoiHuyHoan();
                    LoadHuyHoanTour();
                }
                else
                {
                    MessageBox.Show("Lưu yêu cầu thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu yêu cầu hủy / hoàn:\n" + ex.Message);
            }
        

        }

        private void dgvHuyHoanTour_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row =
                    dgvHuyHoanTour.Rows[e.RowIndex];

                txtIdHuy.Text =
                    row.Cells["Id"].Value.ToString();

                txtMaDonDatTourHuy.Text =
                    row.Cells["MaDatTourBanDau"].Value.ToString();

                txtLyDoHuy.Text =
                    row.Cells["LyDo"].Value.ToString();

                txtSoTienHoan.Text =
                    row.Cells["SoTienHoan"].Value.ToString();

                cbTrangThaiHoanTien.Text =
                    row.Cells["TrangThaiHoanTien"].Value.ToString();
            }
        }

        private void btnDaHoanTien_Click(object sender, EventArgs e)
        {
            if (txtIdHuy.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn yêu cầu hoàn tiền cần xử lý.");
                return;
            }

            int id = Convert.ToInt32(txtIdHuy.Text);

            if (busHT.CapNhatTrangThaiHoanTien(id, "DaHoan"))
            {
                MessageBox.Show("Đã cập nhật trạng thái: Đã hoàn tiền.");
                LamMoiHuyHoan();
                LoadHuyHoanTour();
            }
        }

        private void btnKhongHoanTien_Click(object sender, EventArgs e)
        {
            if (txtIdHuy.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn yêu cầu cần xử lý.");
                return;
            }

            int id = Convert.ToInt32(txtIdHuy.Text);

            if (busHT.CapNhatTrangThaiHoanTien(id, "KhongHoan"))
            {
                MessageBox.Show("Đã cập nhật trạng thái: Không hoàn.");
                LamMoiHuyHoan();
                LoadHuyHoanTour();
            }
        }
        private void LamMoiHuyHoan()
        {
            txtIdHuy.Clear();
            txtMaDonDatTourHuy.Clear();
            txtTongTienDon.Clear();
            txtTongSoNguoi.Clear();
            txtSoNguoiHoan.Clear();
            txtTyLePhat.Clear();
            txtSoTienHoan.Clear();
            txtLyDoHuy.Clear();

            dtpNgayKhoiHanhHuy.Value = DateTime.Now;

            if (cbLoaiXuLyHoan.Items.Count > 0)
                cbLoaiXuLyHoan.SelectedIndex = 0;

            if (cbLoaiNgay.Items.Count > 0)
                cbLoaiNgay.SelectedIndex = 0;

            if (cbTrangThaiHoanTien.Items.Count > 0)
                cbTrangThaiHoanTien.SelectedIndex = 0;
        }

        private void btnLamMoiHuyHoan_Click(object sender, EventArgs e)
        {
            LamMoiHuyHoan();
            LoadHuyHoanTour();
        }
    }
}

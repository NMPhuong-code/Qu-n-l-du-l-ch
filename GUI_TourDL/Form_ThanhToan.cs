using System;
using System.Windows.Forms;
using BUS_TourDL;
using DTO_TourDL;

namespace GUI_TourDL
{
    public partial class Form_ThanhToan : Form
    {
        private DTO_DatTourTronGoi donHang;
        private BUS_Tour busTour = new BUS_Tour();
        private BUS_ThanhToan busTT = new BUS_ThanhToan();
        private Tourmodel tourDuocChon;
        private decimal giaGocTour = 0;
        private int sLNguoiLon = 0;
        private int sLTreEm = 0;

        public Form_ThanhToan()
        {
            InitializeComponent();
        }

        public Form_ThanhToan(DTO_DatTourTronGoi donDat, Tourmodel tour, decimal giaTour, int nguoiLon, int treEm)
        {
            InitializeComponent();
            this.donHang = donDat;
            this.tourDuocChon = tour;
            this.giaGocTour = giaTour;
            this.sLNguoiLon = nguoiLon;
            this.sLTreEm = treEm;
        }

        private void Form_ThanhToan_Load(object sender, EventArgs e)
        {
            // Combobox phương thức thanh toán
            cboPhuongThuc.Items.Clear();
            cboPhuongThuc.Items.Add("Ví điện tử MoMo");
            cboPhuongThuc.Items.Add("Thẻ ngân hàng nội địa");
            cboPhuongThuc.Items.Add("Thẻ quốc tế (Visa/MasterCard)");
            cboPhuongThuc.Items.Add("Thanh toán tại văn phòng");
            cboPhuongThuc.SelectedIndex = 0;

            // Kiểm tra dữ liệu
            if (donHang == null || tourDuocChon == null)
            {
                MessageBox.Show("Dữ liệu thanh toán không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Thông tin tour
            lbl_tt_tourdl.Text = tourDuocChon.TenTour;
            lbl_tt_mota.Text = tourDuocChon.MoTa;
            lbl_tt_ngkh.Text = tourDuocChon.NgayKhoiHanh.ToString("dd/MM/yyyy");

            // Thông tin khách hàng
            lbl_tt_HoTen.Text = donHang.TenNguoiDat;
            lbl_tt_gia.Text = giaGocTour.ToString("N0") + "đ / Vé";

            // Thành tiền
            decimal thanhTienNguoiLon = sLNguoiLon * giaGocTour;
            decimal thanhTienTreEm = sLTreEm * (giaGocTour * 0.9m);
            decimal tongTien = thanhTienNguoiLon + thanhTienTreEm;

            // Gán dữ liệu đơn hàng
            donHang.SoLuong = sLNguoiLon + sLTreEm;
            donHang.TongTienGoc = tongTien;
            donHang.TongTienThanhToan = tongTien;

            // Hiển thị số lượng
            lbl_tt_NguoiLon.Text = sLNguoiLon.ToString();
            lbl_tt_TreEm.Text = sLTreEm.ToString();

            // Hiển thị thành tiền
            lbl_thanhtienNL.Text = thanhTienNguoiLon.ToString("N0") + "đ";
            lblb_thanhtien_TreEm.Text = thanhTienTreEm.ToString("N0") + "đ";
            lblSoTienThanhToan.Text = tongTien.ToString("N0") + "đ";
            lbl_tt_TongTien.Text = tongTien.ToString("N0") + "đ";
        }

        private void btnXacNhanThanhToan_Click(object sender, EventArgs e)
        {
            XulyXacNhanThanhToan();
        }

        private void check_ThanhToan_Click(object sender, EventArgs e)
        {
            XulyXacNhanThanhToan();
        }

        private void XulyXacNhanThanhToan()
        {
            // Kiểm tra chọn phương thức
            if (cboPhuongThuc.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra số lượng
            if (donHang.SoLuong <= 0)
            {
                MessageBox.Show("Số lượng khách không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hình thức tour
            donHang.HinhThucDatTour = "Ghep";

            // Trạng thái đơn
            donHang.TrangThaiDon = "DaXacNhan";

            // Lưu đơn đặt tour
            bool ketQua = busTour.ThucHienDatTour(donHang);

            if (ketQua)
            {
                // Tạo thanh toán
                DTO_ThanhToan tt = new DTO_ThanhToan();
                tt.IdDonDatTour = 1;
                tt.LoaiThanhToan = "ThanhToan";

                // Phương thức thanh toán
                if (cboPhuongThuc.SelectedItem.ToString() == "Thanh toán tại văn phòng")
                {
                    tt.PhuongThucTT = "TienMat";
                }
                else
                {
                    tt.PhuongThucTT = "ChuyenKhoan";
                }

                tt.SoTien = donHang.TongTienThanhToan;
                tt.TrangThaiTT = "ThanhCong";
                tt.MaGiaoDich = "GD_" + DateTime.Now.Ticks;
                tt.NgayThanhToan = DateTime.Now;

                // Lưu thanh toán
                busTT.LuuThanhToan(tt);

                MessageBox.Show("Thanh toán tour thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại!\nVui lòng kiểm tra lại số lượng chỗ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
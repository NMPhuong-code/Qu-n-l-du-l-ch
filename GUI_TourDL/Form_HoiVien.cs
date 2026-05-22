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
    public partial class Form_HoiVien : Form
    {
        private DTO_TaiKhoan _taiKhoan;
        private BUS_HoiVien _busHV = new BUS_HoiVien();

        public Form_HoiVien(DTO_TaiKhoan taiKhoan)
        {
            InitializeComponent();
            _taiKhoan = taiKhoan;
        }

        private void Form_HoiVien_Load(object sender, EventArgs e)
        {
            HienThiThongTinHoiVien();
        }

        private void HienThiThongTinHoiVien()
        {
            lblTenDangNhap.Text = _taiKhoan.TenDangNhap;
            lblVaiTro.Text = "Khách hàng";
            lblTrangThai.Text = _taiKhoan.TrangThai;

            int maKH = _taiKhoan.IdKhachHang;

            if (maKH <= 0)
            {
                MessageBox.Show("Không lấy được mã khách hàng.");
                return;
            }

            DTO_HoiVien hv = _busHV.LayHoiVienTheoId(maKH);

            if (hv == null)
            {
                lblHangHoiVien.Text = "Chưa là hội viên";
                lblHangHoiVien.ForeColor = Color.Gray;
                lblSoTour.Text = "0 điểm";
                lblUuDai.Text = "Khách hàng này chưa có thông tin hội viên.";
                progressHang.Value = 0;
                lblTienDo.Text = "";
                return;
            }

            lblSoTour.Text = hv.DiemHienTai + " điểm";

            lblHangHoiVien.Text = LayTenHang(hv.HangThanhVien);
            lblHangHoiVien.ForeColor = LayMauHang(hv.HangThanhVien);

            lblUuDai.Text = LayUuDai(hv.HangThanhVien);

            var tienDo = LayTienDo(hv.DiemHienTai);
            progressHang.Maximum = tienDo.max;
            progressHang.Value = Math.Min(tienDo.cur, tienDo.max);
            lblTienDo.Text = tienDo.moTa;
        }

        private string LayTenHang(string hang)
        {
            switch (hang)
            {
                case "Platinum": return "💎 PLATINUM";
                case "Gold": return "⭐ GOLD";
                case "Silver": return "🥈 SILVER";
                default: return "🌱 TIỀM NĂNG";
            }
        }

        private Color LayMauHang(string hang)
        {
            switch (hang)
            {
                case "Platinum": return Color.MediumPurple;
                case "Gold": return Color.Gold;
                case "Silver": return Color.Silver;
                default: return Color.SteelBlue;
            }
        }

        private string LayUuDai(string hang)
        {
            switch (hang)
            {
                case "Platinum": return "Giảm 10% cho mọi chuyến đi\nƯu tiên đặt chỗ trước\nHỗ trợ 24/7 riêng biệt";
                case "Gold": return "Giảm 5% cho mọi chuyến đi\nTích điểm nhanh hơn";
                case "Silver": return "Tích điểm mỗi chuyến đi\nLên Gold khi đạt 500 điểm";
                default: return "Đặt tour đầu tiên để bắt đầu tích điểm!";
            }
        }

        private (int cur, int max, string moTa) LayTienDo(int diem)
        {
            if (diem >= 1500)
                return (1500, 1500, "🎉 Bạn đã đạt hạng cao nhất — Platinum!");
            if (diem >= 500)
                return (diem - 500, 1000, $"Còn {1500 - diem} điểm nữa để lên Platinum");
            if (diem > 0)
                return (diem, 500, $"Còn {500 - diem} điểm nữa để lên Gold");
            return (0, 500, "Đặt tour để bắt đầu tích điểm!");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

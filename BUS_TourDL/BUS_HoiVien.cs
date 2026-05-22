using DAL_TourDL;
using DTO_TourDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_TourDL
{
    public class BUS_HoiVien
    {
        private readonly DAL_HoiVien _dal = new DAL_HoiVien();

        // Công thức tích điểm: 10.000đ = 1 điểm
        private const decimal TIEN_MOI_DIEM = 10000m;


        public DTO_HoiVien LayHoiVienTheoId(int idKhachHang)
            => _dal.LayHoiVienTheoId(idKhachHang);

        public List<DTO_HoiVien> LayDanhSachHoiVien()
            => _dal.LayDanhSachHoiVien();

        public bool LaHoiVien(int idKhachHang)
            => _dal.LaHoiVien(idKhachHang);

        /// <summary>
        /// Đăng ký hội viên mới — gọi ngay sau khi đăng ký tài khoản.
        /// Hạng ban đầu: Tiềm Năng, điểm = 0.
        /// </summary>
        public bool DangKyHoiVien(int idKhachHang)
        {
            if (_dal.LaHoiVien(idKhachHang)) return false;
            return _dal.DangKyHoiVien(idKhachHang);
        }

        /// <summary>
        /// Cộng điểm sau khi đặt tour thành công.
        /// Công thức: 10.000đ = 1 điểm.
        /// Hạng tự động cập nhật theo điểm mới.
        /// Ví dụ: tour 1.500.000đ → +150 điểm
        /// </summary>
        public bool CongDiemSauDatTour(int idKhachHang, decimal tongTien)
        {
            int diem = (int)(tongTien / TIEN_MOI_DIEM);
            if (diem <= 0) return false;
            return _dal.CongDiem(idKhachHang, diem);
        }

        /// <summary>
        /// Trả về tên hạng hiển thị có emoji.
        /// </summary>
        public string LayTenHangHienThi(string hang)
        {
            switch (hang)
            {
                case "Platinum": return "💎 PLATINUM";
                case "Gold": return "⭐ GOLD";
                case "Silver": return "🥈 SILVER";
                default: return "🌱 TIỀM NĂNG";
            }
        }

        /// <summary>
        /// Trả về mô tả ưu đãi theo hạng.
        /// </summary>
        public string LayMoTaUuDai(string hang)
        {
            switch (hang)
            {
                case "Platinum": return "Giảm 10% cho mọi chuyến đi\nƯu tiên đặt chỗ trước\nHỗ trợ 24/7 riêng biệt";
                case "Gold": return "Giảm 5% cho mọi chuyến đi\nTích điểm nhanh hơn";
                case "Silver": return "Tích điểm mỗi chuyến đi\nLên Gold khi đạt 500 điểm";
                default: return "Đặt tour đầu tiên để trở thành Silver\nvà bắt đầu tích điểm ưu đãi!";
            }
        }

        /// <summary>
        /// Tính tiến độ lên hạng tiếp theo.
        /// Trả về (diemHienTai, diemMucTieu, moTa).
        /// </summary>
        public (int current, int max, string moTa) LayTienDoLenHang(int diem)
        {
            if (diem >= 1500)
                return (1500, 1500, "🎉 Bạn đã đạt hạng cao nhất — Platinum!");

            if (diem >= 500)
            {
                int con = 1500 - diem;
                return (diem - 500, 1000, $"Còn {con} điểm nữa để lên Platinum");
            }

            if (diem > 0)
                return (diem, 500, $"Còn {500 - diem} điểm nữa để lên Gold");

            // Tiềm Năng — chưa có điểm
            return (0, 1, "Đặt tour đầu tiên để bắt đầu tích điểm!");
        }

        /// <summary>
        /// Trả về phần trăm giảm giá theo hạng.
        /// Dùng khi tính tổng tiền đặt tour.
        /// </summary>
        public decimal LayPhanTramGiamGia(string hang)
        {
            switch (hang)
            {
                case "Platinum": return 0.10m;
                case "Gold": return 0.05m;
                default: return 0m;
            }
        }

        /// <summary>
        /// Tính số điểm nhận được từ một đơn đặt tour.
        /// Dùng để hiển thị trước khi xác nhận đặt.
        /// </summary>
        public int TinhDiemNhanDuoc(decimal tongTien)
            => (int)(tongTien / TIEN_MOI_DIEM);
    }
}

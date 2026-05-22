using System;

namespace DTO_TourDL
{
    public class DTO_HoiVien
    {
        public int IdKhachHang { get; set; }
        public DateTime? NgayDangKy { get; set; }
        public int DiemHienTai { get; set; }
        public string HangThanhVien { get; set; }

        // Thông tin join từ bảng KhachHang (dùng để hiển thị)
        public string TenKH { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }

        public DTO_HoiVien() { }

        public DTO_HoiVien(int idKhachHang, DateTime? ngayDangKy, int diemHienTai, string hangThanhVien)
        {
            IdKhachHang = idKhachHang;
            NgayDangKy = ngayDangKy;
            DiemHienTai = diemHienTai;
            HangThanhVien = hangThanhVien;
        }
    }
}

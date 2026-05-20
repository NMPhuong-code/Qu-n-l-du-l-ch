using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_TourDL
{
    public class DTO_DatTourTronGoi
    {
        public int IdKhachHang { get; set; }
        public string TenNguoiDat { get; set; }
        public string EmailNguoiDat { get; set; }
        public string SDTNguoiDat { get; set; }
        public string CCCDNguoiDat { get; set; }

        public int IdLich { get; set; }
        public int SoLuong { get; set; }
        public string HinhThucDatTour { get; set; }

        public int? IdKhuyenMai { get; set; }
        public decimal SoTienGiamKhuyenMai { get; set; }
        public decimal TongTienGoc { get; set; }
        public decimal TongTienThanhToan { get; set; }

        public string TrangThaiDon { get; set; }
        public DateTime NgayDat { get; set; }

        public List<DTO_NguoiDiTour> DanhSachNguoiDi { get; set; } = new List<DTO_NguoiDiTour>();
    }
}
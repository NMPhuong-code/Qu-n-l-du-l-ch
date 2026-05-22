using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_TourDL
{
    public class DTO_DonDatTour
    {
        public int Id { get; set; }
        public string MaDatTourBanDau { get; set; }
        public int IdKhachHang { get; set; }
        public int IdLichKhoiHanhBanDau { get; set; }
        public int SoLuongNguoi { get; set; }
        public string HinhThucDatTour { get; set; }
        public int? IdKhuyenMai { get; set; }
        public decimal SoTienGiamKhuyenMai { get; set; }
        public decimal TongTienGoc { get; set; }
        public decimal TongTienThanhToan { get; set; }
        public string TrangThaiDon { get; set; }
        public DateTime NgayDat { get; set; }
    }
}

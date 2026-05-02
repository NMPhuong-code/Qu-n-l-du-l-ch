using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_TourDL
{
    public class DTO_DatTourTronGoi
    {
        public string TenNguoiDat { get; set; }
        public string EmailNguoiDat { get; set; }
        public string SDTNguoiDat { get; set; }
        public string DiaChiNguoiDat { get; set; }

        public int IdLich { get; set; }
        public int SoLuong { get; set; }
        public decimal TongTien { get; set; }

        // Danh sách chi tiết những người đi
        public List<DTO_NguoiDiTour> DanhSachNguoiDi { get; set; }
    }
}

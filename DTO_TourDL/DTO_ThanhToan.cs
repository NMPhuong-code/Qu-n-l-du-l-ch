using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_TourDL
{
    public class DTO_ThanhToan
    {
        public int IdDonDatTour { get; set; }

        public string LoaiThanhToan { get; set; }

        public string PhuongThucTT { get; set; }

        public decimal SoTien { get; set; }

        public string TrangThaiTT { get; set; }

        public string MaGiaoDich { get; set; }

        public DateTime NgayThanhToan { get; set; }
    }
}

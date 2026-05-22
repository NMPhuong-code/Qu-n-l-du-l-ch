using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_TourDL
{
    public class DTO_PhanBoDatTour
    {
        public int Id { get; set; }
        public string MaDatTourThucTe { get; set; }
        public int IdDonDatTour { get; set; }
        public int IdLichKhoiHanhThucTe { get; set; }
        public int SoLuongPhanBo { get; set; }
        public string KieuXuLy { get; set; }
        public string TrangThai { get; set; }
    }
}

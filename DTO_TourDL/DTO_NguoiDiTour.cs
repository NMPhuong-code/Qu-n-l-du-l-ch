using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_TourDL
{
    public class DTO_NguoiDiTour
    {
        public int IdNguoiDi { get; set; }
        public int IdDonDatTour { get; set; }
        public string TenNguoi { get; set; }
        public string CCCD { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public DateTime? NgaySinh { get; set; }
    }
}

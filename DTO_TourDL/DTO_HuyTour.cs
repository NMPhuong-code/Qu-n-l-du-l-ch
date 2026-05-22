using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_TourDL
{
    public class DTO_HuyTour
    {
        public int Id { get; set; }

        public int IdDonDatTour { get; set; }

        public string LyDo { get; set; }

        public DateTime NgayHuy { get; set; }

        public decimal SoTienHoan { get; set; }

        public string TrangThaiHoanTien { get; set; }
    }
}

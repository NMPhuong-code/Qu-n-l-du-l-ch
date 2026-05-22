using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_TourDL
{
    public class DTO_NguoiDung
    {
        public int Id { get; set; }

        public int? IdTaiKhoan { get; set; }

        public string TenKH { get; set; }

        public string Email { get; set; }

        public string SDT { get; set; }

        public string CCCD { get; set; }
    }
}

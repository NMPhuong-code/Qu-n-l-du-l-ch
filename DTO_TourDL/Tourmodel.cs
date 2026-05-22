using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_TourDL
{
    public class Tourmodel
    {
        public int Id { get; set; }
        public string TenTour { get; set; }
        public string MoTa { get; set; }
        public decimal GiaCoBan { get; set; }
        public bool TrangThai { get; set; }
        public string HinhAnh { get; set; }
        public int SoChoConTrong { get; set; }
        public int IdLich { get; set; }
        public DateTime NgayKhoiHanh { get; set; }
        public Tourmodel() { }  
    }
}

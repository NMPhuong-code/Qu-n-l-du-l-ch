using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_TourDL
{
    public class DTO_LichKhoiHanh
    {
        public int Id { get; set; }
        public int IdTour { get; set; }
        public string TenTour { get;set; }
        public DateTime NgayKhoiHanh { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public int SoChoToiThieu {  get; set; }
        public int SoChoToiDa {  get; set; }
        public decimal GiaThucTe {  get; set; }
        public string TrangThai {  get; set; }
        public string LoaiNgay {  get; set; }

    }
}

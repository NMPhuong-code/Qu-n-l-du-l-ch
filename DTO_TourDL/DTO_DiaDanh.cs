using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_TourDL
{
    public class DTO_DiaDanh
    {
        public int Id{ get; set; }
        public string TenDiaDanh { get; set; }
        public string TinhThanh { get; set; }
        public DTO_DiaDanh()
        {
        }
        public DTO_DiaDanh( int Id, string TenDiaDanh, string TinhThanh)
        {
            this.Id = Id;
            this.TenDiaDanh= TenDiaDanh;
            this.TinhThanh = TinhThanh;
        }
    }
}

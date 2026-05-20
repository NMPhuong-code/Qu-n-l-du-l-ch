using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_TourDL;
using DTO_TourDL;

namespace BUS_TourDL
{
    public class BUS_LichKhoiHanh
    {
        DAL_LichKhoiHanh dal = new DAL_LichKhoiHanh();
        public List<DTO_LichKhoiHanh> getLichKhoiHanh()
        {
            return dal.GetLichKhoiHanh();
        }
        public List<DTO_LichKhoiHanh> TimKiemLich(string key)
        {
            return dal.TimKiemLich(key);
        }
        public bool themLichKhoiHanh(DTO_LichKhoiHanh lich)
        {
            return dal.themLichKhoiHanh(lich);
        }
        public bool suaLichKhoiHanh(DTO_LichKhoiHanh lich)
        {
            return dal.suaLichKhoiHanh(lich) ;
        }
        public bool xoaLichKhoiHanh(int id)
        {
            return dal.xoaLichKhoiHanh(id) ;
        }
    }
}

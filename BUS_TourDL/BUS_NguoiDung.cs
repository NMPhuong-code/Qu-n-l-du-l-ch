using DAL_TourDL;
using DTO_TourDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_TourDL
{
    public class BUS_NguoiDung
    {
        DAL_NguoiDung dal = new DAL_NguoiDung();
        public List<DTO_NguoiDung> getNguoiDung()
        {
            return dal.getNguoiDung();
        }
        public bool ThemKhachHang(DTO_NguoiDung nd)
        {
            return dal.ThemKhachHang(nd);
        }

        public bool SuaKhachHang(DTO_NguoiDung nd)
        {
            return dal.SuaKhachHang(nd);
        }

        public bool XoaKhachHang(int id)
        {
            return dal.XoaKhachHang(id);
        }
        public List<DTO_NguoiDung> TimKiemKhachHang(string key)
        {
            return dal.TimKiemKhachHang(key);
        }

    }
}

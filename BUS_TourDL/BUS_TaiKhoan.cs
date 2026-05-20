using DTO_TourDL;
using DAL_TourDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_TourDL
{

    public class BUS_TaiKhoan
    {
        DAL_TaiKhoan dal= new DAL_TaiKhoan();
        public List<DTO_TaiKhoan> getTaiKhoan()
        {
            return dal.getTaiKhoan();
        }
        public bool themTaiKhoan(DTO_TaiKhoan tk)
        {
            return dal.themTaiKhoan(tk);
        }
        public bool suaTaiKhoan(DTO_TaiKhoan tk)
        {
            return dal.suaTaiKhoan(tk);
        }
        public bool xoaTaiKhoan(int id)
        {
            return dal.xoaTaiKhoan(id);
        }
        public List<DTO_TaiKhoan> timKiemTaiKhoan(string key)
        {
            return dal.timKiemTaiKhoan(key);
        }
    }
}

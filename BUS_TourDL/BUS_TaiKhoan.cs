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
        public DTO_TaiKhoan dangNhap(string tenDangNhap, string matKhau)
        {
            return dal.dangNhap(tenDangNhap, matKhau);
        }
        public bool kiemTraTrungTenDangNhap(string tenDangNhap)
        {
            return dal.kiemTraTrungTenDangNhap(tenDangNhap);
        }
        public bool dangKyKhachHang(string tenDangNhap, string matKhau,string tenKH,string email,string sdt, string cccd)
        {
            return dal.dangKyKhachHang(
                tenDangNhap,
                matKhau,
                tenKH,
                email,
                sdt,
                cccd
                );
        }
    }
}

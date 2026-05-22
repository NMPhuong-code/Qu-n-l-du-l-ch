using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_TourDL
{
    public class DTO_TaiKhoan
    {
        
            public int Id_TKhoan { get; set; }
            public string TenDangNhap { get; set; }
            public string MatKhau { get; set; }
            public string VaiTro { get; set; }
            public string TrangThai { get; set; }
            public int IdNhomQuyen { get; set; }
            public string TenNhomQuyen { get; set; }
        public int IdKhachHang { get; set; }

        public DTO_TaiKhoan()
        {
        }

        public DTO_TaiKhoan(string tenDangNhap, string matKhau, string vaiTro, string trangThai, int idNhomQuyen)
        {
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            VaiTro = vaiTro;
            TrangThai = trangThai;
            IdNhomQuyen = idNhomQuyen;
        }

    }
}

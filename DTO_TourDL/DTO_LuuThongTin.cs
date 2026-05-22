using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_TourDL
{
    public class DTO_LuuThongTin
    {
        public static int IdKhachHangHienTai { get; set; } = 0;

        // Có thể lưu thêm tên để hiển thị "Xin chào..." trên giao diện nếu muốn
        public static string TenKhachHangHienTai { get; set; } = "";
    }
}

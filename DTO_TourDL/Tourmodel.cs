using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_TourDL
{
    public class Tourmodel
    {
        // Khớp với bảng Tour trong Database
        public string IDTour { get; set; }
        public string TenTour { get; set; }
        public string MoTa { get; set; }
        public int SoNgay { get; set; }
        public int SoDem { get; set; }
        public decimal GiaCoBan { get; set; } // Dùng decimal cho tiền tệ sẽ chính xác hơn int
        public string TrangThai { get; set; }

        // Trường bổ sung để phục vụ hiển thị trên GUI (không nhất thiết có trong DB)
        // Lưu đường dẫn file ảnh: "vungtau.jpg" hoặc "dalat.png"
        public string HinhAnh { get; set; }

        // Thuộc tính tự chế để hiện thị chuỗi "3 ngày 2 đêm" cho nhanh
        public string ThoiGianHienThi
        {
            get { return SoNgay + " ngày " + SoDem + " đêm"; }
        }
    }
}

using DAL_TourDL;
using DTO_TourDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_TourDL
{
    public class BUS_Tour
    {
        DAL_Tour dalTour = new DAL_Tour();

        public List<Tourmodel> TimKiemTour(string diaDiem, DateTime ngayDi, string nganSach)
        {
            // 1. Lấy toàn bộ dữ liệu từ SQL thông qua DAL
            var danhSachGoc = dalTour.GetAllTour();

            // 2. Lọc theo Tên Tour (Địa điểm)
            var ketQua = danhSachGoc.Where(t => t.TenTour.ToLower().Contains(diaDiem.ToLower())).ToList();

            // 3. Lọc theo ngân sách (Sử dụng cột GiaCoBan)
            if (nganSach == "Dưới 4 triệu")
                ketQua = ketQua.Where(t => t.GiaCoBan < 4000000).ToList();
            else if (nganSach == "Từ 4 - 6 triệu")
                ketQua = ketQua.Where(t => t.GiaCoBan >= 4000000 && t.GiaCoBan <= 6000000).ToList();
            else if (nganSach == "Trên 6 triệu")
                ketQua = ketQua.Where(t => t.GiaCoBan > 6000000).ToList();

            // Lưu ý: Tạm thời bỏ qua lọc ngayDi nếu Tourmodel chưa có trường Ngày khởi hành
            // Để tránh lỗi code không chạy được.

            return ketQua;
        }

        public List<Tourmodel> LayTatCa() => dalTour.GetAllTour();
    }
}

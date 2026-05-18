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

        public List<Tourmodel> TimKiemTour(
     string diaDiem,
     DateTime ngayDi,
     string nganSach)
        {
            var ketQua =
                dalTour.TimKiemTour(diaDiem);

            // Lọc ngân sách
            if (nganSach == "Dưới 4 triệu")
            {
                ketQua = ketQua.Where(t =>
                    t.GiaCoBan < 4000000)
                    .ToList();
            }
            else if (nganSach == "Từ 4 - 6 triệu")
            {
                ketQua = ketQua.Where(t =>
                    t.GiaCoBan >= 4000000 &&
                    t.GiaCoBan <= 6000000)
                    .ToList();
            }
            else if (nganSach == "Trên 6 triệu")
            {
                ketQua = ketQua.Where(t =>
                    t.GiaCoBan > 6000000)
                    .ToList();
            }

            return ketQua;
        }
        public List<Tourmodel> LayTatCa() => dalTour.GetAllTour();
    }
}

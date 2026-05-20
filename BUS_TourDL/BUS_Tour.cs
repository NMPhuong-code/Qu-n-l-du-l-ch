using DAL_TourDL;
using DTO_TourDL;
using System;
using System.Collections.Generic;

namespace BUS_TourDL
{
    public class BUS_Tour
    {
        DAL_Tour dalTour = new DAL_Tour();

        public List<Tourmodel> TimKiemTour(string diaDiem, DateTime? ngayDi, string nganSach)
        {
            decimal? giaToiDa = null;

            if (nganSach == "Dưới 4 triệu")
                giaToiDa = 4000000;
            else if (nganSach == "Từ 4 - 6 triệu")
                giaToiDa = 6000000;
            else if (nganSach == "Trên 6 triệu")
                giaToiDa = 999999999;

            return dalTour.TimKiemTour(diaDiem, ngayDi, giaToiDa);
        }

        public bool ThucHienDatTour(DTO_DatTourTronGoi donDat)
        {
            return dalTour.LuuDonDatTour(donDat);
        }

        public List<Tourmodel> LayTatCa()
        {
            return dalTour.GetAllTour();
        }
    }
}
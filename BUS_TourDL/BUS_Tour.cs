using DAL_TourDL;
using DTO_TourDL;
using System;
using System.Collections.Generic;
using System.Data;

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
 
        
        public bool themTour(Tourmodel tour)
        {
            return dalTour.themTour(tour);
        }
        public bool suaTour(Tourmodel tour)
        {
            return dalTour.suaTour(tour);
        }
        public bool xoaTour(int Id)
        {
            return dalTour.xoaTour(Id);
        }
        public DataTable LayLichSuTour(int id)
        {
            return dalTour.LayLichSuTour(id);
        }
        public bool GuiYeuCauHuyTour(int idDon, string lyDo)
        {
            if (string.IsNullOrEmpty(lyDo)) return false; // Chặn nếu lý do trống
            return dalTour.XuLyHuyTourVaoDB(idDon, lyDo);
        }
    }
}
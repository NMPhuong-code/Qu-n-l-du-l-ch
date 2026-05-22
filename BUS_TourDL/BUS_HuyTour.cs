using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_TourDL;
using DTO_TourDL;
namespace BUS_TourDL
{
    public class BUS_HuyTour
    {
        DAL_HuyTour dalHT =
            new DAL_HuyTour();

        public DataTable GetHuyTour()
        {
            return dalHT.GetHuyTour();
        }

        public int GetIdDonDatTourTheoMa(string maDatTourBanDau)
        {
            return dalHT.GetIdDonDatTourTheoMa(maDatTourBanDau);
        }

        public DataTable GetThongTinDonDatTourTheoMa(string maDatTourBanDau)
        {
            return dalHT.GetThongTinDonDatTourTheoMa(maDatTourBanDau);
        }

        public bool ThemHuyTour(DTO_HuyTour ht)
        {
            return dalHT.ThemHuyTour(ht);
        }

        public bool CapNhatTrangThaiHoanTien(int id, string trangThaiHoanTien)
        {
            return dalHT.CapNhatTrangThaiHoanTien(id, trangThaiHoanTien);
        }
        public DataTable GetHuyTourChoXuLy()
        {
            return dalHT.GetHuyTourChoXuLy();
        }
        public bool CapNhatThongTinHoanTien(DTO_HuyTour ht)
        {
            return dalHT.CapNhatThongTinHoanTien(ht);
        }
    }
}

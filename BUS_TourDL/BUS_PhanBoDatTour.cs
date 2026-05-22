using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using DTO_TourDL;
using DAL_TourDL;

namespace BUS_TourDL
{
    public class BUS_PhanBoDatTour
    {
        DAL_PhanBoDatTour dalPB =
            new DAL_PhanBoDatTour();

        public List<DTO_PhanBoDatTour> GetPhanBoDatTour()
        {
            return dalPB.GetPhanBoDatTour();
        }

        public bool themPhanBoDatTour(DTO_PhanBoDatTour pb)
        {
            return dalPB.themPhanBoDatTour(pb);
        }

        public bool suaPhanBoDatTour(DTO_PhanBoDatTour pb)
        {
            return dalPB.suaPhanBoDatTour(pb);
        }

        public bool xoaPhanBoDatTour(int id)
        {
            return dalPB.xoaPhanBoDatTour(id);
        }
        public DataTable GetLichCungTourTheoDonDatTour(int idDonDatTour)
        {
            return dalPB.GetLichCungTourTheoDonDatTour(idDonDatTour);
        }
        public int GetIdLichBanDauTheoDonDatTour(int idDonDatTour)
        {
            return dalPB.GetIdLichBanDauTheoDonDatTour(idDonDatTour);
        }
        public DataTable GetPhanBoDangXuLy()
        {
            return dalPB.GetPhanBoDangXuLy();
        }
        public bool CapNhatTrangThaiPhanBo(int id, string trangThai)
        {
            return dalPB.CapNhatTrangThaiPhanBo(id, trangThai);
        }
        public DataTable GetYeuCauTheoDonDatTour(int idDonDatTour)
        {
            return dalPB.GetYeuCauTheoDonDatTour(idDonDatTour);
        }
        public int GetIdDonDatTourTheoMa(string maDatTourBanDau)
        {
            return dalPB.GetIdDonDatTourTheoMa(maDatTourBanDau);
        }
        public bool CapNhatConstraintKieuXuLy()
        {
            return dalPB.CapNhatConstraintKieuXuLy();
        }
    }
}

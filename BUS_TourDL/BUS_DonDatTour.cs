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
    public class BUS_DonDatTour
    {
        DAL_DonDatTour dal = new DAL_DonDatTour();

        public string TaoMaDatTour()
        {
            return dal.TaoMaDatTour();
        }

        public bool ThemDonDatTour(DTO_DonDatTour don)
        {
            return dal.ThemDonDatTour(don);
        }

        public DataTable GetDonDatTour()
        {
            return dal.GetDonDatTour();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_TourDL;
using DTO_TourDL;

namespace BUS_TourDL
{
    public class BUS_ThanhToan
    {
        DAL_ThanhToan dalTT =
            new DAL_ThanhToan();

        public bool LuuThanhToan(
            DTO_ThanhToan tt)
        {
            return dalTT.LuuThanhToan(tt);
        }
       
    }
}

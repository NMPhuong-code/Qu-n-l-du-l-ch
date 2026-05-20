using DAL_TourDL;
using DTO_TourDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_TourDL
{
    public class BUS_NhomQuyen
    {
       DAL_NhomQuyen dal = new DAL_NhomQuyen(); 
        public List<DTO_NhomQuyen> getNhomQuyen()
        {
            return dal.getNhomQuyen();
        }
    }
}

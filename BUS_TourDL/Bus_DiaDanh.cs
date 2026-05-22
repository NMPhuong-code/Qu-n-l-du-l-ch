using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DAL_TourDL;
using DTO_TourDL;

namespace BUS_TourDL
{
    public class Bus_DiaDanh
    {

        DAL_DiaDanh dal = new DAL_DiaDanh();
        public DataTable getDiaDanh()
        {
            return dal.getDiaDanh();
        }
      
    }
}

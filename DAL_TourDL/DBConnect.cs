using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TourDL
{
    public class DBConnect
    {
        protected SqlConnection _conn = new SqlConnection(
            @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyTour;Integrated Security=True;TrustServerCertificate=True");
    }
}


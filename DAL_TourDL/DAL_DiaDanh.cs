using System;
using DTO_TourDL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;

namespace DAL_TourDL
{
    public class DAL_DiaDanh : DBConnect
    {
        public DataTable getDiaDanh()
        {
            string sql = "SELECT DISTINCT TinhThanh " +
                "FROM DiaDanh";
            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;                                  

        }

        //public List<DTO_DiaDanh> GetAllDiaDanh()
        //{
        //    List<DTO_DiaDanh> list = new List<DTO_DiaDanh>();
        //    using (SqlConnection conn = new SqlConnection(connStr))
        //    {
        //        String sql = "SELECT * FROM DiaDanh";
        //        SqlCommand cmd = new SqlCommand(sql, conn);
        //        conn.Open();
        //        SqlDataReader rd = cmd.ExecuteReader();
        //        while (rd.Read())
        //        {
        //            DTO_DiaDanh dd = new DTO_DiaDanh();
        //            dd.Id = Convert.ToInt32(rd["Id"]);
        //            dd.TenDiaDanh= rd["TenDiaDanh"].ToString();
        //            dd.TinhThanh = rd["TinhThanh"].ToString();
        //        }
        //    }
        //    return list;
        //}
    }
}

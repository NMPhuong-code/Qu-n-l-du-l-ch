using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_TourDL;
namespace DAL_TourDL
{
    public class DAL_NhomQuyen:DBConnect
    {
        public List<DTO_NhomQuyen> getNhomQuyen()
        {
            List<DTO_NhomQuyen> ds= new List<DTO_NhomQuyen>();
            _conn.Open();
            string sql = "SELECT * FROM NhomQuyen WHERE TrangThai =1";
           SqlCommand cmd= new SqlCommand(sql, _conn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                DTO_NhomQuyen nq = new DTO_NhomQuyen();
                nq.Id = Convert.ToInt32(rd["Id"]);
                nq.TenNhomQuyen= rd["TenNhomQuyen"].ToString();
                nq.TrangThai = rd["TrangThai"].ToString();
                ds.Add  (nq);
            }
            rd.Close();
            _conn.Close();
            return ds;
        }
    }
}

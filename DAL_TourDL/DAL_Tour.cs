using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_TourDL;

namespace DAL_TourDL
{
    public class DAL_Tour
    {
        // Khai báo chuỗi kết nối (Thay đổi Tên_Database cho đúng với máy bạn)
        string connStr = @"Data Source=.;Initial Catalog=QuanLyTourDuLich;Integrated Security=True";

        public List<Tourmodel> GetAllTour()
        {
            List<Tourmodel> dsTour = new List<Tourmodel>();

            // Sử dụng using để tự động đóng kết nối sau khi dùng xong
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                // Câu lệnh SQL lấy các cột khớp với Tourmodel bạn vừa sửa
                string sql = "SELECT IDTour, TenTour, MoTa, SoNgay, SoDem, GiaCoBan, TrangThai, HinhAnh FROM TOUR";

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Tourmodel tour = new Tourmodel();

                    // Ánh xạ từng cột từ DB vào thuộc tính của Object
                    tour.IDTour = dr["IDTour"].ToString();
                    tour.TenTour = dr["TenTour"].ToString();
                    tour.MoTa = dr["MoTa"].ToString();
                    tour.SoNgay = Convert.ToInt32(dr["SoNgay"]);
                    tour.SoDem = Convert.ToInt32(dr["SoDem"]);
                    tour.GiaCoBan = Convert.ToDecimal(dr["GiaCoBan"]);
                    tour.TrangThai = dr["TrangThai"].ToString();

                    // Kiểm tra nếu cột HinhAnh trong DB bị NULL thì tránh lỗi
                    tour.HinhAnh = dr["HinhAnh"] != DBNull.Value ? dr["HinhAnh"].ToString() : "default.jpg";

                    dsTour.Add(tour);
                }
            }
            return dsTour;
        }
    }
}

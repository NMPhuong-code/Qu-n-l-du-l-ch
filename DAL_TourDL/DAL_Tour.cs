using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_TourDL;

namespace DAL_TourDL
{
    public class DAL_Tour : DBConnect
    {
        //lấy toàn bộ tour từ sql trả về dạng list
        public List<Tourmodel> GetAllTour()
        {
            //1. Tạo một danh sách tour 
            List<Tourmodel> dsTour = new List<Tourmodel>();

            //mở kết nối đến dtb
            _conn.Open();
            //lấy dữ liệu từ bảng tour
            // các CASE Trạng thái dùng để hiện thị trạng thái của tour là đã hoạt động hay ngưng hoạt động
            //nếu thấy phức tạp thì có thể bỏ 
            //tiếp theo là lấy ảnh đại diện, không có thì trả về default.jpn
            //tính số ngày lấy ngày kết thúc - ngày khởi hành 
            String sql = @"SELECT t.Id AS IDTour, t.TenTour, t.MoTa, t.GiaCoBan, 

                 CASE 
                         WHEN t.TrangThai =1
                         THEN N'ĐANG HOẠT ĐỘNG'
                         ELSE N'NGƯNG HOẠT ĐỘNG'
                      END AS TrangThai,
                ISNULL(
                            MAX(CASE 
                                    WHEN ha.AnhDaiDien = 1 
                                    THEN ha.URL_Anh 
                            END),'default.jpg') AS HinhAnh,

                ISNULL(
                            DATEDIFF(
                                DAY,
                                MIN(l.NgayKhoiHanh),
                                MIN(l.NgayKetThuc)
                            ) + 1,
                            0
                        ) AS SoNgay,
                ISNULL(
                            DATEDIFF(
                                DAY,
                                MIN(l.NgayKhoiHanh),
                                MIN(l.NgayKetThuc)
                            ),
                            0
                        ) AS SoDem

                FROM Tour t
                    LEFT JOIN LichKhoiHanh l ON t.Id = l.IdTour
                    LEFT JOIN HinhAnhTour ha ON t.Id = ha.IdTour
                    GROUP BY
                        t.Id, t.TenTour,t.MoTa, t.GiaCoBan, t.TrangThai                         
                    ";
            //join với lịch khởi hành ( id và id_Tour trong bảng lịch khởi hành) 
            //join hình ảnh tour với tour để lấy hình ảnh tour 
            //nhóm theo id, tên, mô tả, giá, trạng thái 

            SqlCommand cmd = new SqlCommand(sql, _conn);
            //đọc từng dòng dữ liệu trả về.
            SqlDataReader dr = cmd.ExecuteReader();
            //dùng vòng while để đọc từng dòng 1 
            //lấ
            while (dr.Read())
            {
                //trong mỗi vòng lặp tạo 1 object mới để làm biến tạm 
                //lấy dưx liệu từ sql gán vào 

                Tourmodel tour = new Tourmodel();
                tour.IDTour = dr["IdTour"].ToString();
                tour.TenTour = dr["TenTour"].ToString();
                tour.MoTa = dr["Mota"].ToString();
                tour.GiaCoBan = Convert.ToDecimal(dr["GiaCoBan"]);
                // Kiểm tra nếu cột HinhAnh trong DB bị NULL thì tránh lỗi
                tour.HinhAnh = dr["HinhAnh"] != DBNull.Value ? dr["HinhAnh"].ToString() : "default.jpg";
                tour.SoNgay = Convert.ToInt32(dr["SoNgay"]);
                tour.SoDem = Convert.ToInt32(dr["SoDem"]);
                dsTour.Add(tour);

            }


            return dsTour;//trả ds về 
        }
        //tìm kiếm theo tỉnh thành
        //LOGIC: Khi nhập địa điểm vào(hiện tại đang là chọn tỉnh thành từ combobox) -> hiển thị các tour có ở tỉnh đó 
        public List<Tourmodel> TimKiemTour(string tinhThanh)
        {
            List<Tourmodel> dsTour =
                new List<Tourmodel>();
    //chọn các thuộc tính của tour thuộc bảng tour, sau đó kết nối với bảng tour_DiadjDanh và nối với bảng địa danh để biết được 1 tour có
    // thể đi qua những địa danh nào và đi qua tỉnh nào -> truy xuất dữ liệu tìm kiếm 
    //where -> lọc theo tỉnh 
            string sql = @"
        SELECT DISTINCT t.Id, t.TenTour, t.MoTa, t.GiaCoBan, t.TrangThai
        FROM Tour t
        INNER JOIN Tour_DiaDanh td ON t.Id = td.IdTour
        INNER JOIN DiaDanh dd ON td.IdDiaDanh = dd.Id
        WHERE dd.TinhThanh = @TinhThanh";

            SqlCommand cmd = new SqlCommand(sql, _conn);          
            cmd.Parameters.AddWithValue(
                "@TinhThanh",
                tinhThanh);

            _conn.Open();

            SqlDataReader dr =
                cmd.ExecuteReader();

            while (dr.Read())
            {
                Tourmodel tour = new Tourmodel();
                tour.IDTour = dr["Id"].ToString();
                tour.TenTour = dr["TenTour"].ToString();
                tour.MoTa = dr["MoTa"].ToString();
                tour.GiaCoBan = Convert.ToDecimal(dr["GiaCoBan"]);
                tour.TrangThai = dr["TrangThai"].ToString();
                dsTour.Add(tour);
            }
           return dsTour;
        }
    }
}

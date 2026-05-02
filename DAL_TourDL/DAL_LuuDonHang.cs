using DTO_TourDL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TourDL
{
    public class DAL_LuuDonHang
    {
        public bool LuuDonHang(DTO_DatTourTronGoi data)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // 1. Lưu thông tin người đặt vào bảng KhachHang (nếu chưa có)
                    // Tạm thời giả sử bạn đã có hàm lấy IdKhachHang từ SDT
                    int idKH = 1; // Ví dụ mặc định

                    // 2. Lưu vào bảng DonDatTour
                    string sqlDon = "INSERT INTO DonDatTour (MaDatTourBanDau, IdKhachHang, IdLichKhoiHanhBanDau, SoLuongNguoi, TongTienThanhToan, TrangThaiDon) " +
                                    "OUTPUT INSERTED.IdDonDatTour " + // Lấy ID vừa tự sinh
                                    "VALUES (@ma, @idKH, @idLich, @soLuong, @tongTien, N'ChoXacNhan')";
                    SqlCommand cmdDon = new SqlCommand(sqlDon, conn, trans);
                    cmdDon.Parameters.AddWithValue("@ma", "DT" + DateTime.Now.Ticks.ToString().Substring(10));
                    cmdDon.Parameters.AddWithValue("@idKH", idKH);
                    cmdDon.Parameters.AddWithValue("@idLich", data.IdLich);
                    cmdDon.Parameters.AddWithValue("@soLuong", data.SoLuong);
                    cmdDon.Parameters.AddWithValue("@tongTien", data.TongTien);
                    int idDonMoi = (int)cmdDon.ExecuteScalar();

                    // 3. Vòng lặp lưu danh sách người đi (DTO_NguoiDiTour)
                    foreach (var nguoi in data.DanhSachNguoiDi)
                    {
                        string sqlNguoi = "INSERT INTO DanhSachKhachHangTheoTour (IdDonDatTour, HoTen, CCCD) VALUES (@idDon, @ten, @cccd)";
                        SqlCommand cmdNguoi = new SqlCommand(sqlNguoi, conn, trans);
                        cmdNguoi.Parameters.AddWithValue("@idDon", idDonMoi);
                        cmdNguoi.Parameters.AddWithValue("@ten", nguoi.HoTen);
                        cmdNguoi.Parameters.AddWithValue("@cccd", nguoi.CCCD);
                        cmdNguoi.ExecuteNonQuery();
                    }

                    trans.Commit();
                    return true;
                }
                catch { trans.Rollback(); return false; }
            }
        }
    }
}

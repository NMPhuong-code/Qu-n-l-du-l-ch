using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO_TourDL;

namespace DAL_TourDL
{
    public class DAL_DatTour : DBConnect
    {
        public int LaySoChoConLai(int idLich)
        {
            int soChoConLai = 0;

            if (_conn.State == ConnectionState.Closed)
            {
                _conn.Open();
            }

            string sql = @"SELECT (lkh.SoChoToiDa - ISNULL(SUM(ddt.SoLuongNguoi), 0)) AS SoChoConLai
                           FROM LichKhoiHanh lkh
                           LEFT JOIN DonDatTour ddt ON lkh.Id = ddt.IdLichKhoiHanhBanDau AND ddt.TrangThaiDon != N'DaHuy'
                           WHERE lkh.Id = @IdLich
                           GROUP BY lkh.Id, lkh.SoChoToiDa";

            SqlCommand cmd = new SqlCommand(sql, _conn);
            cmd.Parameters.AddWithValue("@IdLich", idLich);

            object result = cmd.ExecuteScalar();
            if (result != null && result != DBNull.Value)
            {
                soChoConLai = Convert.ToInt32(result);
            }

            _conn.Close();
            return soChoConLai;
        }

        public bool ThucHienDatTour(DTO_DatTourTronGoi donHang)
        {
            if (_conn.State == ConnectionState.Closed)
            {
                _conn.Open();
            }

            SqlTransaction transaction = _conn.BeginTransaction();

            try
            {
                int idKhachHang = donHang.IdKhachHang;

                if (idKhachHang <= 0)
                {
                    string sqlKhach = @"INSERT INTO KhachHang (TenKH, SDT, Email, CCCD) 
                                        VALUES (@TenKH, @SDT, @Email, @CCCD);
                                        SELECT SCOPE_IDENTITY();";

                    SqlCommand cmdKhach = new SqlCommand(sqlKhach, _conn, transaction);
                    cmdKhach.Parameters.AddWithValue("@TenKH", donHang.TenNguoiDat);
                    cmdKhach.Parameters.AddWithValue("@SDT", donHang.SDTNguoiDat);
                    cmdKhach.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(donHang.EmailNguoiDat) ? (object)DBNull.Value : donHang.EmailNguoiDat);
                    cmdKhach.Parameters.AddWithValue("@CCCD", string.IsNullOrEmpty(donHang.CCCDNguoiDat) ? (object)DBNull.Value : donHang.CCCDNguoiDat);

                    idKhachHang = Convert.ToInt32(cmdKhach.ExecuteScalar());
                }

                string maDatTour = string.IsNullOrEmpty(donHang.MaDatTourBanDau)
                    ? "BK" + DateTime.Now.ToString("yyyyMMddHHmmssfff")
                    : donHang.MaDatTourBanDau;
                string sqlDonHang = @"INSERT INTO DonDatTour (MaDatTourBanDau, IdKhachHang, IdLichKhoiHanhBanDau, SoLuongNguoi, HinhThucDatTour, IdKhuyenMai, SoTienGiamKhuyenMai, TongTienGoc, TongTienThanhToan, TrangThaiDon, NgayDat)
                                      VALUES (@MaDatTour, @IdKhachHang, @IdLich, @SoLuong, @HinhThuc, @IdKhuyenMai, @SoTienGiam, @TongTienGoc, @TongTienThanhToan, @TrangThaiDon, @NgayDat);
                                      SELECT SCOPE_IDENTITY();";

                SqlCommand cmdDon = new SqlCommand(sqlDonHang, _conn, transaction);
                cmdDon.Parameters.AddWithValue("@MaDatTour", maDatTour);
                cmdDon.Parameters.AddWithValue("@IdKhachHang", idKhachHang);
                cmdDon.Parameters.AddWithValue("@IdLich", donHang.IdLich);
                cmdDon.Parameters.AddWithValue("@SoLuong", donHang.SoLuong);
                cmdDon.Parameters.AddWithValue("@HinhThuc", donHang.HinhThucDatTour);
                cmdDon.Parameters.AddWithValue("@IdKhuyenMai", donHang.IdKhuyenMai.HasValue ? (object)donHang.IdKhuyenMai.Value : DBNull.Value);
                cmdDon.Parameters.AddWithValue("@SoTienGiam", donHang.SoTienGiamKhuyenMai);
                cmdDon.Parameters.AddWithValue("@TongTienGoc", donHang.TongTienGoc);
                cmdDon.Parameters.AddWithValue("@TongTienThanhToan", donHang.TongTienThanhToan);
                cmdDon.Parameters.AddWithValue("@TrangThaiDon", donHang.TrangThaiDon);
                cmdDon.Parameters.AddWithValue("@NgayDat", donHang.NgayDat);

                int idDonDatTour = Convert.ToInt32(cmdDon.ExecuteScalar());

                foreach (var nguoiDi in donHang.DanhSachNguoiDi)
                {
                    string sqlNguoiDi = @"INSERT INTO NguoiDiTour (IdDonDatTour, TenNguoi, CCCD, SDT, Email, NgaySinh)
                                          VALUES (@IdDon, @TenNguoi, @CCCD, @SDT, @Email, @NgaySinh)";

                    SqlCommand cmdNguoi = new SqlCommand(sqlNguoiDi, _conn, transaction);
                    cmdNguoi.Parameters.AddWithValue("@IdDon", idDonDatTour);
                    cmdNguoi.Parameters.AddWithValue("@TenNguoi", nguoiDi.TenNguoi);
                    cmdNguoi.Parameters.AddWithValue("@CCCD", string.IsNullOrEmpty(nguoiDi.CCCD) ? (object)DBNull.Value : nguoiDi.CCCD);
                    cmdNguoi.Parameters.AddWithValue("@SDT", string.IsNullOrEmpty(nguoiDi.SDT) ? (object)DBNull.Value : nguoiDi.SDT);
                    cmdNguoi.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(nguoiDi.Email) ? (object)DBNull.Value : nguoiDi.Email);
                    cmdNguoi.Parameters.AddWithValue("@NgaySinh", nguoiDi.NgaySinh.HasValue ? (object)nguoiDi.NgaySinh.Value : DBNull.Value);

                    cmdNguoi.ExecuteNonQuery();
                }

                transaction.Commit();
                _conn.Close();
                return true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                _conn.Close();
                return false;
            }
        }
    }
}

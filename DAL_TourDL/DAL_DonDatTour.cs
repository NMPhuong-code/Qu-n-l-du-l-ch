using System;
using System.Data;
using System.Data.SqlClient;
using DTO_TourDL;

namespace DAL_TourDL
{
    public class DAL_DonDatTour : DBConnect
    {
        public string TaoMaDatTour()
        {
            return "BK" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        public bool ThemDonDatTour(DTO_DonDatTour don)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
                    INSERT INTO DonDatTour
                    (
                        MaDatTourBanDau,
                        IdKhachHang,
                        IdLichKhoiHanhBanDau,
                        SoLuongNguoi,
                        HinhThucDatTour,
                        IdKhuyenMai,
                        SoTienGiamKhuyenMai,
                        TongTienGoc,
                        TongTienThanhToan,
                        TrangThaiDon,
                        NgayDat
                    )
                    VALUES
                    (
                        @MaDatTourBanDau,
                        @IdKhachHang,
                        @IdLichKhoiHanhBanDau,
                        @SoLuongNguoi,
                        @HinhThucDatTour,
                        @IdKhuyenMai,
                        @SoTienGiamKhuyenMai,
                        @TongTienGoc,
                        @TongTienThanhToan,
                        @TrangThaiDon,
                        @NgayDat
                    )";

                SqlCommand cmd = new SqlCommand(sql, _conn);

                cmd.Parameters.AddWithValue("@MaDatTourBanDau", don.MaDatTourBanDau);
                cmd.Parameters.AddWithValue("@IdKhachHang", don.IdKhachHang);
                cmd.Parameters.AddWithValue("@IdLichKhoiHanhBanDau", don.IdLichKhoiHanhBanDau);
                cmd.Parameters.AddWithValue("@SoLuongNguoi", don.SoLuongNguoi);
                cmd.Parameters.AddWithValue("@HinhThucDatTour", don.HinhThucDatTour);

                if (don.IdKhuyenMai == null)
                    cmd.Parameters.AddWithValue("@IdKhuyenMai", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@IdKhuyenMai", don.IdKhuyenMai);

                cmd.Parameters.AddWithValue("@SoTienGiamKhuyenMai", don.SoTienGiamKhuyenMai);
                cmd.Parameters.AddWithValue("@TongTienGoc", don.TongTienGoc);
                cmd.Parameters.AddWithValue("@TongTienThanhToan", don.TongTienThanhToan);
                cmd.Parameters.AddWithValue("@TrangThaiDon", don.TrangThaiDon);
                cmd.Parameters.AddWithValue("@NgayDat", don.NgayDat);

                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }

        public DataTable GetDonDatTour()
        {
            string sql = @"
                SELECT 
                    ddt.Id,
                    ddt.MaDatTourBanDau,
                    ddt.IdKhachHang,
                    kh.TenKhachHang,
                    ddt.IdLichKhoiHanhBanDau,
                    t.TenTour,
                    lkh.NgayKhoiHanh,
                    ddt.SoLuongNguoi,
                    ddt.HinhThucDatTour,
                    ddt.TongTienGoc,
                    ddt.TongTienThanhToan,
                    ddt.TrangThaiDon,
                    ddt.NgayDat
                FROM DonDatTour ddt
                LEFT JOIN KhachHang kh ON ddt.IdKhachHang = kh.Id
                LEFT JOIN LichKhoiHanh lkh ON ddt.IdLichKhoiHanhBanDau = lkh.Id
                LEFT JOIN Tour t ON lkh.IdTour = t.Id
                ORDER BY ddt.Id DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
using System;
using System.Data;
using System.Data.SqlClient;
using DTO_TourDL;

namespace DAL_TourDL
{
    public class DAL_ThanhToan : DBConnect
    {
        public bool LuuThanhToan(
            DTO_ThanhToan tt)
        {
            try
            {
                if (_conn.State ==
                    ConnectionState.Closed)
                {
                    _conn.Open();
                }

                string sql = @"
                INSERT INTO ThanhToan
                (
                    IdDonDatTour,
                    LoaiThanhToan,
                    PhuongThucTT,
                    SoTien,
                    TrangThaiTT,
                    MaGiaoDich,
                    NgayThanhToan
                )
                VALUES
                (
                    @IdDonDatTour,
                    @LoaiThanhToan,
                    @PhuongThucTT,
                    @SoTien,
                    @TrangThaiTT,
                    @MaGiaoDich,
                    @NgayThanhToan
                )";

                SqlCommand cmd =
                    new SqlCommand(sql, _conn);

                cmd.Parameters.AddWithValue( "@IdDonDatTour",  tt.IdDonDatTour);
                cmd.Parameters.AddWithValue("@LoaiThanhToan", tt.LoaiThanhToan);
                cmd.Parameters.AddWithValue( "@PhuongThucTT",tt.PhuongThucTT);
                cmd.Parameters.AddWithValue("@SoTien", tt.SoTien);
                cmd.Parameters.AddWithValue("@TrangThaiTT",  tt.TrangThaiTT);
                cmd.Parameters.AddWithValue( "@MaGiaoDich",tt.MaGiaoDich);
                cmd.Parameters.AddWithValue( "@NgayThanhToan", tt.NgayThanhToan);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (_conn.State ==
                    ConnectionState.Open)
                {
                    _conn.Close();
                }
            }
        }
    }
}
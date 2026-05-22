using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_TourDL;

namespace DAL_TourDL
{
    public class DAL_HuyTour: DBConnect
    {
        public DataTable GetHuyTour()
        {
            string sql = @"
                SELECT 
                    ht.Id,
                    ht.IdDonDatTour,
                    ddt.MaDatTourBanDau,
                    ht.LyDo,
                    ht.NgayHuy,
                    ht.SoTienHoan,
                    ht.TrangThaiHoanTien
                FROM HuyTour ht
                JOIN DonDatTour ddt
                    ON ht.IdDonDatTour = ddt.Id
                ORDER BY ht.Id DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;
        }
        public int GetIdDonDatTourTheoMa(string maDatTourBanDau)
        {
            string sql = @"
                SELECT Id
                FROM DonDatTour
                WHERE MaDatTourBanDau = @MaDatTourBanDau";

            SqlCommand cmd = new SqlCommand(sql, _conn);

            cmd.Parameters.AddWithValue("@MaDatTourBanDau", maDatTourBanDau);

            if (_conn.State == ConnectionState.Closed)
                _conn.Open();

            object result = cmd.ExecuteScalar();

            _conn.Close();

            if (result == null || result == DBNull.Value)
                return 0;

            return Convert.ToInt32(result);
        }
        public DataTable GetThongTinDonDatTourTheoMa(string maDatTourBanDau)
        {
            string sql = @"
                SELECT 
                    ddt.Id,
                    ddt.MaDatTourBanDau,
                    ddt.SoLuongNguoi,
                    ddt.TongTienThanhToan,
                    ddt.IdLichKhoiHanhBanDau,
                    lkh.NgayKhoiHanh,
                    t.TenTour
                FROM DonDatTour ddt
                JOIN LichKhoiHanh lkh
                    ON ddt.IdLichKhoiHanhBanDau = lkh.Id
                JOIN Tour t
                    ON lkh.IdTour = t.Id
                WHERE ddt.MaDatTourBanDau = @MaDatTourBanDau";

            SqlCommand cmd = new SqlCommand(sql, _conn);

            cmd.Parameters.AddWithValue("@MaDatTourBanDau", maDatTourBanDau);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;
        }
        public bool ThemHuyTour(DTO_HuyTour ht)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
                    INSERT INTO HuyTour
                    (
                        IdDonDatTour,
                        LyDo,
                        NgayHuy,
                        SoTienHoan,
                        TrangThaiHoanTien
                    )
                    VALUES
                    (
                        @IdDonDatTour,
                        @LyDo,
                        @NgayHuy,
                        @SoTienHoan,
                        @TrangThaiHoanTien
                    )"; SqlCommand cmd = new SqlCommand(sql, _conn);

                cmd.Parameters.AddWithValue("@IdDonDatTour", ht.IdDonDatTour);
                cmd.Parameters.AddWithValue("@LyDo", ht.LyDo);
                cmd.Parameters.AddWithValue("@NgayHuy", ht.NgayHuy);
                cmd.Parameters.AddWithValue("@SoTienHoan", ht.SoTienHoan);
                cmd.Parameters.AddWithValue("@TrangThaiHoanTien", ht.TrangThaiHoanTien);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }
        public bool CapNhatTrangThaiHoanTien(int id, string trangThaiHoanTien)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
                    UPDATE HuyTour
                    SET TrangThaiHoanTien = @TrangThaiHoanTien
                    WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(sql, _conn);

                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@TrangThaiHoanTien", trangThaiHoanTien);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }
        public DataTable GetHuyTourChoXuLy()
        {
            string sql = @"
        SELECT 
            ht.Id,
            ht.IdDonDatTour,
            ddt.MaDatTourBanDau,
            ht.LyDo,
            ht.NgayHuy,
            ht.SoTienHoan,
            ht.TrangThaiHoanTien
        FROM HuyTour ht
        JOIN DonDatTour ddt
            ON ht.IdDonDatTour = ddt.Id
        WHERE ht.TrangThaiHoanTien = N'ChuaHoan'
        ORDER BY ht.Id DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;
        }
        public bool CapNhatThongTinHoanTien(DTO_HuyTour ht)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
            UPDATE HuyTour
            SET 
                LyDo = @LyDo,
                NgayHuy = @NgayHuy,
                SoTienHoan = @SoTienHoan,
                TrangThaiHoanTien = @TrangThaiHoanTien
            WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(sql, _conn);

                cmd.Parameters.AddWithValue("@Id", ht.Id);
                cmd.Parameters.AddWithValue("@LyDo", ht.LyDo);
                cmd.Parameters.AddWithValue("@NgayHuy", ht.NgayHuy);
                cmd.Parameters.AddWithValue("@SoTienHoan", ht.SoTienHoan);
                cmd.Parameters.AddWithValue("@TrangThaiHoanTien", ht.TrangThaiHoanTien);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }

    }
}

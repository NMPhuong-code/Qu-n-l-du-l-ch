using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using DTO_TourDL;


namespace DAL_TourDL
{
    public class DAL_Tour : DBConnect
    {
        public List<Tourmodel> GetAllTour()
        {
            List<Tourmodel> dsTour = new List<Tourmodel>();

            string sql = @"
                SELECT 
                    t.Id,
                    t.TenTour,
                    t.MoTa,
                    t.GiaCoBan,
                    t.TrangThai,
                    ISNULL(ha.URL_Anh, 'default.jpg') AS HinhAnh
                FROM Tour t
                OUTER APPLY
                (
                    SELECT TOP 1 URL_Anh
                    FROM HinhAnhTour
                    WHERE IdTour = t.Id
                      AND AnhDaiDien = 1
                ) ha
                WHERE t.TrangThai = 1";

            SqlCommand cmd = new SqlCommand(sql, _conn);

            if (_conn.State == ConnectionState.Closed)
                _conn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Tourmodel tour = new Tourmodel();

                tour.Id = Convert.ToInt32(dr["Id"]);
                tour.TenTour = dr["TenTour"].ToString();
                tour.MoTa = dr["MoTa"].ToString();
                tour.GiaCoBan = Convert.ToDecimal(dr["GiaCoBan"]);
                tour.TrangThai = Convert.ToBoolean(dr["TrangThai"]);
                tour.HinhAnh = dr["HinhAnh"].ToString();

                tour.IdLich = 0;
                tour.SoChoConTrong = 0;

                dsTour.Add(tour);
            }

            dr.Close();
            _conn.Close();

            return dsTour;
        }

        public List<Tourmodel> TimKiemTour(
    string tinhThanh,
    DateTime? ngayDi,
    decimal? nganSach)
        {
            List<Tourmodel> dsTour = new List<Tourmodel>();

            string sql = @"
    SELECT 
        t.Id,
        t.TenTour,
        t.MoTa,
        t.GiaCoBan,
        t.TrangThai,

        lkh.Id AS IdLich,
        lkh.NgayKhoiHanh,

        (
            ISNULL(lkh.SoChoToiDa, 0)
            - ISNULL(DA_DAT.TongDaDat, 0)
        ) AS SoChoConTrong,

        ISNULL(ha.URL_Anh, 'default.jpg') AS HinhAnh

    FROM Tour t

    INNER JOIN Tour_DiaDanh td
        ON t.Id = td.IdTour

    INNER JOIN DiaDanh dd
        ON td.IdDiaDanh = dd.Id

    INNER JOIN LichKhoiHanh lkh
        ON t.Id = lkh.IdTour

    LEFT JOIN
    (
        SELECT 
            IdLichKhoiHanhBanDau,
            SUM(SoLuongNguoi) AS TongDaDat
        FROM DonDatTour
        WHERE TrangThaiDon = N'Đã thanh toán'
        GROUP BY IdLichKhoiHanhBanDau
    ) DA_DAT
        ON lkh.Id = DA_DAT.IdLichKhoiHanhBanDau

    OUTER APPLY
    (
        SELECT TOP 1 URL_Anh
        FROM HinhAnhTour
        WHERE IdTour = t.Id
        AND AnhDaiDien = 1
    ) ha

    WHERE 
        dd.TinhThanh = @TinhThanh

        AND (
    @NgayDi IS NULL
    OR CAST(lkh.NgayKhoiHanh AS DATE)
       = CAST(@NgayDi AS DATE)
)

        AND (
            @NganSach IS NULL
            OR t.GiaCoBan <= @NganSach
        )

        AND t.TrangThai = 1

        AND (
            ISNULL(lkh.SoChoToiDa, 0)
            - ISNULL(DA_DAT.TongDaDat, 0)
        ) > 0";

            SqlCommand cmd = new SqlCommand(sql, _conn);

            cmd.Parameters.AddWithValue("@TinhThanh", tinhThanh);
            if (ngayDi.HasValue)
            {
                cmd.Parameters.AddWithValue(
                    "@NgayDi",
                    ngayDi.Value.Date);
            }
            else
            {
                cmd.Parameters.AddWithValue(
                    "@NgayDi",
                    DBNull.Value);
            }

            if (nganSach.HasValue)
                cmd.Parameters.AddWithValue("@NganSach", nganSach.Value);
            else
                cmd.Parameters.AddWithValue("@NganSach", DBNull.Value);

            if (_conn.State == ConnectionState.Closed)
                _conn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Tourmodel tour = new Tourmodel();

                tour.Id = Convert.ToInt32(dr["Id"]);
                tour.TenTour = dr["TenTour"].ToString();
                tour.MoTa = dr["MoTa"].ToString();
                tour.GiaCoBan = Convert.ToDecimal(dr["GiaCoBan"]);
                tour.TrangThai = Convert.ToBoolean(dr["TrangThai"]);
                tour.HinhAnh = dr["HinhAnh"].ToString();

                tour.IdLich = Convert.ToInt32(dr["IdLich"]);

                tour.SoChoConTrong =
                    Convert.ToInt32(dr["SoChoConTrong"]);
                tour.NgayKhoiHanh =
                Convert.ToDateTime(dr["NgayKhoiHanh"]);

                dsTour.Add(tour);
            }

            dr.Close();
            _conn.Close();

            return dsTour;
        }

        public bool LuuDonDatTour(DTO_DatTourTronGoi don)
        {
            if (_conn.State == ConnectionState.Closed)
                _conn.Open();

            SqlTransaction tran = _conn.BeginTransaction();

            try
            {
                string sqlCheck = @"
                    SELECT 
                        lkh.SoChoToiDa - ISNULL(DA_DAT.DaDat, 0) AS ChoConTrong
                    FROM LichKhoiHanh lkh WITH (UPDLOCK, HOLDLOCK)
                    LEFT JOIN
                    (
                        SELECT 
                            IdLichKhoiHanhBanDau,
                            SUM(SoLuongNguoi) AS DaDat
                        FROM DonDatTour
                        WHERE TrangThaiDon = N'Đã thanh toán'
                        GROUP BY IdLichKhoiHanhBanDau
                    ) DA_DAT
                        ON lkh.Id = DA_DAT.IdLichKhoiHanhBanDau
                    WHERE lkh.Id = @IdLich";

                SqlCommand cmdCheck = new SqlCommand(sqlCheck, _conn, tran);
                cmdCheck.Parameters.AddWithValue("@IdLich", don.IdLich);

                object checkResult = cmdCheck.ExecuteScalar();

                int choConTrong = checkResult != null && checkResult != DBNull.Value
                    ? Convert.ToInt32(checkResult)
                    : 0;


                if (choConTrong < don.SoLuong)
                {
                    throw new Exception(
        "IdLich: " + don.IdLich
        + "\nChoConTrong: " + choConTrong
        + "\nSoLuong: " + don.SoLuong);
                }


                string sqlInsert = @"
                    INSERT INTO DonDatTour 
                    (   MaDatTourBanDau,
                        IdKhachHang,
                        IdLichKhoiHanhBanDau,
                        SoLuongNguoi,
                        HinhThucDatTour,
                        TongTienGoc,
                        TongTienThanhToan,
                        TrangThaiDon,
                        NgayDat
                    )
                    VALUES 
                    (   @MaDatTourBanDau,
                        @IdKhachHang,
                        @IdLichKhoiHanhBanDau,
                        @SoLuongNguoi,
                        @HinhThucDatTour,
                        @TongTienGoc,
                        @TongTienThanhToan,
                        @TrangThaiDon,
                        @NgayDat
                    )";

                SqlCommand cmdInsert = new SqlCommand(sqlInsert, _conn, tran);
                string maDon = "BK_" +DateTime.Now.ToString("yyyyMMddHHmmss");

                int maKH = don.IdKhachHang > 0 ? don.IdKhachHang : 1;
                if (string.IsNullOrEmpty(don.MaDatTourBanDau))
                {
                    don.MaDatTourBanDau = "BK" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                }

                cmdInsert.Parameters.AddWithValue("@MaDatTourBanDau", don.MaDatTourBanDau);
                cmdInsert.Parameters.AddWithValue("@IdKhachHang", maKH);
                cmdInsert.Parameters.AddWithValue("@IdLichKhoiHanhBanDau", don.IdLich);
                cmdInsert.Parameters.AddWithValue("@SoLuongNguoi", don.SoLuong);
                cmdInsert.Parameters.AddWithValue("@HinhThucDatTour", don.HinhThucDatTour ?? (object)DBNull.Value);
                cmdInsert.Parameters.AddWithValue("@TongTienGoc", don.TongTienGoc);
                cmdInsert.Parameters.AddWithValue("@TongTienThanhToan", don.TongTienThanhToan);
                cmdInsert.Parameters.AddWithValue("@TrangThaiDon", don.TrangThaiDon ?? (object)DBNull.Value);
                cmdInsert.Parameters.AddWithValue("@NgayDat", don.NgayDat);

                cmdInsert.ExecuteNonQuery();

                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();

                throw;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }
        public bool themTour(Tourmodel tour)
        {
            try
            {
                _conn.Open();

                string sql = string.Format(
                    "INSERT INTO Tour(TenTour, MoTa, GiaCoBan, TrangThai) " +
                    "VALUES (N'{0}', N'{1}', {2}, {3})",

                    tour.TenTour,
                    tour.MoTa,
                    tour.GiaCoBan,
                    tour.TrangThai
                );

                SqlCommand cmd =
                    new SqlCommand(sql, _conn);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch
            {

            }
            finally
            {
                _conn.Close();
            }

            return false;
        }
        public bool xoaTour(int id)
        {
            try
            {
                _conn.Open();

                string sql =
                    "DELETE FROM Tour WHERE Id = " + id;

                SqlCommand cmd =
                    new SqlCommand(sql, _conn);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch
            {

            }
            finally
            {
                _conn.Close();
            }

            return false;
        }
        public bool suaTour(Tourmodel tour)
        {
            try
            {
                _conn.Open();

                string sql = string.Format(
                    "UPDATE Tour SET " +
                    "TenTour = N'{0}', " +
                    "MoTa = N'{1}', " +
                    "GiaCoBan = {2}, " +
                    "TrangThai = {3} " +
                    "WHERE Id = {4}",

                    tour.TenTour,
                    tour.MoTa,
                    tour.GiaCoBan,
                    tour.TrangThai,
                    tour.Id
                );

                SqlCommand cmd =
                    new SqlCommand(sql, _conn);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch
            {

            }
            finally
            {
                _conn.Close();
            }

            return false;
     }

        public DataTable LayLichSuTour(int idKH)
        {
            DataTable dt = new DataTable();
            if (_conn.State == ConnectionState.Closed) _conn.Open();
            try
            {
                string sql = @"SELECT 
                        d.Id,
                        t.TenTour,
                        l.NgayKhoiHanh,
                        d.TrangThaiDon
                       FROM DonDatTour d
                       INNER JOIN LichKhoiHanh l ON d.IdLichKhoiHanhBanDau = l.Id
                       INNER JOIN Tour t ON l.IdTour = t.Id
                       WHERE d.IdKhachHang = @Id
                       ORDER BY l.NgayKhoiHanh DESC";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@Id", idKH);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL: " + ex.Message); }
            finally { _conn.Close(); }
            return dt;
        }
        public bool XuLyHuyTourVaoDB(int idDon, string lyDo)
        {
            if (_conn.State == ConnectionState.Closed)
                _conn.Open();

            SqlTransaction trans = _conn.BeginTransaction();

            try
            {
                // Chèn đúng cấu trúc bảng HuyTour của bạn (Có cột TrangThaiDuyet)
                string sqlHuy = @"INSERT INTO HuyTour (IdDonDatTour, LyDo, NgayHuy, SoTienHoan, TrangThaiHoanTien, TrangThaiDuyet) 
                                  VALUES (@IdDon, @LyDo, GETDATE(), 0, NULL, N'Chờ duyệt')";

                SqlCommand cmdHuy = new SqlCommand(sqlHuy, _conn, trans);
                cmdHuy.Parameters.AddWithValue("@IdDon", idDon);
                cmdHuy.Parameters.AddWithValue("@LyDo", lyDo);
                cmdHuy.ExecuteNonQuery();

                // Cập nhật trạng thái đơn hàng gốc sang trạng thái 'Chờ duyệt hủy'
                string sqlDon = "UPDATE DonDatTour SET TrangThaiDon = N'Chờ duyệt hủy' WHERE Id = @IdDon";
                SqlCommand cmdDon = new SqlCommand(sqlDon, _conn, trans);
                cmdDon.Parameters.AddWithValue("@IdDon", idDon);
                cmdDon.ExecuteNonQuery();

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                Console.WriteLine("Lỗi SQL thực thi hủy tại DAL: " + ex.Message);
                return false;
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
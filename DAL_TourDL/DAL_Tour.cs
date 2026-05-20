using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                    (
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
                    (
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

                int maKH = don.IdKhachHang > 0 ? don.IdKhachHang : 1;

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
    }
}
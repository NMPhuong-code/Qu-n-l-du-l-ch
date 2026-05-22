using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_TourDL;

namespace DAL_TourDL
{
    public class DAL_PhanBoDatTour: DBConnect
    {

        public List<DTO_PhanBoDatTour> GetPhanBoDatTour()
        {
            _conn.Open();
            List<DTO_PhanBoDatTour> ds =
                new List<DTO_PhanBoDatTour>();

            string sql = @"
                SELECT Id, MaDatTourThucTe, IdDonDatTour,
                       IdLichKhoiHanhThucTe, SoLuongPhanBo,
                       KieuXuLy, TrangThai
                FROM PhanBoDatTour";

            SqlCommand cmd = new SqlCommand(sql, _conn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                DTO_PhanBoDatTour pb = new DTO_PhanBoDatTour();
                pb.Id =Convert.ToInt32(rd["Id"]);
                pb.MaDatTourThucTe = rd["MaDatTourThucTe"].ToString();
                pb.IdDonDatTour = Convert.ToInt32(rd["IdDonDatTour"]);
                pb.IdLichKhoiHanhThucTe = Convert.ToInt32(rd["IdLichKhoiHanhThucTe"]);
                pb.SoLuongPhanBo =  Convert.ToInt32(rd["SoLuongPhanBo"]);
                pb.KieuXuLy = rd["KieuXuLy"].ToString();
                pb.TrangThai = rd["TrangThai"].ToString();
                ds.Add(pb);
            }
            rd.Close();
            _conn.Close();
            return ds;
        }
        public bool themPhanBoDatTour(DTO_PhanBoDatTour pb)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
            INSERT INTO PhanBoDatTour
            (
                MaDatTourThucTe,
                IdDonDatTour,
                IdLichKhoiHanhThucTe,
                SoLuongPhanBo,
                KieuXuLy,
                TrangThai
            )
            VALUES
            (
                @MaDatTourThucTe,
                @IdDonDatTour,
                @IdLichKhoiHanhThucTe,
                @SoLuongPhanBo,
                @KieuXuLy,
                @TrangThai
            )";

                SqlCommand cmd = new SqlCommand(sql, _conn);

                cmd.Parameters.AddWithValue("@MaDatTourThucTe", pb.MaDatTourThucTe);
                cmd.Parameters.AddWithValue("@IdDonDatTour", pb.IdDonDatTour);
                cmd.Parameters.AddWithValue("@IdLichKhoiHanhThucTe", pb.IdLichKhoiHanhThucTe);
                cmd.Parameters.AddWithValue("@SoLuongPhanBo", pb.SoLuongPhanBo);
                cmd.Parameters.AddWithValue("@KieuXuLy", pb.KieuXuLy);
                cmd.Parameters.AddWithValue("@TrangThai", pb.TrangThai);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw;

            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }
        public bool suaPhanBoDatTour(DTO_PhanBoDatTour pb)
        {
            try
            {
                _conn.Open();

                string sql =
                    "UPDATE PhanBoDatTour SET " +
                    "MaDatTourThucTe = N'" + pb.MaDatTourThucTe + "', " +
                    "IdDonDatTour = " + pb.IdDonDatTour + ", " +
                    "IdLichKhoiHanhThucTe = " + pb.IdLichKhoiHanhThucTe + ", " +
                    "SoLuongPhanBo = " + pb.SoLuongPhanBo + ", " +
                    "KieuXuLy = N'" + pb.KieuXuLy + "', " +
                    "TrangThai = N'" + pb.TrangThai + "' " +
                    "WHERE Id = " + pb.Id;

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
        public bool xoaPhanBoDatTour(int id)
        {
            try
            {
                _conn.Open();

                string sql =
                    "DELETE FROM PhanBoDatTour WHERE Id = " + id;

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
        public DataTable GetLichCungTourTheoDonDatTour(int idDonDatTour)
        {
            string sql = @"
        SELECT 
            lkh2.Id,
            CONVERT(nvarchar(20), lkh2.NgayKhoiHanh, 103)
            + N' đến '
            + CONVERT(nvarchar(20), lkh2.NgayKetThuc, 103)
            AS TenHienThi
        FROM DonDatTour ddt
        JOIN LichKhoiHanh lkhCu 
            ON ddt.IdLichKhoiHanhBanDau = lkhCu.Id
        JOIN LichKhoiHanh lkh2 
            ON lkh2.IdTour = lkhCu.IdTour
        WHERE ddt.Id = @IdDonDatTour
        ORDER BY lkh2.NgayKhoiHanh";

            SqlCommand cmd = new SqlCommand(sql, _conn);
            cmd.Parameters.AddWithValue("@IdDonDatTour", idDonDatTour);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public int GetIdLichBanDauTheoDonDatTour(int idDonDatTour)
        {
            string sql = @"
        SELECT IdLichKhoiHanhBanDau
        FROM DonDatTour
        WHERE Id = @IdDonDatTour";

            SqlCommand cmd = new SqlCommand(sql, _conn);

            cmd.Parameters.AddWithValue("@IdDonDatTour", idDonDatTour);

            _conn.Open();

            object result = cmd.ExecuteScalar();

            _conn.Close();

            if (result == null || result == DBNull.Value)
                return 0;

            return Convert.ToInt32(result);
        }
        public DataTable GetPhanBoDangXuLy()
        {
            string sql = @"
        SELECT 
            Id,
            MaDatTourThucTe,
            IdDonDatTour,
            IdLichKhoiHanhThucTe,
            SoLuongPhanBo,
            KieuXuLy,
            TrangThai
        FROM PhanBoDatTour
       WHERE TrangThai = N'ChoXuLy'
        ORDER BY Id DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;
        }
        public bool CapNhatTrangThaiPhanBo(int id, string trangThai)
        {
            try
            {
                _conn.Open();

                string sql =
                    "UPDATE PhanBoDatTour SET " +
                    "TrangThai = N'" + trangThai + "' " +
                    "WHERE Id = " + id;

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
        public DataTable GetYeuCauTheoDonDatTour(int idDonDatTour)
        {
            string sql = @"
        SELECT 
            MaDatTourThucTe,
            IdDonDatTour,
            IdLichKhoiHanhThucTe,
            SoLuongPhanBo,
            KieuXuLy,
            TrangThai
        FROM PhanBoDatTour
        WHERE IdDonDatTour = @IdDonDatTour
        ORDER BY Id DESC";

            SqlCommand cmd = new SqlCommand(sql, _conn);

            cmd.Parameters.AddWithValue("@IdDonDatTour", idDonDatTour);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

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

            
                _conn.Open();

            object result = cmd.ExecuteScalar();

            _conn.Close();

            if (result == null || result == DBNull.Value)
                return 0;

            return Convert.ToInt32(result);
        }
        public bool CapNhatConstraintKieuXuLy()
        {
            try
            {
          
                    _conn.Open();

                string sql = @"
            DECLARE @ConstraintName nvarchar(200);

            SELECT @ConstraintName = con.name
            FROM sys.check_constraints con
            JOIN sys.columns col
                ON con.parent_object_id = col.object_id
               AND con.parent_column_id = col.column_id
            WHERE OBJECT_NAME(con.parent_object_id) = 'PhanBoDatTour'
              AND col.name = 'KieuXuLy';

            IF @ConstraintName IS NOT NULL
            BEGIN
                EXEC('ALTER TABLE PhanBoDatTour DROP CONSTRAINT ' + @ConstraintName);
            END;

            ALTER TABLE PhanBoDatTour
            ADD CONSTRAINT CK_PhanBoDatTour_KieuXuLy
            CHECK (
                KieuXuLy IN (
                    N'BinhThuong',
                    N'Tach',
                    N'Ghep',
                    N'Ghep_KH',
                    N'Ghep_NV',
                    N'Tach_ChuyenLich',
                    N'Tach_DiLe',
                    N'TachLe_GiuaTour'
                )
            );
        ";

                SqlCommand cmd = new SqlCommand(sql, _conn);

                cmd.ExecuteNonQuery();

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
    }


    }

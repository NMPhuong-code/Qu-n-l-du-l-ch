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
    public class DAL_NguoiDung : DBConnect
    {
        public List<DTO_NguoiDung> getNguoiDung()
        {
            List<DTO_NguoiDung> ds = new List<DTO_NguoiDung>();
            _conn.Open();
            string sql = @" SELECT Id, IdTaiKhoan, TenKH, Email, SDT, CCCD
                FROM KhachHang";
            SqlCommand cmd = new SqlCommand(sql, _conn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                DTO_NguoiDung nd = new DTO_NguoiDung();
                nd.Id = Convert.ToInt32(rd["Id"]);

                if (rd["IdTaiKhoan"] == DBNull.Value)
                    nd.IdTaiKhoan = null;
                else
                    nd.IdTaiKhoan = Convert.ToInt32(rd["IdTaiKhoan"]);
                nd.TenKH = rd["TenKH"].ToString();
                nd.Email = rd["Email"].ToString();
                nd.SDT = rd["SDT"].ToString();
                nd.CCCD = rd["CCCD"].ToString();
                ds.Add(nd);
            }
            _conn.Close();
            rd.Close();
            return ds;
        }
        public bool ThemKhachHang(DTO_NguoiDung kh)
        {
            try
            {
                _conn.Open();

                string sql = @"
            INSERT INTO KhachHang(IdTaiKhoan, TenKH, Email, SDT, CCCD)
            VALUES (@IdTaiKhoan, @TenKH, @Email, @SDT, @CCCD)";

                SqlCommand cmd = new SqlCommand(sql, _conn);

                if (kh.IdTaiKhoan == null)
                    cmd.Parameters.AddWithValue("@IdTaiKhoan", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@IdTaiKhoan", kh.IdTaiKhoan);

                cmd.Parameters.AddWithValue("@TenKH", kh.TenKH);
                cmd.Parameters.AddWithValue("@Email", kh.Email);
                cmd.Parameters.AddWithValue("@SDT", kh.SDT);
                cmd.Parameters.AddWithValue("@CCCD", kh.CCCD);

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
        public bool SuaKhachHang(DTO_NguoiDung kh)
        {
            try
            {
                _conn.Open();

                string sql = @"
                    UPDATE KhachHang
                    SET IdTaiKhoan = @IdTaiKhoan,
                        TenKH = @TenKH,
                        Email = @Email,
                        SDT = @SDT,
                        CCCD = @CCCD
                    WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(sql, _conn);

                cmd.Parameters.AddWithValue("@Id", kh.Id);

                if (kh.IdTaiKhoan == null)
                    cmd.Parameters.AddWithValue("@IdTaiKhoan", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@IdTaiKhoan", kh.IdTaiKhoan);

                cmd.Parameters.AddWithValue("@TenKH", kh.TenKH);
                cmd.Parameters.AddWithValue("@Email", kh.Email);
                cmd.Parameters.AddWithValue("@SDT", kh.SDT);
                cmd.Parameters.AddWithValue("@CCCD", kh.CCCD);

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
        public bool XoaKhachHang(int id)
        {
            try
            {
                _conn.Open();

                string sql =
                    "DELETE FROM KhachHang WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(sql, _conn);

                cmd.Parameters.AddWithValue("@Id", id);

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
        public List<DTO_NguoiDung> TimKiemKhachHang(string key)
        {
            List<DTO_NguoiDung> ds = new List<DTO_NguoiDung>();

            string sql = @"
                SELECT Id, IdTaiKhoan, TenKH, Email, SDT, CCCD
                FROM KhachHang
                WHERE TenKH LIKE @key
                   OR Email LIKE @key
                   OR SDT LIKE @key
                   OR CCCD LIKE @key";

            SqlCommand cmd = new SqlCommand(sql, _conn);

            cmd.Parameters.AddWithValue("@key", "%" + key + "%");

            _conn.Open();

            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                DTO_NguoiDung kh = new DTO_NguoiDung();

                kh.Id = Convert.ToInt32(rd["Id"]);
                if (rd["IdTaiKhoan"] == DBNull.Value)
                    kh.IdTaiKhoan = null;
                else
                    kh.IdTaiKhoan = Convert.ToInt32(rd["IdTaiKhoan"]);

                kh.TenKH = rd["TenKH"].ToString();
                kh.Email = rd["Email"].ToString();
                kh.SDT = rd["SDT"].ToString();
                kh.CCCD = rd["CCCD"].ToString();

                ds.Add(kh);
            }

            rd.Close();
            _conn.Close();

            return ds;
        }

    }
}

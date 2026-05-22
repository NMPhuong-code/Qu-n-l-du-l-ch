using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_TourDL;

namespace DAL_TourDL
{
    public class DAL_TaiKhoan : DBConnect
    {
        public List<DTO_TaiKhoan> getTaiKhoan()
        {
            List<DTO_TaiKhoan> ds = new List<DTO_TaiKhoan> ();
            _conn.Open ();
            string sql = @" SELECT tk.Id_TKhoan, tk.TenDangNhap,tk.MatKhau,tk.VaiTro,tk.TrangThai,tk.IdNhomQuyen, nq.TenNhomQuyen
             FROM TaiKhoan tk
             LEFT JOIN NhomQuyen nq
             ON tk.IdNhomQuyen = nq.Id";
            SqlCommand cmd = new SqlCommand (sql, _conn);
            SqlDataReader rd = cmd.ExecuteReader();
            while(rd.Read())
            {
                DTO_TaiKhoan tk = new DTO_TaiKhoan ();
                tk.Id_TKhoan = Convert.ToInt32(rd["Id_TKhoan"]);
                tk.TenDangNhap = rd["TenDangNhap"].ToString();
                tk.MatKhau= rd["MatKhau"].ToString ();
                tk.VaiTro = rd["VaiTro"].ToString();
                tk.TrangThai = rd["TrangThai"].ToString () ;
                tk.IdNhomQuyen = Convert.ToInt32(rd["IdNhomQuyen"]);
                tk.TenNhomQuyen = rd["TenNhomQuyen"].ToString() ;
                ds.Add(tk);
            }
            rd.Close ();
            _conn.Close ();
            return ds;

        }
        public bool themTaiKhoan(DTO_TaiKhoan tk)
        {
            try
            {
                _conn.Open();

                string sql = string.Format(
                    "INSERT INTO TaiKhoan(TenDangNhap, MatKhau, VaiTro, TrangThai, IdNhomQuyen) " +
                    "VALUES ('{0}', '{1}', N'{2}', N'{3}', {4})",
                    tk.TenDangNhap,
                    tk.MatKhau,
                    tk.VaiTro,
                    tk.TrangThai,
                    tk.IdNhomQuyen
                );

                SqlCommand cmd = new SqlCommand(sql, _conn);

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
        public bool suaTaiKhoan(DTO_TaiKhoan tk)
        {
            try
            {
                _conn.Open();

                string sql =
                    "UPDATE TaiKhoan SET " +
                    "TenDangNhap = '" + tk.TenDangNhap + "', " +
                    "MatKhau = '" + tk.MatKhau + "', " +
                    "VaiTro = N'" + tk.VaiTro + "', " +
                    "TrangThai = N'" + tk.TrangThai + "', " +
                    "IdNhomQuyen = " + tk.IdNhomQuyen + " " +
                    "WHERE Id_TKhoan = " + tk.Id_TKhoan;

                SqlCommand cmd = new SqlCommand(sql, _conn);

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
        public bool xoaTaiKhoan(int id)
        {
            try
            {
                _conn.Open();

                string sql =
                    "UPDATE TaiKhoan SET TrangThai = N'Đã khóa' " +
                    "WHERE Id_TKhoan = " + id;

                SqlCommand cmd = new SqlCommand(sql, _conn);

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
        public List<DTO_TaiKhoan> timKiemTaiKhoan(string key)
        {
            List<DTO_TaiKhoan> ds = new List<DTO_TaiKhoan>();

            _conn.Open();

            string sql = @"
        SELECT 
            tk.Id_TKhoan,
            tk.TenDangNhap,
            tk.MatKhau,
            tk.VaiTro,
            tk.TrangThai,
            tk.IdNhomQuyen,
            nq.TenNhomQuyen
        FROM TaiKhoan tk
        LEFT JOIN NhomQuyen nq 
        ON tk.IdNhomQuyen = nq.Id
        WHERE tk.TenDangNhap LIKE @TuKhoa
        OR tk.VaiTro LIKE @TuKhoa
        OR tk.TrangThai LIKE @TuKhoa";

            SqlCommand cmd = new SqlCommand(sql, _conn);

            cmd.Parameters.AddWithValue("@TuKhoa", "%" + key + "%");

            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                DTO_TaiKhoan tk = new DTO_TaiKhoan();

                tk.Id_TKhoan = Convert.ToInt32(rd["Id_TKhoan"]);
                tk.TenDangNhap = rd["TenDangNhap"].ToString();
                tk.MatKhau = rd["MatKhau"].ToString();
                tk.VaiTro = rd["VaiTro"].ToString();
                tk.TrangThai = rd["TrangThai"].ToString();
                tk.IdNhomQuyen = Convert.ToInt32(rd["IdNhomQuyen"]);
                tk.TenNhomQuyen = rd["TenNhomQuyen"].ToString();

                ds.Add(tk);
            }

            rd.Close();
            _conn.Close();

            return ds;
        }

        public DTO_TaiKhoan dangNhap(string tenDangNhap, string matKhau)
        {
            DTO_TaiKhoan tk = null;

            try
            {
                _conn.Open();

                string sql = @"
            SELECT tk.Id_TKhoan, tk.TenDangNhap, tk.MatKhau, tk.VaiTro, tk.TrangThai, tk.IdNhomQuyen, kh.Id AS IdKhachHang
            FROM TaiKhoan tk
            LEFT JOIN KhachHang kh ON tk.Id_TKhoan = kh.IdTaiKhoan
            WHERE tk.TenDangNhap = @TenDangNhap
            AND tk.MatKhau = @MatKhau";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhau", matKhau);

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    tk = new DTO_TaiKhoan();
                    tk.Id_TKhoan = Convert.ToInt32(rd["Id_TKhoan"]);
                    tk.TenDangNhap = rd["TenDangNhap"].ToString();
                    tk.MatKhau = rd["MatKhau"].ToString();
                    tk.VaiTro = rd["VaiTro"].ToString();
                    tk.TrangThai = rd["TrangThai"].ToString();
                    tk.IdNhomQuyen = Convert.ToInt32(rd["IdNhomQuyen"]);
                    if (rd["IdKhachHang"] != DBNull.Value)
                    {
                        tk.IdKhachHang = Convert.ToInt32(rd["IdKhachHang"]);

                        DTO_TourDL.DTO_LuuThongTin.IdKhachHangHienTai = Convert.ToInt32(rd["IdKhachHang"]);
                    }
                }

                rd.Close();
            }
            catch
            {
                tk = null;
            }
            finally
            {
                _conn.Close();
            }

            return tk;
        }

        public bool kiemTraTrungTenDangNhap(string tenDangNhap)
        {
            bool tonTai = false;

            try
            {
                _conn.Open();

                string sql = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 0)
                    tonTai = true;
            }
            catch
            {
                tonTai = true;
            }
            finally
            {
                _conn.Close();
            }

            return tonTai;
        }

        public bool dangKyKhachHang(string tenDangNhap, string matKhau, string tenKH, string email, string sdt, string cccd)
        {
            SqlTransaction tran = null;

            try
            {
                _conn.Open();
                tran = _conn.BeginTransaction();

                string sqlTaiKhoan = @"
            INSERT INTO TaiKhoan(TenDangNhap, MatKhau, VaiTro, TrangThai, IdNhomQuyen)
            OUTPUT INSERTED.Id_TKhoan
            VALUES(@TenDangNhap, @MatKhau, N'KhachHang', 1, 4)";

                SqlCommand cmdTK = new SqlCommand(sqlTaiKhoan, _conn, tran);
                cmdTK.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                cmdTK.Parameters.AddWithValue("@MatKhau", matKhau);

                int idTaiKhoan = Convert.ToInt32(cmdTK.ExecuteScalar());

                string sqlKhachHang = @"
            INSERT INTO KhachHang(IdTaiKhoan, TenKH, Email, SDT, CCCD)
            VALUES(@IdTaiKhoan, @TenKH, @Email, @SDT, @CCCD)";

                SqlCommand cmdKH = new SqlCommand(sqlKhachHang, _conn, tran);
                cmdKH.Parameters.AddWithValue("@IdTaiKhoan", idTaiKhoan);
                cmdKH.Parameters.AddWithValue("@TenKH", tenKH);
                cmdKH.Parameters.AddWithValue("@Email", email);
                cmdKH.Parameters.AddWithValue("@SDT", sdt);
                cmdKH.Parameters.AddWithValue("@CCCD", cccd);

                cmdKH.ExecuteNonQuery();

                tran.Commit();
                return true;
            }
            catch
            {
                if (tran != null)
                    tran.Rollback();

                return false;
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}

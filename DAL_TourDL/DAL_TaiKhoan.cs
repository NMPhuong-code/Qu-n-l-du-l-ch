using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_TourDL;

namespace DAL_TourDL
{
    public class DAL_TaiKhoan:DBConnect
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
    }
}

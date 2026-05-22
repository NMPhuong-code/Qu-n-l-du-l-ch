using DTO_TourDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TourDL
{
    public class DAL_HoiVien:DBConnect
    {

        public DTO_HoiVien LayHoiVienTheoId(int idKhachHang)
        {
            DTO_HoiVien hv = null;
            try
            {
                _conn.Open();
                string sql = @"
                    SELECT hv.IdKhachHang, hv.NgayDangKy, hv.DiemHienTai, hv.HangThanhVien,
                           kh.TenKH, kh.Email, kh.SDT
                    FROM HoiVien hv
                    INNER JOIN KhachHang kh ON hv.IdKhachHang = kh.Id
                    WHERE hv.IdKhachHang = @IdKhachHang";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@IdKhachHang", idKhachHang);

                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    hv = new DTO_HoiVien();
                    hv.IdKhachHang = Convert.ToInt32(rd["IdKhachHang"]);
                    hv.NgayDangKy = rd["NgayDangKy"] != DBNull.Value
                                        ? (DateTime?)Convert.ToDateTime(rd["NgayDangKy"]) : null;
                    hv.DiemHienTai = rd["DiemHienTai"] != DBNull.Value
                                        ? Convert.ToInt32(rd["DiemHienTai"]) : 0;
                    hv.HangThanhVien = rd["HangThanhVien"].ToString();
                    hv.TenKH = rd["TenKH"].ToString();
                    hv.Email = rd["Email"].ToString();
                    hv.SDT = rd["SDT"].ToString();
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi LayHoiVienTheoId: " + ex.Message);
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
            return hv;
        }

        public List<DTO_HoiVien> LayDanhSachHoiVien()
        {
            List<DTO_HoiVien> ds = new List<DTO_HoiVien>();
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();
                string sql = @"
                    SELECT hv.IdKhachHang, hv.NgayDangKy, hv.DiemHienTai, hv.HangThanhVien,
                           kh.TenKH, kh.Email, kh.SDT
                    FROM HoiVien hv
                    INNER JOIN KhachHang kh ON hv.IdKhachHang = kh.Id
                    ORDER BY hv.DiemHienTai DESC";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    DTO_HoiVien hv = new DTO_HoiVien();
                    hv.IdKhachHang = Convert.ToInt32(rd["IdKhachHang"]);
                    hv.NgayDangKy = rd["NgayDangKy"] != DBNull.Value
                                        ? (DateTime?)Convert.ToDateTime(rd["NgayDangKy"]) : null;
                    hv.DiemHienTai = rd["DiemHienTai"] != DBNull.Value
                                        ? Convert.ToInt32(rd["DiemHienTai"]) : 0;
                    hv.HangThanhVien = rd["HangThanhVien"].ToString();
                    hv.TenKH = rd["TenKH"].ToString();
                    hv.Email = rd["Email"].ToString();
                    hv.SDT = rd["SDT"].ToString();
                    ds.Add(hv);
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi LayDanhSachHoiVien: " + ex.Message);
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
            return ds;
        }

        public bool LaHoiVien(int idKhachHang)
        {
            bool result = false;
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM HoiVien WHERE IdKhachHang = @Id", _conn);
                cmd.Parameters.AddWithValue("@Id", idKhachHang);
                result = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
            catch { }
            finally { _conn.Close(); }
            return result;
        }
        public bool DangKyHoiVien(int idKhachHang)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
                    INSERT INTO HoiVien
                    (
                        IdKhachHang,
                        NgayDangKy,
                        DiemHienTai,
                        HangThanhVien
                    )
                    VALUES
                    (
                        @IdKhachHang,
                        GETDATE(),
                        0,
                        N'Tiềm Năng'
                    )";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@IdKhachHang", idKhachHang);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi DangKyHoiVien: " + ex.Message);
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }

        public bool CongDiem(int idKhachHang, int diemCong)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
                    UPDATE HoiVien
                    SET 
                        DiemHienTai = DiemHienTai + @DiemCong,
                        HangThanhVien =
                            CASE
                                WHEN DiemHienTai + @DiemCong >= 1500 THEN N'Platinum'
                                WHEN DiemHienTai + @DiemCong >= 500 THEN N'Gold'
                                WHEN DiemHienTai + @DiemCong > 0 THEN N'Silver'
                                ELSE N'Tiềm Năng'
                            END
                    WHERE IdKhachHang = @IdKhachHang";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@IdKhachHang", idKhachHang);
                cmd.Parameters.AddWithValue("@DiemCong", diemCong);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi CongDiem: " + ex.Message);
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_TourDL;

namespace DAL_TourDL
{
    public class DAL_LichKhoiHanh: DBConnect
    {
        public List<DTO_LichKhoiHanh> GetLichKhoiHanh() 
        {
            List<DTO_LichKhoiHanh> ds = new List<DTO_LichKhoiHanh>();
            _conn.Open();
            string sql = @" SELECT l.Id, l.IdTour, t.TenTour, l.NgayKhoiHanh, l.NgayKetThuc,
            l.SoChoToiThieu, l.SoChoToiDa, l.GiaThucTe,l.TrangThai, l.LoaiNgay
            FROM LichKhoiHanh l
            INNER JOIN Tour t ON l.IdTour = t.Id";
            SqlCommand cmd = new SqlCommand(sql, _conn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                DTO_LichKhoiHanh lich= new DTO_LichKhoiHanh();
                lich.Id = Convert.ToInt32(rd["Id"]);
                lich.IdTour = Convert.ToInt32(rd["IdTour"]);
                lich.TenTour = rd["TenTour"].ToString();
                lich.NgayKhoiHanh = Convert.ToDateTime(rd["NgayKhoiHanh"]);
                lich.NgayKetThuc = Convert.ToDateTime(rd["NgayKetThuc"]);
                lich.SoChoToiThieu = Convert.ToInt32(rd["SoChoToiThieu"]);
                lich.SoChoToiDa = Convert.ToInt32(rd["SoChoToiDa"]);
                lich.GiaThucTe = Convert.ToDecimal(rd["GiaThucTe"]);
                lich.TrangThai = rd["TrangThai"].ToString() ;
                lich.LoaiNgay = rd["LoaiNgay"].ToString();
                ds.Add(lich);
            }
            rd.Close();
            _conn.Close();
            return ds;
        }
        public bool themLichKhoiHanh(DTO_LichKhoiHanh lich)
        {
            try
            {
                _conn.Open();
                string sql = string.Format(
                "INSERT INTO LichKhoiHanh" +
                "IdTour, NgayKhoiHanh, NgayKetThuc, SoChoToiThieu, SoChoToiDa," +
                "GiaThucTe,TrangThai,LoaiNgay" +
                "VALUES ({0},'{1}','{2}',{3},{4},{5},N'{6}',N'{7}')",
                lich.IdTour,
                lich.NgayKhoiHanh.ToString("dd-MM-yyyy"),
                lich.NgayKetThuc.ToString("dd-MM-yyyy"),
                lich.SoChoToiThieu,
                lich.SoChoToiDa,
                lich.GiaThucTe,
                lich.TrangThai,
                lich.LoaiNgay) ;
                SqlCommand cmd = new SqlCommand(sql, _conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;

            }
            catch {  }
            finally { _conn.Close(); }
            return false;
        }
        public bool suaLichKhoiHanh(DTO_LichKhoiHanh lich)
        {
            try
            {
                _conn.Open();

                string sql = string.Format(
                    "UPDATE LichKhoiHanh SET " +
                    "IdTour = {0}, " +
                    "NgayKhoiHanh = '{1}', " +
                    "NgayKetThuc = '{2}', " +
                    "SoChoToiThieu = {3}, " +
                    "SoChoToiDa = {4}, " +
                    "GiaThucTe = {5}, " +
                    "TrangThai = N'{6}', " +
                    "LoaiNgay = N'{7}' " +
                    "WHERE Id = {8}",
                    lich.IdTour,
                    lich.NgayKhoiHanh.ToString("yyyy-MM-dd"),
                    lich.NgayKetThuc.ToString("yyyy-MM-dd"),
                    lich.SoChoToiThieu,
                    lich.SoChoToiDa,
                    lich.GiaThucTe,
                    lich.TrangThai,
                    lich.LoaiNgay,
                    lich.Id);

                SqlCommand cmd =
                    new SqlCommand(sql, _conn);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch { }
            finally { _conn.Close();}
            return false;
        }
        public bool xoaLichKhoiHanh(int id)
        {
            _conn.Open();

            string sql = @"
    UPDATE LichKhoiHanh
    SET TrangThai = N'Đã hủy'
    WHERE Id = @Id";

            SqlCommand cmd = new SqlCommand(sql, _conn);

            cmd.Parameters.AddWithValue("@Id", id);

            int kq = cmd.ExecuteNonQuery();

            _conn.Close();

            return kq > 0;
        }
        public List<DTO_LichKhoiHanh> TimKiemLich(string key)
        {
            List<DTO_LichKhoiHanh> ds =
                new List<DTO_LichKhoiHanh>();

            _conn.Open();

            string sql = @"
        SELECT 
            l.Id,
            l.IdTour,
            t.TenTour,
            l.NgayKhoiHanh,
            l.NgayKetThuc,
            l.SoChoToiThieu,
            l.SoChoToiDa,
            l.GiaThucTe,
            l.TrangThai,
            l.LoaiNgay
        FROM LichKhoiHanh l
        INNER JOIN Tour t ON l.IdTour = t.Id
        WHERE t.TenTour LIKE @TuKhoa";

            SqlCommand cmd =
                new SqlCommand(sql, _conn);

            cmd.Parameters.AddWithValue(
                "@TuKhoa",
                "%" + key + "%");

            SqlDataReader rd =
                cmd.ExecuteReader();

            while (rd.Read())
            {
                DTO_LichKhoiHanh lich =
                    new DTO_LichKhoiHanh();

                lich.Id = Convert.ToInt32(rd["Id"]);
                lich.IdTour = Convert.ToInt32(rd["IdTour"]);
                lich.TenTour = rd["TenTour"].ToString();
                lich.NgayKhoiHanh = Convert.ToDateTime(rd["NgayKhoiHanh"]);
                lich.NgayKetThuc = Convert.ToDateTime(rd["NgayKetThuc"]);
                lich.SoChoToiThieu = Convert.ToInt32(rd["SoChoToiThieu"]);
                lich.SoChoToiDa = Convert.ToInt32(rd["SoChoToiDa"]);
                lich.GiaThucTe = Convert.ToDecimal(rd["GiaThucTe"]);
                lich.TrangThai = rd["TrangThai"].ToString();
                lich.LoaiNgay = rd["LoaiNgay"].ToString();

                ds.Add(lich);
            }

            rd.Close();
            _conn.Close();

            return ds;
        }
    }
}

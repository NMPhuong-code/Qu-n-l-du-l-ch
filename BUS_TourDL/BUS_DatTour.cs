using DAL_TourDL;
using DTO_TourDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_TourDL
{
    public class BUS_DatTour
    {
        private DAL_DatTour dalDatTour = new DAL_DatTour();

        public int KiemTraSoChoConLai(int idLich)
        {
            return dalDatTour.LaySoChoConLai(idLich);
        }

        public string DatTour(DTO_DatTourTronGoi donHang)
        {
            if (donHang.SoLuong <= 0)
            {
                return "Số lượng người đăng ký tour phải lớn hơn 0.";
            }

            if (string.IsNullOrEmpty(donHang.TenNguoiDat) || string.IsNullOrEmpty(donHang.SDTNguoiDat))
            {
                return "Thông tin người đặt tour không được để trống.";
            }

            int soChoConLai = dalDatTour.LaySoChoConLai(donHang.IdLich);
            if (donHang.SoLuong > soChoConLai)
            {
                return "Không thể đặt tour. Lịch khởi hành này chỉ còn lại " + soChoConLai + " chỗ trống.";
            }

            if (donHang.DanhSachNguoiDi == null || donHang.DanhSachNguoiDi.Count != donHang.SoLuong)
            {
                return "Danh sách thông tin người đi tour không khớp với số lượng người đăng ký.";
            }

            donHang.TrangThaiDon = "ChoXuLy";
            donHang.NgayDat = DateTime.Now;

            bool ketQua = dalDatTour.ThucHienDatTour(donHang);
            if (ketQua)
            {
                return "Success";
            }
            else
            {
                return "Đã xảy ra lỗi trong quá trình lưu dữ liệu đặt tour vào hệ thống.";
            }
        }
    }
}

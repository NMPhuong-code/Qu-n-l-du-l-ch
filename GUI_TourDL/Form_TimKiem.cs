using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_TourDL;
using DTO_TourDL;

namespace GUI_TourDL
{
    public partial class Form_TimKiem : Form
    {
        string _diaDiem, _nganSach;
        DateTime _ngayDi; // Đổi biến này thành kiểu DateTime

        // Sửa hàm nhận dữ liệu để khớp với Form1
        public Form_TimKiem(string diaDiem, DateTime ngayDi, string nganSach)
        {
            InitializeComponent();
            _diaDiem = diaDiem;
            _ngayDi = ngayDi;
            _nganSach = nganSach;
        }

        private void HienThiKetQua()
        {
            FlowPanel_Tour.Controls.Clear();

            // 1. Gọi BUS xử lý toàn bộ logic nhức đầu (Truyền 3 từ khóa vào)
            BUS_Tour busTour = new BUS_Tour();
            var ketQua = busTour.TimKiemTour(_diaDiem, _ngayDi, _nganSach);

            // 2. Chỉ việc lấy kết quả vẽ ra màn hình
            foreach (var item in ketQua)
            {
                ListTour theTour = new ListTour();
                theTour.TenTour = item.TenTour;
                theTour.GiaTien = item.GiaCoBan.ToString("N0") + " VNĐ";
                theTour.ThoiGian = item.ThoiGianHienThi;


                FlowPanel_Tour.Controls.Add(theTour);
            }

            if (ketQua.Count == 0)
            {
                Label lblNoResult = new Label() { Text = "Không tìm thấy tour phù hợp!", AutoSize = true };
                FlowPanel_Tour.Controls.Add(lblNoResult);
            }
        }

        private void linkTrangchu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void Form_TimKiem_Load(object sender, EventArgs e)
        {
            if (_diaDiem != "" && _diaDiem != "-- Chọn địa điểm --")
            {
                // Viết hoa chữ cái đầu cho đẹp (VD: đà lạt -> Đà Lạt)
                string tenDiaDiemHienThi = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(_diaDiem.ToLower());

                lblKetquaTK.Text = "Du lịch " + tenDiaDiemHienThi;
            }
            else
            {
                lblKetquaTK.Text = "Tất cả các Tour";
            }

            // Chạy hàm hiển thị danh sách
            HienThiKetQua();
        }
    }
}

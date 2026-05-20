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
        DateTime? _ngayDi;

        public Form_TimKiem(string diaDiem, DateTime? ngayDi, string nganSach)
        {
            InitializeComponent();
            _diaDiem = diaDiem;
            _ngayDi = ngayDi;
            _nganSach = nganSach;
        }

        private void HienThiKetQua()
        {
            FlowPanel_Tour.Controls.Clear();

            BUS_Tour busTour = new BUS_Tour();
            var ketQua = busTour.TimKiemTour(_diaDiem, _ngayDi, _nganSach);

            foreach (var item in ketQua)
            {
                ListTour theTour = new ListTour();
                theTour.TenTour = item.TenTour;
                theTour.GiaTien = item.GiaCoBan.ToString("N0") + " VNĐ";
                theTour.Data = item;
                theTour.SoChoConTrong = item.SoChoConTrong;
                theTour.NgayKhoiHanh ="Khởi hành: "
                + item.NgayKhoiHanh.ToString("dd/MM/yyyy");
                theTour.OnSelect += TheTour_OnSelect;

                FlowPanel_Tour.Controls.Add(theTour);
            }

            if (ketQua.Count == 0)
            {
                Label lblNoResult = new Label() { Text = "Không tìm thấy tour phù hợp!", AutoSize = true };
                FlowPanel_Tour.Controls.Add(lblNoResult);
            }
        }

        private void TheTour_OnSelect(object sender, EventArgs e)
        {
            ListTour theTourClicked = (ListTour)sender;

            if (theTourClicked.Data != null)
            {
                Form_datTour formDatTour =
    new Form_datTour(theTourClicked.Data);
                formDatTour.StartPosition = FormStartPosition.CenterScreen;
                formDatTour.ShowDialog();

                HienThiKetQua();
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
                string tenDiaDiemHienThi = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(_diaDiem.ToLower());
                lblKetquaTK.Text = "Du lịch " + tenDiaDiemHienThi;
            }
            else
            {
                lblKetquaTK.Text = "Tất cả các Tour";
            }

            HienThiKetQua();
        }
    }
}
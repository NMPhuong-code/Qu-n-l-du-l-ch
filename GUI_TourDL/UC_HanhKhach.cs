using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_TourDL;
namespace GUI_TourDL
{
    public partial class UC_HanhKhach : UserControl
    {
        public UC_HanhKhach()
        {
            InitializeComponent();
        }
        public DTO_NguoiDiTour LayThongTin()
        {
            return new DTO_NguoiDiTour
            {
                HoTen = txtHoTen.Text, // Đảm bảo tên TextBox đúng như bạn đặt
                SDT = txtSDT.Text,
                CCCD = txtCCCD.Text,
                Email = txtEmail.Text,
                DiaChi = txtEmail.Text,
                NgaySinh= dtpNgaySinh.Value,

                // Nếu bạn có thêm Ngày sinh hay Email trong UC thì thêm vào đây
            };
        }

        private void UC_HanhKhach_Load(object sender, EventArgs e)
        {

        }

        
    }
}

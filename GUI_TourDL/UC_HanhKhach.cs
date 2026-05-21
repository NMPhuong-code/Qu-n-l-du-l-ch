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
                TenNguoi = txtHoTen.Text, // Đảm bảo tên TextBox đúng như bạn đặt
                SDT = txtSDT.Text,
                CCCD = txtCCCD.Text,
                Email = txtEmail.Text,
                NgaySinh= dtpNgaySinh.Value,

                // Nếu bạn có thêm Ngày sinh hay Email trong UC thì thêm vào đây
            };
        }
        public string TieuDeHanhKhach
        {
            get { return groupBoxHK.Text; }
            set { groupBoxHK.Text = value; }
        }
        public void ThietLapGiaoDienTreEm()
        {
            lblSDT.Visible = false;
            txtSDT.Visible = false;

            txtCCCD.Visible = false;
            textBox7.Visible = false;

            lblEmail.Visible = false;
            txtEmail.Visible = false;

            lblngSinh.Location = txtCCCD.Location;
            dtpNgaySinh.Location = textBox7.Location;
        }
        private void UC_HanhKhach_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

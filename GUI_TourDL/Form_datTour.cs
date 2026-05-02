using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_TourDL
{
    public partial class Form_datTour : Form
    {
        public Form_datTour()
        {
            InitializeComponent();
        }

        private void CapNhatDanhSachHanhKhach()
        {
            flpDSHanhKhach.Controls.Clear(); // Xóa sạch các khung cũ

            int tongSo = (int)numNguoiLon.Value + (int)numTreEm.Value;

            for (int i = 1; i <= tongSo; i++)
            {
                UC_HanhKhach uc = new UC_HanhKhach();
                // Bạn có thể chỉnh tiêu đề GroupBox trong UC cho đẹp (nếu có thuộc tính)
                flpDSHanhKhach.Controls.Add(uc);
            }
        }
        private void Form_datTour_Load(object sender, EventArgs e)
        {

        }
        private void numTreEm_ValueChanged(object sender, EventArgs e) => CapNhatDanhSachHanhKhach();
        private void numNguoiLon_ValueChanged(object sender, EventArgs e) => CapNhatDanhSachHanhKhach();
    }
}

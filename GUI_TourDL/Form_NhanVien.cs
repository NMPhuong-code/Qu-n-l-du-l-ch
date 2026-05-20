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
    public partial class Form_NhanVien : Form
    {
        public Form_NhanVien()
        {
            InitializeComponent();
        }

        private void Form_NhanVien_Load(object sender, EventArgs e)
        {
           
        }
        private void LoadControl(UserControl uc)
        {
            pnlContent.Controls.Clear();

            uc.Dock = DockStyle.Fill;

            pnlContent.Controls.Add(uc);
        }

        private void btnQuanLyTour_Click(object sender, EventArgs e)
        {
            UC_QuanLyTour uc = new UC_QuanLyTour();
            LoadControl(uc);
        }
    }
}

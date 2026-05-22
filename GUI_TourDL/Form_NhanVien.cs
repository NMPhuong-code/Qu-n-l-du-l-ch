using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace GUI_TourDL
{
    public partial class Form_NhanVien : Form
    {
        public Form_NhanVien()
        {
            InitializeComponent();

            if (DangMoBangDesigner())
            {
                return;
            }
        }

        private bool DangMoBangDesigner()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime
                   || this.DesignMode;
        }

        private void Form_NhanVien_Load(object sender, EventArgs e)
        {
            if (DangMoBangDesigner())
            {
                return;
            }
        }

        private void LoadControl(UserControl uc)
        {
            if (DangMoBangDesigner())
            {
                return;
            }

            if (uc == null)
            {
                return;
            }

            pnlContent.Controls.Clear();

            uc.Dock = DockStyle.Fill;

            pnlContent.Controls.Add(uc);
        }

        private void btnQuanLyTour_Click(object sender, EventArgs e)
        {
            if (DangMoBangDesigner())
            {
                return;
            }

            UC_QuanLyTour uc = new UC_QuanLyTour();
            LoadControl(uc);
        }

        private void btnLichKhoiHanh_Click(object sender, EventArgs e)
        {
            if (DangMoBangDesigner())
            {
                return;
            }

            UC_QuanLyLichKhoiHanh uc = new UC_QuanLyLichKhoiHanh();
            LoadControl(uc);
        }

        private void btnQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            if (DangMoBangDesigner())
            {
                return;
            }

            UC_QuanLyTaiKhoan uc = new UC_QuanLyTaiKhoan();
            LoadControl(uc);
        }

        private void btnQuanLyNguoiDung_Click(object sender, EventArgs e)
        {
            if (DangMoBangDesigner())
            {
                return;
            }

            UC_QuanLyNguoiDung uc = new UC_QuanLyNguoiDung();
            LoadControl(uc);
        }

        private void btnXuLyTour_Click(object sender, EventArgs e)
        {
            if (DangMoBangDesigner())
            {
                return;
            }

            UC_XuLyTour uc = new UC_XuLyTour();
            LoadControl(uc);
        }
    }
}
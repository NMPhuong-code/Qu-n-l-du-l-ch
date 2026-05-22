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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int idKhachHangLogined = 0; // Biến lưu ID khách hàng sau khi đăng nhập thành công
        public string tenKhachHangLogined = "";
        private DTO_TaiKhoan taiKhoanDangNhap = null;
        private void Form1_Load(object sender, EventArgs e) {
        //{
        //    cbDiaDiem.Items.Clear();
        //    cbDiaDiem.Items.Add("-- Chọn địa điểm --"); // Mục này mang số 0
        //    //cbDiaDiem.Items.Add("Đà Lạt");
        //    //cbDiaDiem.Items.Add("Hạ Long");
        //    //cbDiaDiem.Items.Add("Phú Quốc");
        //    //cbDiaDiem.Items.Add("Sapa");
        //    cbDiaDiem.SelectedIndex = 0; // Ép phần mềm chọn sẵn dòng số 0
        Bus_DiaDanh bus = new Bus_DiaDanh();
            cbDiaDiem.DataSource = bus.getDiaDanh();
            cbDiaDiem.DisplayMember = "TinhThanh";
            //cbDiaDiem.ValueMember= "Id";
            cbDiaDiem.DropDownStyle =ComboBoxStyle.DropDownList;
            // 2. Nạp danh sách Ngân sách
            cbNganSach.Items.Clear();
            cbNganSach.Items.Add("-- Chọn ngân sách --"); // Mục này mang số 0
            cbNganSach.Items.Add("Dưới 4 triệu");
            cbNganSach.Items.Add("Từ 4 - 6 triệu");
            cbNganSach.Items.Add("Trên 6 triệu");
            cbNganSach.SelectedIndex = 0; // Ép phần mềm chọn sẵn dòng số 0
            cbNganSach.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (cbDiaDiem.SelectedIndex < 0 || cbNganSach.SelectedIndex <= 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn Địa điểm và Ngân sách",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string diaDiem = cbDiaDiem.Text;

            string nganSach = cbNganSach.Text;

            // Lấy ngày đi đúng
            DateTime? ngayDi = null;

            if (cbNgayDi.Checked)
            {
                ngayDi = cbNgayDi.Value.Date;
            }

            // Mở form kết quả
            Form_TimKiem frmKetQua =
                new Form_TimKiem(
                diaDiem,
                ngayDi,
                nganSach);

            frmKetQua.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Form_DangNhap frm = new Form_DangNhap();
            frm.Owner = this;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                taiKhoanDangNhap = frm.taiKhoanDangNhap;

                btnLogin.Visible = false;
                btnTaiKhoan.Visible = true;
                btnTaiKhoan.Text = taiKhoanDangNhap.TenDangNhap;

                // Bật nút "Lịch sử đặt" hiển thị lên thanh menu
                btnDonDaDat.Visible = true;
                // Bật nút "Hội Viên" khi đăng nhập thành công
                btnHoiVien.Visible = true;
            }
        }

        private void cbDiaDiem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void DangXuat(object sender,EventArgs e)
        {
            taiKhoanDangNhap = null;
            btnTaiKhoan.Visible = false;
            btnLogin.Visible = true;

            // ĐĂNG XUẤT THÌ ẨN ĐI: Chuyển thành false để khách vãng lai không bấm được
            btnDonDaDat.Visible = false;
            btnHoiVien.Visible = false;

            btnTaiKhoan.Text = "";
            MessageBox.Show("Đăng xuất thành công!");
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            DialogResult rs =
        MessageBox.Show(
            "Bạn muốn đăng xuất?",
            "Xác nhận",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                taiKhoanDangNhap = null;
                btnTaiKhoan.Visible = false;

                btnLogin.Visible = true;
                btnDonDaDat.Visible = false;
                btnHoiVien.Visible = false;

                btnTaiKhoan.Text = "";

                MessageBox.Show(
                    "Đăng xuất thành công!");
            }
        }

        private void btnDonDaDat_Click(object sender, EventArgs e)
        {
            if (taiKhoanDangNhap != null)
            {
                int maKH = DTO_TourDL.DTO_LuuThongTin.IdKhachHangHienTai;
                string tenKH = taiKhoanDangNhap.TenDangNhap;

                // Truyền maKH chuẩn sang form hiển thị lịch sử
                Form_ChiTietDonDat f = new Form_ChiTietDonDat(maKH, tenKH);
                f.ShowDialog();
            }
        }

        private void btnHoiVien_Click(object sender, EventArgs e)
        {
            if (taiKhoanDangNhap != null)
            {
                Form_HoiVien f = new Form_HoiVien(taiKhoanDangNhap);
                f.ShowDialog();
            }
        }
    }
}

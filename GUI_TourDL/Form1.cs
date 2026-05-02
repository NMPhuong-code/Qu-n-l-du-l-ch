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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbDiaDiem.Items.Clear();
            cbDiaDiem.Items.Add("-- Chọn địa điểm --"); // Mục này mang số 0
            cbDiaDiem.Items.Add("Đà Lạt");
            cbDiaDiem.Items.Add("Hạ Long");
            cbDiaDiem.Items.Add("Phú Quốc");
            cbDiaDiem.Items.Add("Sapa");
            cbDiaDiem.SelectedIndex = 0; // Ép phần mềm chọn sẵn dòng số 0

            // 2. Nạp danh sách Ngân sách
            cbNganSach.Items.Clear();
            cbNganSach.Items.Add("-- Chọn ngân sách --"); // Mục này mang số 0
            cbNganSach.Items.Add("Dưới 4 triệu");
            cbNganSach.Items.Add("Từ 4 - 6 triệu");
            cbNganSach.Items.Add("Trên 6 triệu");
            cbNganSach.SelectedIndex = 0; // Ép phần mềm chọn sẵn dòng số 0


        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (cbDiaDiem.SelectedIndex <= 0 || cbNganSach.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn Địa điểm và Ngân sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // DÙNG .Text THAY VÌ .SelectedItem.ToString() SẼ KHÔNG BAO GIỜ BỊ LỖI VĂNG APP
            string diaDiem = cbDiaDiem.Text;
            string nganSach = cbNganSach.Text;

            // Lấy ngày đi
            DateTime ngayDi = cbNgayDi.Checked ? cbNgayDi.Value : DateTime.MinValue;

            // Mở Form kết quả
            Form_TimKiem frmKetQua = new Form_TimKiem(diaDiem, ngayDi, nganSach);
            frmKetQua.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Form_DangNhap frmDangNhap =new Form_DangNhap();
        }
    }
}

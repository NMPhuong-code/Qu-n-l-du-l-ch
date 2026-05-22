using BUS_TourDL;
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
    public partial class Form_ChiTietDonDat : Form
    {
        public Form_ChiTietDonDat()
        {
            InitializeComponent();
        }
        private BUS_Tour bus = new BUS_Tour();
        private int idKH;

        // Constructor nhận ID và Tên từ form trước truyền sang
        public Form_ChiTietDonDat(int maKH, string tenKH)
        {
            InitializeComponent();
            idKH = maKH;
            lblTenKhach.Text = "Xin chào: " + tenKH;
        }

        private void Form_ChiTietDonDat_Load(object sender, EventArgs e)
        {
            HienThiDuLieuTour();
        }

        void HienThiDuLieuTour()
        {
            DataTable dtGoc = bus.LayLichSuTour(idKH);
          
            DataView dvDonHienTai = new DataView(dtGoc);

            dvDonHienTai.RowFilter ="TrangThaiDon <> 'DaHuy'";
            dgvDonHienTai.DataSource = dvDonHienTai;       
            DataView dvLichSu = new DataView(dtGoc);
            dvLichSu.RowFilter = "TrangThaiDon='DaHuy'";
           dgvLichSu.DataSource =  dvLichSu;

            DinhDangGridView(dgvDonHienTai);
            DinhDangGridView(dgvLichSu);
        }

        void DinhDangGridView(DataGridView dgv)
        {
            if (dgv.DataSource == null || dgv.Columns.Count == 0) return;
            dgv.Columns["Id"].HeaderText = "Mã Đơn";
            dgv.Columns["TenTour"].HeaderText = "Tên Chuyến Đi";
            dgv.Columns["NgayKhoiHanh"].HeaderText = "Ngày Khởi Hành";
            dgv.Columns["TrangThaiDon"].HeaderText = "Trạng Thái";
            // Tự giãn cột
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Không cho thêm dòng trắng
            dgv.AllowUserToAddRows = false;

            // Chỉ đọc
            dgv.ReadOnly =  true;

            // Chọn nguyên hàng
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv.MultiSelect =false;
        }

        // Sự kiện click nút Yêu cầu hủy
        

        private void btnYeuCauHuyTour_Click(object sender, EventArgs e)
        {

            if (dgvDonHienTai.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn tour cần hủy!");
                return;
            }

            int idDon = Convert.ToInt32(dgvDonHienTai.CurrentRow.Cells["Id"].Value);

            // Bật Form_HuyTour lên (Form này chúng ta sẽ làm ở bước kế tiếp)
            Form_HuyTour f = new Form_HuyTour(idDon);
            if (f.ShowDialog() == DialogResult.OK)
            {
                HienThiDuLieuTour(); // Load lại dữ liệu nếu hủy thành công
            }
        }
    }
}

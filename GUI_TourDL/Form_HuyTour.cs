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
    public partial class Form_HuyTour : Form
    {
        public Form_HuyTour()
        {
            InitializeComponent();
        }
        private int idDonHang;
        private BUS_Tour bus = new BUS_Tour();

        // Sửa Constructor để nhận mã đơn từ Form danh sách truyền sang
        public Form_HuyTour(int idDon)
        {
            InitializeComponent();
            idDonHang = idDon;
        }

        private void Form_HuyTour_Load(object sender, EventArgs e)
        {
            // Hiển thị mã đơn lên label để khách biết đang hủy đơn nào
            lblThongTin.Text = "Nhập lý do hủy cho đơn hàng: #" + idDonHang;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string lyDo = txtLyDo.Text.Trim();

            if (string.IsNullOrEmpty(lyDo))
            {
                MessageBox.Show("Vui lòng nhập lý do hủy tour cụ thể trước khi xác nhận!", "Thông báo");
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn gửi yêu cầu hủy tour này không?", "Xác nhận hành động", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                // Gọi xuống tầng BUS để thực thi ghi nhận vào SQL Server
                if (bus.GuiYeuCauHuyTour(idDonHang, lyDo))
                {
                    MessageBox.Show("Gửi yêu cầu thành công! Vui lòng chờ nhân viên kiểm tra và phê duyệt.", "Thành công");
                    this.DialogResult = DialogResult.OK; // Trả về kết quả OK để báo cho Form danh sách biết
                    this.Close(); // Đóng form nhập lý do lại
                }
                else
                {
                    MessageBox.Show("Gửi yêu cầu thất bại. Vui lòng kiểm tra lại kết nối Database!");
                }
            }
        }
    }
}

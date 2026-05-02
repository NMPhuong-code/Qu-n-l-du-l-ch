using DTO_TourDL;
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
    public partial class ListTour : UserControl
    {
        // Biến lưu trữ đối tượng Tour để khi click vào sẽ lấy được toàn bộ data
        public Tourmodel Data { get; set; }

        // Định nghĩa một sự kiện Click riêng cho UserControl này
        public event EventHandler OnSelect;

        public ListTour()
        {
            InitializeComponent();

            // Đăng ký sự kiện click cho các thành phần con để bấm vào đâu cũng được
            this.Click += Item_Click;
            lblTenTour.Click += Item_Click;
            lblGiaTien.Click += Item_Click;
            lblThoiGian.Click += Item_Click;
            picTour.Click += Item_Click;
        }

        private void Item_Click(object sender, EventArgs e)
        {
            // Khi bấm vào thì kích hoạt sự kiện OnSelect
            OnSelect?.Invoke(this, e);
        }

        public string TenTour
        {
            get { return lblTenTour.Text; }
            set { lblTenTour.Text = value; }
        }

        public string GiaTien
        {
            get { return lblGiaTien.Text; }
            set { lblGiaTien.Text = value; }
        }

        public string ThoiGian
        {
            get { return lblThoiGian.Text; }
            set { lblThoiGian.Text = value; }
        }
        public Image AnhTour
        {
            get { return picTour.Image; }
            set { picTour.Image = value; }
        }
    private void ListTour_Load(object sender, EventArgs e)
        {

        }
    }
}

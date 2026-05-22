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
        private int _soChoConTrong;

        public Tourmodel Data { get; set; }

        public event EventHandler OnSelect;

        public ListTour()
        {
            InitializeComponent();
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

        public int SoChoConTrong
        {
            get { return _soChoConTrong; }
            set
            {
                _soChoConTrong = value;

                if (_soChoConTrong <= 0)
                {
                    SoChoCon.Text = "Hết chỗ!";
                    SoChoCon.ForeColor = Color.Red;
                    btn_datNgay.Enabled = false; // Khóa luôn nút không cho đặt nếu đã hết vé
                    btn_datNgay.BackColor = Color.Gray;
                }
                else
                {
                    SoChoCon.Text = "Số chỗ còn trống: " + _soChoConTrong.ToString();
                    SoChoCon.ForeColor = Color.Green;
                    btn_datNgay.Enabled = true;
                }
            }
        }

        public string NgayKhoiHanh
        {
            get { return lbl_ngayKHanh.Text; }

            set { lbl_ngayKHanh.Text = value; }
        }
        public Image AnhTour
        {
            get { return picTour.Image; }
            set { picTour.Image = value; }
        }

        private void ListTour_Load(object sender, EventArgs e)
        {
        }

        private void btn_datNgay_Click(object sender, EventArgs e)
        {
            OnSelect?.Invoke(this, e);
        }

        private void lblThoiGian_Click(object sender, EventArgs e)
        {

        }
    }
}
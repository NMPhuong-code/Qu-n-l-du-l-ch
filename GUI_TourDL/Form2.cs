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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            UC_QuanLyTaiKhoan uc =
        new UC_QuanLyTaiKhoan();
            uc.Dock = DockStyle.Fill;

            this.Controls.Add(uc);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}

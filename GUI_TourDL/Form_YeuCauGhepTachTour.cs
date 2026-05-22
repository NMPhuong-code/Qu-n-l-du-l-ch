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
    public partial class Form_YeuCauGhepTachTour : Form
    {
        BUS_PhanBoDatTour busPB = new BUS_PhanBoDatTour();
        BUS_LichKhoiHanh busLKH = new BUS_LichKhoiHanh();
        private int idDonDatTourDangChon = 0;
        public Form_YeuCauGhepTachTour()
        {
            InitializeComponent();
            TaoMaYeuCau();
            LoadLoaiYeuCau();
            cbLichKhoiHanhThucTe.DataSource = null;
        }
        private void TaoMaYeuCau()
        {
            txtMaDatTourThucTe.Text =
                "YC" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }
        private void LoadLoaiYeuCau()
        {
            cbLoaiYeuCau.Items.Clear();

            cbLoaiYeuCau.Items.Add("Ghép tour");
            cbLoaiYeuCau.Items.Add("Tách tour");

            cbLoaiYeuCau.SelectedIndex = 0;

            LoadHinhThucXuLy();
        }
        private void LoadHinhThucXuLy()
        {
            cbHinhThucXuLy.Items.Clear();

            if (cbLoaiYeuCau.Text == "Ghép tour")
            {
                cbHinhThucXuLy.Items.Add("Ghép sang lịch khác");
            }
            else
            {
                cbHinhThucXuLy.Items.Add("Tách sang tour khác");
                cbHinhThucXuLy.Items.Add("Tách đi riêng");
            }

            cbHinhThucXuLy.SelectedIndex = 0;

            AnHienLichMoi();
        }
        private void AnHienLichMoi()
        {
            if (cbLoaiYeuCau.Text == "Ghép tour")
            {
                cbLichKhoiHanhThucTe.Enabled = true;

                if (txtIdDonDatTour.Text.Trim() != "")
                {
                    LoadLichTheoDonDatTour();
                }
            }
            else
            {
                cbLichKhoiHanhThucTe.Enabled = false;
                cbLichKhoiHanhThucTe.DataSource = null;
            }
        }
        private void cbLoaiYeuCau_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadHinhThucXuLy();

        }

        private void cbHinhThucXuLy_SelectedIndexChanged(object sender, EventArgs e)
        {
            AnHienLichMoi();

        }
        private void LoadLichKhoiHanh()
        {
            cbLichKhoiHanhThucTe.DataSource =
                busLKH.getLichKhoiHanh();

            cbLichKhoiHanhThucTe.DisplayMember =
                "NgayKhoiHanh";

            cbLichKhoiHanhThucTe.ValueMember =
                "Id";
        }
        private string LayKieuXuLy()
        {
            if (cbLoaiYeuCau.Text == "Ghép tour")
            {
                return "Ghep_KH";
            }

            if (cbLoaiYeuCau.Text == "Tách tour")
            {
                return "Tach";
            }

            return "BinhThuong";
        }

        private void btnGuiYeuCau_Click(object sender, EventArgs e)
        {

            if (txtIdDonDatTour.Text.Trim() == "" ||
                txtSoLuongPhanBo.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã đơn đặt tour và số lượng người.");
                return;
            }

            string maDon = txtIdDonDatTour.Text.Trim();

            int idDonDatTour = busPB.GetIdDonDatTourTheoMa(maDon);

            if (idDonDatTour == 0)
            {
                MessageBox.Show("Mã đơn đặt tour không hợp lệ hoặc không tồn tại.");
                return;
            }

            int soLuong;

            if (!int.TryParse(txtSoLuongPhanBo.Text.Trim(), out soLuong))
            {
                MessageBox.Show("Số lượng người phải là số.");
                return;
            }

            if (soLuong <= 0)
            {
                MessageBox.Show("Số lượng người phải lớn hơn 0.");
                return;
            }

            DTO_PhanBoDatTour pb =
                new DTO_PhanBoDatTour();

            pb.MaDatTourThucTe = txtMaDatTourThucTe.Text;

            pb.IdDonDatTour = idDonDatTour;

            if (cbLichKhoiHanhThucTe.Enabled == true)
            {
                if (cbLichKhoiHanhThucTe.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn lịch muốn chuyển sang.");
                    return;
                }

                pb.IdLichKhoiHanhThucTe =
                    Convert.ToInt32(cbLichKhoiHanhThucTe.SelectedValue);
            }
            else
            {
                pb.IdLichKhoiHanhThucTe =
                    busPB.GetIdLichBanDauTheoDonDatTour(idDonDatTour);
            }

            pb.SoLuongPhanBo = soLuong;

            pb.KieuXuLy = LayKieuXuLy();
            pb.TrangThai = "ChoXuLy";
            if (busPB.themPhanBoDatTour(pb))
            {
                MessageBox.Show("Gửi yêu cầu thành công. Nhân viên sẽ xử lý và liên hệ lại với bạn.");
                LamMoi();
            }
            else
            {
                MessageBox.Show("Gửi yêu cầu thất bại. Vui lòng kiểm tra lại thông tin.");
            }
        }



        private void LamMoi()
        {
            txtIdDonDatTour.Clear();
            txtSoLuongPhanBo.Clear();

            cbLichKhoiHanhThucTe.DataSource = null;

            TaoMaYeuCau();

            cbLoaiYeuCau.SelectedIndex = 0;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }
        private void LoadLichTheoDonDatTour()
        {
            cbLichKhoiHanhThucTe.DataSource = null;

            if (txtIdDonDatTour.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã đơn đặt tour.");
                return;
            }

            string maDon = txtIdDonDatTour.Text.Trim();

            int idDonDatTour = busPB.GetIdDonDatTourTheoMa(maDon);

            if (idDonDatTour == 0)
            {
                MessageBox.Show("Mã đơn đặt tour không hợp lệ hoặc không tồn tại.");
                return;
            }

            idDonDatTourDangChon = idDonDatTour;

            DataTable dt =
                busPB.GetLichCungTourTheoDonDatTour(idDonDatTour);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Tour của đơn này hiện chưa có lịch khởi hành khác.");
                return;
            }

            cbLichKhoiHanhThucTe.DataSource = dt;
            cbLichKhoiHanhThucTe.DisplayMember = "TenHienThi";
            cbLichKhoiHanhThucTe.ValueMember = "Id";
        }
        private void txtIdDonDatTour_Leave(object sender, EventArgs e)
        {
            if (txtIdDonDatTour.Text.Trim() != "" &&
         cbLichKhoiHanhThucTe.Enabled == true)
            {
                LoadLichTheoDonDatTour();
            };

        }

        private void btnKiemTraDon_Click(object sender, EventArgs e)
        {
            if (txtIdDonDatTour.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã đơn đặt tour để tra cứu.");
                return;
            }

            string maDon = txtIdDonDatTour.Text.Trim();

            int idDonDatTour = busPB.GetIdDonDatTourTheoMa(maDon);

            if (idDonDatTour == 0)
            {
                MessageBox.Show("Mã đơn đặt tour không hợp lệ hoặc không tồn tại.");
                return;
            }

            DataTable dt = busPB.GetYeuCauTheoDonDatTour(idDonDatTour);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Đơn này chưa có yêu cầu ghép/tách nào.");
                return;
            }

            string trangThai = dt.Rows[0]["TrangThai"].ToString();

            MessageBox.Show("Trạng thái yêu cầu mới nhất: " + trangThai);
        }
    }
}

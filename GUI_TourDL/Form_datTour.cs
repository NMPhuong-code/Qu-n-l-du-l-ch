using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BUS_TourDL;
using DTO_TourDL;

namespace GUI_TourDL
{
    public partial class Form_datTour : Form
    {
        private Tourmodel tourDuocChon;
        private BUS_Tour busTour = new BUS_Tour();

        public Form_datTour()
        {
            InitializeComponent();
        }

        // Nhận nguyên object Tourmodel
        public Form_datTour(Tourmodel tour)
        {
            InitializeComponent();
            this.tourDuocChon = tour;
        }

        private void Form_datTour_Load(object sender, EventArgs e)
        {
            numNguoiLon.Value = 0;
            numTreEm.Value = 0;

            CapNhatDanhSachHanhKhach();

            // Hiển thị thông tin tour được chọn
            if (tourDuocChon != null)
            {
                lblTenTourHienThi.Text =
                    tourDuocChon.TenTour;

                lblGiaTourHienThi.Text =
                    "Giá cơ bản: "
                    + tourDuocChon.GiaCoBan.ToString("N0")
                    + " VNĐ";

                lblMoTaHienThi.Text =
                    tourDuocChon.MoTa;
            }
        }

        private void CapNhatDanhSachHanhKhach()
        {
            int soNguoiLon = (int)numNguoiLon.Value;
            int soTreEm = (int)numTreEm.Value;

            int tongSoYeuCau =
                soNguoiLon + soTreEm;

            while (flpDSHanhKhach.Controls.Count > tongSoYeuCau)
            {
                int viTriCuoi =
                    flpDSHanhKhach.Controls.Count - 1;

                Control oCanXoa =
                    flpDSHanhKhach.Controls[viTriCuoi];

                flpDSHanhKhach.Controls.Remove(oCanXoa);

                oCanXoa.Dispose();
            }

            while (flpDSHanhKhach.Controls.Count < tongSoYeuCau)
            {
                UC_HanhKhach ucMoi =
                    new UC_HanhKhach();

                flpDSHanhKhach.Controls.Add(ucMoi);
            }

            int indexNguoiLon = 1;
            int indexTreEm = 1;

            for (int i = 0; i < flpDSHanhKhach.Controls.Count; i++)
            {
                if (flpDSHanhKhach.Controls[i] is UC_HanhKhach)
                {
                    UC_HanhKhach uc =
                        (UC_HanhKhach)flpDSHanhKhach.Controls[i];

                    if (i < soNguoiLon)
                    {
                        uc.TieuDeHanhKhach =
                            "Thông tin người lớn "
                            + indexNguoiLon;

                        indexNguoiLon++;
                    }
                    else
                    {
                        uc.TieuDeHanhKhach =
                            "Thông tin trẻ em "
                            + indexTreEm;

                        uc.ThietLapGiaoDienTreEm();

                        indexTreEm++;
                    }
                }
            }
        }

        private List<DTO_NguoiDiTour> ThuThapDanhSachNguoiDi()
        {
            List<DTO_NguoiDiTour> dsNguoiDi =
                new List<DTO_NguoiDiTour>();

            foreach (Control control in flpDSHanhKhach.Controls)
            {
                if (control is UC_HanhKhach)
                {
                    UC_HanhKhach uc =
                        (UC_HanhKhach)control;

                    DTO_NguoiDiTour nguoiDi =
                        uc.LayThongTin();

                    dsNguoiDi.Add(nguoiDi);
                }
            }

            return dsNguoiDi;
        }

        private void numNguoiLon_ValueChanged(object sender, EventArgs e)
        {
            CapNhatDanhSachHanhKhach();
        }

        private void numTreEm_ValueChanged(object sender, EventArgs e)
        {
            CapNhatDanhSachHanhKhach();
        }

        private void btnThanhToan_Click_1(object sender, EventArgs e)
        {
            if (!chkCamKet.Checked)
            {
                MessageBox.Show(
                    "Vui lòng tích chọn xác nhận cam kết thông tin đưa ra là chính xác!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (string.IsNullOrWhiteSpace(txtHoTenLienHe.Text)
                || string.IsNullOrWhiteSpace(txtSDTLienHe.Text))
            {
                MessageBox.Show(
                    "Vui lòng điền đầy đủ Họ tên và Số điện thoại!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Kiểm tra an toàn
            if (tourDuocChon == null)
            {
                MessageBox.Show(
                    "Không tìm thấy thông tin tour!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            decimal giaTourHienTai =
                tourDuocChon.GiaCoBan;

            DTO_DatTourTronGoi donDat =
                new DTO_DatTourTronGoi();

            donDat.TenNguoiDat =
                txtHoTenLienHe.Text;

            donDat.SDTNguoiDat =
                txtSDTLienHe.Text;

            donDat.EmailNguoiDat =
                txtEmailLienHe.Text;

            donDat.NgayDat =
                DateTime.Now;

            donDat.TrangThaiDon =
                "Chờ thanh toán";

            // QUAN TRỌNG NHẤT
            donDat.IdLich =
                tourDuocChon.IdLich;

            int soNguoiLon =
                (int)numNguoiLon.Value;

            int soTreEm =
                (int)numTreEm.Value;

            donDat.SoLuong =
                soNguoiLon + soTreEm;

            donDat.DanhSachNguoiDi =
                ThuThapDanhSachNguoiDi();

            Form_ThanhToan frmThanhToan =
                new Form_ThanhToan(
                    donDat,
                    tourDuocChon,
                    giaTourHienTai,
                    soNguoiLon,
                    soTreEm);

            frmThanhToan.StartPosition =
                FormStartPosition.CenterScreen;

            if (frmThanhToan.ShowDialog() == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
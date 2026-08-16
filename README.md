# Tourism Management System (Hệ Thống Quản Lý Du Lịch)

> **Academic Collaborative Project** - System Analysis & Software Development  
> **Repository:** [NMPhuong-code/Qu-n-l-du-l-ch](https://github.com/NMPhuong-code/Qu-n-l-du-l-ch)  
> **Timeline:** 03/2026 – 05/2026

---

## Tổng Quan Dự Án
**Hệ thống quản lý du lịch** Là hệ thống triển khai các nghiệp vụ của ngành du lịch như ghép/tách tour, gói tour theo yêu cầu và quản lý hồ sơ du khách.

---

## Chức năng chính

* **Quản lý Tour & Lịch trình:**
  * Thêm, xóa, sửa thông tin các tuyến tour du lịch, điểm tham quan, lịch trình chi tiết và bảng giá theo mùa.
* **Quản lý Khách hàng:**
  * Lưu trữ thông tin du khách, lịch sử đặt tour, thông tin liên hệ và phân nhóm khách hàng thân thiết.
* **Xử lý Đặt Tour & Thanh toán:**
  * Tiếp nhận đơn đặt tour, xử lý giữ chỗ, xuất hóa đơn và theo dõi trạng thái thanh toán.
*  **Ghép & Tách Tour Linh Hoạt:**
  * Hỗ trợ điều phối số lượng khách giữa các đoàn tour để tối ưu chi phí vận hành và số lượng chỗ ngồi.
* **Đặt tour theo yêu cầu:**
  * Thiết kế các gói dịch vụ theo yêu cầu riêng của từng đoàn du khách.

---

## Công Nghệ Sử Dụng

* **Programming Language:** C# / .NET
* **Database Management System:** Microsoft SQL Server
* **Modeling & System Design:** Draw.io (ERD, Use Case Diagrams, DFD, Sequence Diagrams)
* **Version Control & Collaboration:** Git / GitHub

---

## Thiết Kế Cơ Sở Dữ Liệu

| Phân hệ chức năng | Các bảng dữ liệu chính | Nghiệp vụ cốt lõi |
| :--- | :--- | :--- |
| **Auth & Users** | `TaiKhoan`, `NhomQuyen`, `NhanVien` | Quản lý tài khoản, phân quyền và hồ sơ nhân sự |
| **Customers** | `KhachHang`, `HoiVien` | Quản lý thông tin khách, tích điểm và nâng hạng hội viên |
| **Tours & Schedules** | `Tour`, `DiaDanh`, `Tour_DiaDanh`, `LichKhoiHanh`, `HinhAnhTour` | Tuyến điểm tham quan (n-n), bộ sưu tập ảnh và lịch khởi hành |
| **Booking & Allocation** | `DonDatTour`, `NguoiDiTour`, `PhanBoDatTour`, `HuyTour` | Đặt tour, danh sách đoàn, cơ chế **tách/ghép tour** và xử lý hủy tour |
| **Payment & Promo** | `KhuyenMai`, `ThanhToan` | Áp dụng mã giảm giá và quản lý thanh toán nhiều đợt |

---

## Phân Chia Công Việc

| Thành viên | Vai trò | Trách nhiệm chính |
| :--- | :--- | :--- |
| **Đặng Hoàng Thanh Mai** | **System Analyst & Developer / QA** | - Phân tích yêu cầu nghiệp vụ.<br>• Thiết kế mô hình dữ liệu quan hệ (ERD) và cơ sở dữ liệu trên SQL Server.<br>- Phát triển & kiểm thử các module: Quản lý tour, người dùng, ghép/Tách tour và Tour theo yêu cầu.<br>- Thực hiện kiểm thử chức năng (Functional Testing) đảm bảo chất lượng hệ thống. |
| **Nguyễn Mỹ Phương** | **System Analyst & Developer & QA & Team Lead** | - Phân tích yêu cầu nghiệp vụ & tài liệu hóa đặc tả hệ thống(DFD). <br>. - Thiết kế kiến trúc phần mềm & giao diện người dùng (UI/UX).<br>- Xây dựng luồng xử lý thanh toán, quản lý hội viên, xử lý đơn đặt tour, xử lý tour, phân quyền tài khoản, lịch sử tour,  & tổng hợp báo cáo.<br>- Quản lý repository & điều phối mã nguồn. |

---

## Hướng Dẫn Chạy Dự Án

1. **Clone repository:**
   ```bash
   git clone [https://github.com/NMPhuong-code/Qu-n-l-du-l-ch.git](https://github.com/NMPhuong-code/Qu-n-l-du-l-ch.git)

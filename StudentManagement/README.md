# Dự Án Quản Lý Sinh Viên (Windows Forms C#)

Dự án giao diện Quản lý Sinh viên được phát triển bằng Windows Forms (.NET), tuân thủ đầy đủ các tiêu chuẩn giao diện và tính năng theo yêu cầu.

## 1. Cấu Trúc Thư Mục Dự Án
```
D:\Duna VJU\LTNC\code\StudentManagement\
│
├── Models\
│   └── Student.cs                   # Model lớp dữ liệu Student
├── StudentManagementForm.cs         # Code-behind xử lý logic, sự kiện & dữ liệu mẫu
├── StudentManagementForm.Designer.cs# Khởi tạo giao diện bằng code C# WinForms sạch sẽ
├── Program.cs                       # Điểm khởi chạy ứng dụng (Main)
└── StudentManagement.csproj         # File cấu hình dự án .NET
```

## 2. Các Tính Năng Đã Triển Khai
- **Giao diện hiện đại**:
  - Font chữ hệ thống Segoe UI 10pt.
  - Phân vùng trực quan với Header, GroupBox Thông tin, Panel Nút bấm, GroupBox Tìm kiếm và GroupBox Danh sách.
- **Header**: Tiêu đề "QUẢN LÝ SINH VIÊN" nổi bật (18pt Bold, Navy).
- **Nhập liệu (3 cột)**: Đầy đủ các trường Mã SV, Họ tên, Lớp học, Ngày sinh (Custom dd/MM/yyyy), Giới tính (Nam/Nữ), Điểm số, Email, Điện thoại, Trạng thái.
- **Nút thao tác có mã màu**:
  - `btnThem` (Xanh lá - Green)
  - `btnSua` (Xanh dương - Blue)
  - `btnXoa` (Đỏ - Red)
  - `btnLamMoi` (Xám - Gray)
- **Bộ lọc & Tìm kiếm**:
  - Tìm kiếm theo từ khóa (Mã SV / Tên).
  - Lọc theo lớp học (`cboFilterLop`).
  - Lọc theo ngưỡng điểm tối thiểu (`txtDiemTu`).
  - Nút `btnHienThiTatCa` để khôi phục toàn bộ danh sách.
- **Danh sách (DataGridView)**:
  - Hiển thị 9 cột chuẩn: MaSV, HoTen, NgaySinh, GioiTinh, Email, DienThoai, Diem, Lop, TrangThai.
  - Chế độ chọn toàn dòng (`FullRowSelect`), tự động giãn cột (`AutoSizeColumnsMode = Fill`), không cho người dùng tự ý thêm dòng trực tiếp (`AllowUserToAddRows = False`).
  - Thẻ `lblTongSo` hiển thị số lượng sinh viên theo thời gian thực ở góc trên bảng.
- **Sự kiện tích hợp sẵn**:
  - `CellClick`: Nhấp vào bất kỳ dòng nào trong bảng sẽ tự động đổ dữ liệu ngược lên các ô nhập liệu.
  - `btnLamMoi`: Xóa sạch form nhập liệu, bỏ chọn dòng trên bảng và focus vào ô Mã SV.
  - Đầy đủ logic Thêm (kiểm tra rỗng, kiểm tra trùng mã), Sửa, Xóa (có hộp thoại xác nhận) và Tìm kiếm.

## 3. Cách Chạy Dự Án
1. **Qua Terminal / Command Prompt**:
   ```bash
   cd "D:\Duna VJU\LTNC\code\StudentManagement"
   dotnet run
   ```
2. **Qua Visual Studio**:
   Mở solution `code.slnx` trong thư mục `D:\Duna VJU\LTNC\code\24110255_DuongThiNga_Laptrinhnangcao`, chọn project `StudentManagement` làm **Startup Project** và nhấn **F5** hoặc **Start**.

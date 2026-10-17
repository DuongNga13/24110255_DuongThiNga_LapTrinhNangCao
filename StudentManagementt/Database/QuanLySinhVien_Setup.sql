USE QuanLySinhVien;
DELETE FROM SinhVien;
DELETE FROM LopHoc;

INSERT INTO LopHoc (MaLop, TenLop) VALUES
    (N'CSE0101', N'Kỹ thuật phần mềm 01'),
    (N'CSE0102', N'Kỹ thuật phần mềm 02'),
    (N'CSE0201', N'Trí tuệ nhân tạo 01'),
    (N'CSE0301', N'Khoa học dữ liệu 01');

INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, Email, DienThoai, Diem, MaLop, TrangThai) VALUES
    (N'SV000123', N'Nguyễn Văn An',  '2006-01-01', N'Nam', N'an.nv@st.vju.ac.vn',   N'0912345678', 9.5, N'CSE0101', N'Đang học'),
    (N'SV000124', N'Ngô Khắc Anh',   '2006-02-02', N'Nữ',  N'anh.nk@st.vju.ac.vn',  N'0901054321', 9.0, N'CSE0201', N'Đang học'),
    (N'SV000125', N'Lê Hoàng Bình',  '2006-03-03', N'Nam', N'binh.lh@st.vju.ac.vn', N'0920366977', 7.8, N'CSE0102', N'Đang học'),
    (N'SV000126', N'Đỗ Thế Hùng',   '2006-04-04', N'Nữ',  N'hung.dt@st.vju.ac.vn',  N'0977889999', 8.1, N'CSE0301', N'Đang học');
using System;

namespace StudentManagementt.Data.Entity
{
    public class SinhVien
    {
        public string MaSV { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; } = "Nam";
        public string Email { get; set; } = string.Empty;
        public string DienThoai { get; set; } = string.Empty;
        public double Diem { get; set; }
        public string MaLop { get; set; } = string.Empty;
        public string TrangThai { get; set; } = "Đang học";
    }
}

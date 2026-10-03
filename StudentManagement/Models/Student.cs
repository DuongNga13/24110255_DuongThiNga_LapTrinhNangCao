using System;

namespace StudentManagement.Models
{
    public class Student
    {
        public string MaSV { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; } = "Nam";
        public string Email { get; set; } = string.Empty;
        public string DienThoai { get; set; } = string.Empty;
        public double Diem { get; set; }
        public string Lop { get; set; } = string.Empty;
        public string TrangThai { get; set; } = "Đang học";

        public Student() { }

        public Student(string maSV, string hoTen, DateTime ngaySinh, string gioiTinh, 
                       string email, string dienThoai, double diem, string lop, string trangThai)
        {
            MaSV = maSV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            Email = email;
            DienThoai = dienThoai;
            Diem = diem;
            Lop = lop;
            TrangThai = trangThai;
        }
    }
}

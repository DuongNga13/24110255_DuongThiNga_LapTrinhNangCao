using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudentManagementt.Entity
{
    public class SinhVien
    {
        [Required]
        [RegularExpression(@"^SV[0-9]{8}$", ErrorMessage = "Mã sinh viên phải có định dạng: SV followed by 8 digits.")]
        public string maSV { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Họ tên phải có độ dài từ 2 đến 50 ký tự.")]
        public string HoTen { get; set; }
        [Required]
        [RegularExpression(@"^(Nam|Nữ|Khác)$", ErrorMessage = "Giới tính phải là 'Nam', 'Nữ' hoặc 'Khác'.")]
        public string GioiTinh { get; set; }
        [Required]
        [RegularExpression(@"^\d{2}-\d{2}-\d{4}$", ErrorMessage = "Ngày sinh phải có định dạng: dd-MM-yyyy.")]
        public DateTime NgaySinh { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Định dạng email không hợp lệ.")]
        public string email { get; set; }
        [Required]
        [Phone(ErrorMessage = "Định dạng số điện thoại không hợp lệ.")]
        public string Dienthoai { get; set; }
        [Required]
        [RegularExpression(@"^CSE[0-9]{4}$", ErrorMessage = "Mã lớp phải có định dạng: CSE followed by 4 digits.")]
        public string lop { get; set; }
        [Required]
        public string TrangThai { get; set; }
        [Required]  
        [RegularExpression(@"^(0(\.\d{1,2})?|10(\.0{1,2})?)$", ErrorMessage = "Điểm phải là số thực từ 0 đến 10 với tối đa 2 chữ số thập phân.")]
        public string Diem { get; set; }
    }
}
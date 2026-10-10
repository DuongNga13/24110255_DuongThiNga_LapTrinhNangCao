using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using StudentManagementt.Data.DAL;
using StudentManagementt.Data.Entity;

namespace StudentManagementt.BUL
{
    public class SinhVienBUL
    {
        private readonly SinhVienDAL _dal = new();

        public List<SinhVien> GetAll() => _dal.GetAll();

        public List<SinhVien> Search(string keyword, string maLop)
            => _dal.Search(keyword, maLop);

        /// Thêm sinh viên. Trả về null nếu thành công, chuỗi lỗi nếu thất bại.
        public string? Add(SinhVien sv)
        {
            string? error = Validate(sv);
            if (error != null) return error;

            return _dal.Add(sv) ? null : $"Mã sinh viên '{sv.MaSV}' đã tồn tại.";
        }

        /// Cập nhật sinh viên. Trả về null nếu thành công, chuỗi lỗi nếu thất bại.
        public string? Update(SinhVien sv)
        {
            string? error = Validate(sv);
            if (error != null) return error;

            return _dal.Update(sv) ? null : $"Không tìm thấy sinh viên '{sv.MaSV}'.";
        }

        /// Xoá sinh viên. Trả về null nếu thành công, chuỗi lỗi nếu thất bại.
        public string? Delete(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV))
                return "Vui lòng chọn sinh viên cần xoá.";

            return _dal.Delete(maSV) ? null : $"Không tìm thấy sinh viên '{maSV}'.";
        }

        /// Kiểm tra dữ liệu hợp lệ. Trả về null nếu hợp lệ, chuỗi lỗi nếu không.
        public string? Validate(SinhVien sv)
        {
            if (string.IsNullOrWhiteSpace(sv.MaSV))
                return "Mã sinh viên không được để trống.";
            if (!Regex.IsMatch(sv.MaSV.Trim(), @"^SV\d{6,8}$"))
                return "Mã sinh viên phải có định dạng SV + 6–8 chữ số (ví dụ: SV000123).";

            if (string.IsNullOrWhiteSpace(sv.HoTen))
                return "Họ và tên không được để trống.";
            if (sv.HoTen.Trim().Length is < 2 or > 50)
                return "Họ và tên phải có từ 2 đến 50 ký tự.";

            if (sv.NgaySinh == DateTime.MinValue)
                return "Ngày sinh không hợp lệ.";
            if (sv.NgaySinh.Date > DateTime.Today)
                return "Ngày sinh không được lớn hơn ngày hôm nay.";
            if (!IsAgeInRange(sv.NgaySinh, 16, 60))
                return "Tuổi sinh viên phải từ 16 đến 60.";

            if (string.IsNullOrWhiteSpace(sv.Email))
                return "Email không được để trống.";
            if (!Regex.IsMatch(sv.Email.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return "Địa chỉ email không hợp lệ.";

            if (string.IsNullOrWhiteSpace(sv.DienThoai))
                return "Số điện thoại không được để trống.";
            if (!Regex.IsMatch(sv.DienThoai.Trim(), @"^0\d{9}$"))
                return "Số điện thoại phải bắt đầu bằng 0 và có đúng 10 chữ số.";

            if (sv.Diem < 0 || sv.Diem > 10)
                return "Điểm phải trong khoảng từ 0.0 đến 10.0.";

            if (string.IsNullOrWhiteSpace(sv.MaLop))
                return "Vui lòng chọn lớp học.";

            return null;
        }

        public string PhanLoaiHocLuc(double diem) => diem switch
        {
            >= 9.0 => "Xuất sắc",
            >= 8.0 => "Giỏi",
            >= 7.0 => "Khá",
            >= 5.0 => "Trung bình",
            _      => "Yếu"
        };

        private static bool IsAgeInRange(DateTime ngaySinh, int min, int max)
        {
            int age = DateTime.Today.Year - ngaySinh.Year;
            if (ngaySinh.Date > DateTime.Today.AddYears(-age)) age--;
            return age >= min && age <= max;
        }
    }
}

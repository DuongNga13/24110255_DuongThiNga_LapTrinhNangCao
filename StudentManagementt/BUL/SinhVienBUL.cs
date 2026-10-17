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

        public List<SinhVien> GetAll()
        {
            try
            {
                return _dal.GetAllSinhVien();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi nghiệp vụ khi lấy danh sách sinh viên: " + ex.Message, ex);
            }
        }

        public List<SinhVien> Search(string keyword, string maLop)
        {
            try
            {
                return _dal.Search(keyword, maLop);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi nghiệp vụ khi tìm kiếm sinh viên: " + ex.Message, ex);
            }
        }

        public SinhVien? GetByMaSV(string maSV)
        {
            try
            {
                return _dal.GetSinhVienByMaSV(maSV);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi nghiệp vụ khi lấy thông tin sinh viên: " + ex.Message, ex);
            }
        }

        public void Add(SinhVien sv)
        {
            Validate(sv);

            // Kiểm tra trùng mã sinh viên
            if (_dal.GetSinhVienByMaSV(sv.MaSV) != null)
            {
                throw new Exception($"Mã sinh viên '{sv.MaSV}' đã tồn tại trong hệ thống.");
            }

            _dal.AddSinhVien(sv);
        }

        public void Update(SinhVien sv)
        {
            Validate(sv);

            if (_dal.GetSinhVienByMaSV(sv.MaSV) == null)
            {
                throw new Exception($"Không tìm thấy sinh viên có mã '{sv.MaSV}' để cập nhật.");
            }

            _dal.UpdateSinhVien(sv);
        }

        public void Delete(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV))
                throw new Exception("Vui lòng chọn sinh viên cần xoá.");

            if (_dal.GetSinhVienByMaSV(maSV) == null)
                throw new Exception($"Không tìm thấy sinh viên '{maSV}' để xoá.");

            _dal.DeleteSinhVien(maSV);
        }

        public void Validate(SinhVien sv)
        {
            if (string.IsNullOrWhiteSpace(sv.MaSV))
                throw new Exception("Mã sinh viên không được để trống.");
            if (!Regex.IsMatch(sv.MaSV.Trim(), @"^SV\d{6,8}$"))
                throw new Exception("Mã sinh viên phải có định dạng SV + 6–8 chữ số (ví dụ: SV000123).");

            if (string.IsNullOrWhiteSpace(sv.HoTen))
                throw new Exception("Họ và tên không được để trống.");
            if (sv.HoTen.Trim().Length is < 2 or > 50)
                throw new Exception("Họ và tên phải có từ 2 đến 50 ký tự.");

            if (sv.NgaySinh == DateTime.MinValue)
                throw new Exception("Ngày sinh không hợp lệ.");
            if (sv.NgaySinh.Date > DateTime.Today)
                throw new Exception("Ngày sinh không được lớn hơn ngày hôm nay.");
            if (!IsAgeInRange(sv.NgaySinh, 16, 60))
                throw new Exception("Tuổi sinh viên phải từ 16 đến 60.");

            if (string.IsNullOrWhiteSpace(sv.Email))
                throw new Exception("Email không được để trống.");
            if (!Regex.IsMatch(sv.Email.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new Exception("Địa chỉ email không hợp lệ.");

            if (string.IsNullOrWhiteSpace(sv.DienThoai))
                throw new Exception("Số điện thoại không được để trống.");
            if (!Regex.IsMatch(sv.DienThoai.Trim(), @"^0\d{9}$"))
                throw new Exception("Số điện thoại phải bắt đầu bằng 0 và có đúng 10 chữ số.");

            if (sv.Diem < 0 || sv.Diem > 10)
                throw new Exception("Điểm phải trong khoảng từ 0.0 đến 10.0.");

            if (string.IsNullOrWhiteSpace(sv.MaLop))
                throw new Exception("Vui lòng chọn lớp học.");
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

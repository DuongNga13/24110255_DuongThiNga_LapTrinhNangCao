using System.Collections.Generic;
using System.Text.RegularExpressions;
using StudentManagementt.Data.DAL;
using StudentManagementt.Data.Entity;

namespace StudentManagementt.BUL
{
    public class LopHocBUL
    {
        private readonly LopHocDAL _dal = new();

        public List<LopHoc> GetAll() => _dal.GetAll();

        /// Thêm lớp mới. Trả về null nếu thành công, chuỗi lỗi nếu thất bại.
        public string? Add(LopHoc lop)
        {
            string? error = Validate(lop);
            if (error != null) return error;

            return _dal.Add(lop) ? null : $"Mã lớp '{lop.MaLop}' đã tồn tại.";
        }

        /// Kiểm tra dữ liệu hợp lệ. Trả về null nếu hợp lệ, chuỗi lỗi nếu không.
        public string? Validate(LopHoc lop)
        {
            if (string.IsNullOrWhiteSpace(lop.MaLop))
                return "Mã lớp không được để trống.";
            if (!Regex.IsMatch(lop.MaLop.Trim(), @"^CSE\d{4}$"))
                return "Mã lớp phải có định dạng CSE + 4 chữ số (ví dụ: CSE0101).";

            if (string.IsNullOrWhiteSpace(lop.TenLop))
                return "Tên lớp không được để trống.";
            if (lop.TenLop.Trim().Length is < 5 or > 30)
                return "Tên lớp phải có từ 5 đến 30 ký tự.";

            return null;
        }
    }
}

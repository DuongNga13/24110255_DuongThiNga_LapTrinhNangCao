using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using StudentManagementt.Data.DAL;
using StudentManagementt.Data.Entity;

namespace StudentManagementt.BUL
{
    public class LopHocBUL
    {
        private readonly LopHocDAL _dal = new();

        public List<LopHoc> GetAll()
        {
            try
            {
                return _dal.GetAllLopHoc();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi nghiệp vụ khi lấy danh sách lớp học: " + ex.Message, ex);
            }
        }

        public LopHoc? GetByMaLop(string maLop)
        {
            try
            {
                return _dal.GetLopHocByMaLop(maLop);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi nghiệp vụ khi tìm lớp '{maLop}': " + ex.Message, ex);
            }
        }

        public void Add(LopHoc lop)
        {
            Validate(lop);

            if (_dal.GetLopHocByMaLop(lop.MaLop) != null)
            {
                throw new Exception($"Mã lớp '{lop.MaLop}' đã tồn tại trong hệ thống.");
            }

            _dal.AddLopHoc(lop);
        }

        public void Update(LopHoc lop)
        {
            Validate(lop);

            if (_dal.GetLopHocByMaLop(lop.MaLop) == null)
            {
                throw new Exception($"Không tìm thấy lớp '{lop.MaLop}' để cập nhật.");
            }

            _dal.UpdateLopHoc(lop);
        }

        public void Delete(string maLop)
        {
            if (string.IsNullOrWhiteSpace(maLop))
                throw new Exception("Vui lòng chọn mã lớp cần xoá.");

            if (_dal.GetLopHocByMaLop(maLop) == null)
                throw new Exception($"Không tìm thấy lớp '{maLop}' để xoá.");

            _dal.DeleteLopHoc(maLop);
        }

        public void Validate(LopHoc lop)
        {
            if (string.IsNullOrWhiteSpace(lop.MaLop))
                throw new Exception("Mã lớp không được để trống.");
            if (!Regex.IsMatch(lop.MaLop.Trim(), @"^CSE\d{4}$"))
                throw new Exception("Mã lớp phải có định dạng CSE + 4 chữ số (ví dụ: CSE0101).");

            if (string.IsNullOrWhiteSpace(lop.TenLop))
                throw new Exception("Tên lớp không được để trống.");
            if (lop.TenLop.Trim().Length is < 5 or > 30)
                throw new Exception("Tên lớp phải có từ 5 đến 30 ký tự.");
        }
    }
}

using System;
using System.Collections.Generic;
using StudentManagementt.Data.Entity;

namespace StudentManagementt.Data.DAL
{
    public class SinhVienDAL
    {
        private static readonly List<SinhVien> _data = new()
        {
            new SinhVien { MaSV = "SV000123", HoTen = "Nguyễn Văn An",  NgaySinh = new DateTime(2006, 1, 1), GioiTinh = "Nam", Email = "an.nv@st.vju.ac.vn",   DienThoai = "0912345678", Diem = 9.5, MaLop = "CSE0101", TrangThai = "Đang học" },
            new SinhVien { MaSV = "SV000124", HoTen = "Ngô Khắc Anh",   NgaySinh = new DateTime(2006, 2, 2), GioiTinh = "Nữ", Email = "anh.nk@st.vju.ac.vn",  DienThoai = "0901054321", Diem = 9.0, MaLop = "CSE0201", TrangThai = "Đang học" },
            new SinhVien { MaSV = "SV000125", HoTen = "Lê Hoàng Bình",  NgaySinh = new DateTime(2006, 3, 3), GioiTinh = "Nam", Email = "binh.lh@st.vju.ac.vn", DienThoai = "0920366977", Diem = 7.8, MaLop = "CSE0102", TrangThai = "Đang học" },
            new SinhVien { MaSV = "SV000126", HoTen = "Đỗ Thế Hùng",   NgaySinh = new DateTime(2006, 4, 4), GioiTinh = "Nữ", Email = "hung.dt@st.vju.ac.vn",  DienThoai = "0977889999", Diem = 8.1, MaLop = "CSE0301", TrangThai = "Đang học" },
        };

        public List<SinhVien> GetAll() => new(_data);

        public SinhVien? GetByMaSV(string maSV)
            => _data.Find(sv => sv.MaSV.Equals(maSV, StringComparison.OrdinalIgnoreCase));

        public bool Add(SinhVien sv)
        {
            if (GetByMaSV(sv.MaSV) != null) return false;
            _data.Add(sv);
            return true;
        }

        public bool Update(SinhVien sv)
        {
            var target = GetByMaSV(sv.MaSV);
            if (target == null) return false;

            target.HoTen     = sv.HoTen;
            target.NgaySinh  = sv.NgaySinh;
            target.GioiTinh  = sv.GioiTinh;
            target.Email     = sv.Email;
            target.DienThoai = sv.DienThoai;
            target.Diem      = sv.Diem;
            target.MaLop     = sv.MaLop;
            target.TrangThai = sv.TrangThai;
            return true;
        }

        public bool Delete(string maSV)
        {
            var sv = GetByMaSV(maSV);
            if (sv == null) return false;
            _data.Remove(sv);
            return true;
        }

        public List<SinhVien> Search(string keyword, string maLop)
        {
            string kw = keyword.Trim().ToLower();

            return _data.FindAll(sv =>
            {
                bool matchKeyword = string.IsNullOrEmpty(kw)
                    || sv.MaSV.ToLower().Contains(kw)
                    || sv.HoTen.ToLower().Contains(kw)
                    || sv.Email.ToLower().Contains(kw)
                    || sv.DienThoai.Contains(kw);

                bool matchLop = string.IsNullOrEmpty(maLop) || sv.MaLop == maLop;

                return matchKeyword && matchLop;
            });
        }
    }
}

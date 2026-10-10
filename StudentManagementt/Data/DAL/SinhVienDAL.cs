using System;
using System.Collections.Generic;
using StudentManagementt.Data.Entity;

namespace StudentManagementt.Data.DAL
{
    public class SinhVienDAL
    {
        private static readonly List<SinhVien> _data = new()
        {
            new SinhVien { MaSV = "24110578", HoTen = "Nguyễn Văn An",     NgaySinh = new DateTime(2005, 1, 15), GioiTinh = "Nam", Email = "an.nv@st.vju.ac.vn",     DienThoai = "0912345678", Diem = 9.5, MaLop = "CSE0101", TrangThai = "Đang học" },
            new SinhVien { MaSV = "23648974", HoTen = "Ngô Khắc Anh",      NgaySinh = new DateTime(2004, 2, 20), GioiTinh = "Nam", Email = "anh.nk@st.vju.ac.vn",    DienThoai = "0901054321", Diem = 9.0, MaLop = "CSE0201", TrangThai = "Đang học" },
            new SinhVien { MaSV = "24110579", HoTen = "Lê Hoàng Bình",     NgaySinh = new DateTime(2005, 3, 10), GioiTinh = "Nam", Email = "binh.lh@st.vju.ac.vn",   DienThoai = "0920366977", Diem = 7.8, MaLop = "CSE0102", TrangThai = "Đang học" },
            new SinhVien { MaSV = "24110580", HoTen = "Đỗ Thu Hương",      NgaySinh = new DateTime(2006, 4, 25), GioiTinh = "Nữ",  Email = "huong.dt@st.vju.ac.vn",  DienThoai = "0977889999", Diem = 8.1, MaLop = "CSE0301", TrangThai = "Đang học" },
            new SinhVien { MaSV = "24110581", HoTen = "Nguyễn Văn Bính",   NgaySinh = new DateTime(2005, 9, 01), GioiTinh = "Nam", Email = "binh.nv@st.vju.ac.vn",   DienThoai = "0934567890", Diem = 6.5, MaLop = "CSE0101", TrangThai = "Bảo lưu" },
            new SinhVien { MaSV = "24110582", HoTen = "Bùi Văn Lộc",       NgaySinh = new DateTime(2006, 5, 18), GioiTinh = "Nam", Email = "loc.bv@st.vju.ac.vn",    DienThoai = "0981122334", Diem = 8.7, MaLop = "CSE0201", TrangThai = "Đang học" },
            new SinhVien { MaSV = "24110583", HoTen = "Trần Thị Hòa",      NgaySinh = new DateTime(2005, 7, 12), GioiTinh = "Nữ",  Email = "hoa.tt@st.vju.ac.vn",   DienThoai = "0945678901", Diem = 7.2, MaLop = "CSE0102", TrangThai = "Đang học" },
            new SinhVien { MaSV = "24110584", HoTen = "Lê Tú Anh",         NgaySinh = new DateTime(2006, 8, 30), GioiTinh = "Nữ",  Email = "anh.lt@st.vju.ac.vn",   DienThoai = "0966778899", Diem = 8.4, MaLop = "CSE0301", TrangThai = "Đang học" },
            new SinhVien { MaSV = "24110585", HoTen = "Phạm Tiến Sinh",    NgaySinh = new DateTime(2005, 11, 05),GioiTinh = "Nam", Email = "sinh.pt@st.vju.ac.vn",   DienThoai = "0955443322", Diem = 5.8, MaLop = "CSE0101", TrangThai = "Thôi học" },
            new SinhVien { MaSV = "24110586", HoTen = "Quách Ngọc Văn",    NgaySinh = new DateTime(2006, 12, 14),GioiTinh = "Nam", Email = "van.qn@st.vju.ac.vn",    DienThoai = "0911223344", Diem = 9.2, MaLop = "CSE0201", TrangThai = "Đang học" },
            new SinhVien { MaSV = "24110587", HoTen = "Lê Hoàng Xuân",     NgaySinh = new DateTime(2005, 06, 22),GioiTinh = "Nữ",  Email = "xuan.lh@st.vju.ac.vn",   DienThoai = "0933445566", Diem = 6.9, MaLop = "CSE0102", TrangThai = "Đang học" },
            new SinhVien { MaSV = "24110588", HoTen = "Đỗ Thế Vinh",       NgaySinh = new DateTime(2004, 10, 08),GioiTinh = "Nam", Email = "vinh.dt@st.vju.ac.vn",   DienThoai = "0971234567", Diem = 7.5, MaLop = "CSE0301", TrangThai = "Đang học" },        };

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

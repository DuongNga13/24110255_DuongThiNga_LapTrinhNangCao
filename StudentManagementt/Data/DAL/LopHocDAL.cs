using System.Collections.Generic;
using StudentManagementt.Data.Entity;

namespace StudentManagementt.Data.DAL
{
    public class LopHocDAL
    {
        private static readonly List<LopHoc> _data = new()
        {
            new LopHoc { MaLop = "CSE0101", TenLop = "Kỹ thuật phần mềm 01" },
            new LopHoc { MaLop = "CSE0102", TenLop = "Kỹ thuật phần mềm 02" },
            new LopHoc { MaLop = "CSE0201", TenLop = "Trí tuệ nhân tạo 01"  },
            new LopHoc { MaLop = "CSE0301", TenLop = "Khoa học dữ liệu 01"  },
        };

        public List<LopHoc> GetAll() => new(_data);

        public LopHoc? GetByMaLop(string maLop)
            => _data.Find(l => l.MaLop == maLop);

        public bool Add(LopHoc lop)
        {
            if (GetByMaLop(lop.MaLop) != null) return false;
            _data.Add(lop);
            return true;
        }

        public bool Update(LopHoc lop)
        {
            var target = GetByMaLop(lop.MaLop);
            if (target == null) return false;
            target.TenLop = lop.TenLop;
            return true;
        }

        public bool Delete(string maLop)
        {
            var lop = GetByMaLop(maLop);
            if (lop == null) return false;
            _data.Remove(lop);
            return true;
        }
    }
}

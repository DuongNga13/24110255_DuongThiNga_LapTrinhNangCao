using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using StudentManagementt.Data.Entity;

namespace StudentManagementt.Data.DAL
{
    public class SinhVienDAL
    {
        private readonly DataHelper _db = new DataHelper();

        public List<SinhVien> GetAll()
        {
            string sql = "SELECT MaSV,HoTen,NgaySinh,GioiTinh,Email,DienThoai,Diem,MaLop,TrangThai FROM SinhVien ORDER BY MaSV";
            DataTable table = _db.ExecuteQueryResult(sql);
            return MapTable(table);
        }

        public SinhVien? GetByMaSV(string maSV)
        {
            string sql = "SELECT MaSV,HoTen,NgaySinh,GioiTinh,Email,DienThoai,Diem,MaLop,TrangThai FROM SinhVien WHERE MaSV = @MaSV";
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaSV", maSV)
            };
            DataTable table = _db.ExecuteQueryResult(sql, parameters);
            if (table.Rows.Count == 0) return null;
            return MapRow(table.Rows[0]);
        }

        public bool Add(SinhVien sv)
        {
            try
            {
                string sql = @"INSERT INTO SinhVien (MaSV,HoTen,NgaySinh,GioiTinh,Email,DienThoai,Diem,MaLop,TrangThai)
                               VALUES (@MaSV,@HoTen,@NgaySinh,@GioiTinh,@Email,@DienThoai,@Diem,@MaLop,@TrangThai)";
                _db.ExecuteQuery(sql, BuildParams(sv));
                return true;
            }
            catch { return false; }
        }

        public bool Update(SinhVien sv)
        {
            try
            {
                string sql = @"UPDATE SinhVien SET
                                HoTen     = @HoTen,
                                NgaySinh  = @NgaySinh,
                                GioiTinh  = @GioiTinh,
                                Email     = @Email,
                                DienThoai = @DienThoai,
                                Diem      = @Diem,
                                MaLop     = @MaLop,
                                TrangThai = @TrangThai
                               WHERE MaSV = @MaSV";
                _db.ExecuteQuery(sql, BuildParams(sv));
                return true;
            }
            catch { return false; }
        }

        public bool Delete(string maSV)
        {
            try
            {
                string sql = "DELETE FROM SinhVien WHERE MaSV = @MaSV";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@MaSV", maSV)
                };
                _db.ExecuteQuery(sql, parameters);
                return true;
            }
            catch { return false; }
        }

        public List<SinhVien> Search(string keyword, string maLop)
        {
            string kw = string.IsNullOrWhiteSpace(keyword) ? "%" : $"%{keyword.Trim()}%";
            string sql = @"SELECT MaSV,HoTen,NgaySinh,GioiTinh,Email,DienThoai,Diem,MaLop,TrangThai
                           FROM SinhVien
                           WHERE (@KW = '%' OR MaSV LIKE @KW OR HoTen LIKE @KW OR Email LIKE @KW OR DienThoai LIKE @KW)
                             AND (@MaLop = '' OR MaLop = @MaLop)
                           ORDER BY MaSV";
            SqlParameter[] parameters =
            {
                new SqlParameter("@KW",    kw),
                new SqlParameter("@MaLop", maLop ?? "")
            };
            DataTable table = _db.ExecuteQueryResult(sql, parameters);
            return MapTable(table);
        }

        private static SqlParameter[] BuildParams(SinhVien sv) => new[]
        {
            new SqlParameter("@MaSV",      sv.MaSV),
            new SqlParameter("@HoTen",     sv.HoTen),
            new SqlParameter("@NgaySinh",  sv.NgaySinh.Date),
            new SqlParameter("@GioiTinh",  sv.GioiTinh),
            new SqlParameter("@Email",     sv.Email),
            new SqlParameter("@DienThoai", sv.DienThoai),
            new SqlParameter("@Diem",      sv.Diem),
            new SqlParameter("@MaLop",     sv.MaLop),
            new SqlParameter("@TrangThai", sv.TrangThai)
        };

        private static List<SinhVien> MapTable(DataTable table)
        {
            var list = new List<SinhVien>();
            foreach (DataRow row in table.Rows)
                list.Add(MapRow(row));
            return list;
        }

        private static SinhVien MapRow(DataRow row) => new SinhVien
        {
            MaSV      = row["MaSV"].ToString()!,
            HoTen     = row["HoTen"].ToString()!,
            NgaySinh  = Convert.ToDateTime(row["NgaySinh"]),
            GioiTinh  = row["GioiTinh"].ToString()!,
            Email     = row["Email"].ToString()!,
            DienThoai = row["DienThoai"].ToString()!,
            Diem      = Convert.ToDouble(row["Diem"]),
            MaLop     = row["MaLop"].ToString()!,
            TrangThai = row["TrangThai"].ToString()!
        };
    }
}

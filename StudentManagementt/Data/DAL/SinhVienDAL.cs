using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using StudentManagementt.Data.Entity;

namespace StudentManagementt.Data.DAL
{
    public class SinhVienDAL
    {
        private readonly DataHelper dataHelper = new DataHelper();

        public List<SinhVien> GetAllSinhVien()
        {
            try
            {
                List<SinhVien> sinhViens = new List<SinhVien>();
                DataTable dt = dataHelper.GetDataTable("SELECT * FROM SinhVien ORDER BY MaSV");
                foreach (DataRow dr in dt.Rows)
                {
                    sinhViens.Add(MapRow(dr));
                }
                return sinhViens;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải danh sách sinh viên: " + ex.Message, ex);
            }
        }

        public List<SinhVien> GetAllSinhVienUsingReader()
        {
            try
            {
                List<SinhVien> list = new List<SinhVien>();
                SqlDataReader dr = dataHelper.ExcuteReader("SELECT * FROM SinhVien ORDER BY MaSV");
                while (dr.Read())
                {
                    list.Add(new SinhVien
                    {
                        MaSV = dr["MaSV"].ToString()!,
                        HoTen = dr["HoTen"].ToString()!,
                        NgaySinh = Convert.ToDateTime(dr["NgaySinh"]),
                        GioiTinh = dr["GioiTinh"].ToString()!,
                        Email = dr["Email"].ToString()!,
                        DienThoai = dr["DienThoai"].ToString()!,
                        Diem = Convert.ToDouble(dr["Diem"]),
                        MaLop = dr["MaLop"].ToString()!,
                        TrangThai = dr["TrangThai"].ToString()!
                    });
                }
                dr.Close();
                dataHelper.CloseConnection();
                return list;
            }
            catch (Exception ex)
            {
                dataHelper.CloseConnection();
                throw new Exception("Lỗi khi đọc danh sách sinh viên bằng SqlDataReader: " + ex.Message, ex);
            }
        }

        public SinhVien? GetSinhVienByMaSV(string maSV)
        {
            try
            {
                SqlParameter[] parameters = { new SqlParameter("@MaSV", maSV) };
                DataTable dt = dataHelper.GetDataTable("SELECT * FROM SinhVien WHERE MaSV = @MaSV", parameters);
                if (dt.Rows.Count == 0) return null;
                return MapRow(dt.Rows[0]);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm sinh viên có mã '{maSV}': " + ex.Message, ex);
            }
        }

        public List<SinhVien> GetSinhViensByMaLop(string maLop)
        {
            try
            {
                List<SinhVien> list = new List<SinhVien>();
                SqlParameter[] parameters = { new SqlParameter("@MaLop", maLop) };
                DataTable dt = dataHelper.GetDataTable("SELECT * FROM SinhVien WHERE MaLop = @MaLop", parameters);
                foreach (DataRow r in dt.Rows)
                {
                    list.Add(MapRow(r));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy sinh viên theo mã lớp '{maLop}': " + ex.Message, ex);
            }
        }

        public void AddSinhVien(SinhVien sv)
        {
            try
            {
                string sql = @"INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, Email, DienThoai, Diem, MaLop, TrangThai)
                               VALUES (@MaSV, @HoTen, @NgaySinh, @GioiTinh, @Email, @DienThoai, @Diem, @MaLop, @TrangThai)";
                dataHelper.ExecuteNonQuery(sql, BuildParams(sv));
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm sinh viên '{sv.MaSV}': " + ex.Message, ex);
            }
        }

        public void UpdateSinhVien(SinhVien sv)
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
                dataHelper.ExecuteNonQuery(sql, BuildParams(sv));
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật sinh viên '{sv.MaSV}': " + ex.Message, ex);
            }
        }

        public void DeleteSinhVien(string maSV)
        {
            try
            {
                string sql = "DELETE FROM SinhVien WHERE MaSV = @MaSV";
                SqlParameter[] parameters = { new SqlParameter("@MaSV", maSV) };
                dataHelper.ExecuteNonQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xoá sinh viên '{maSV}': " + ex.Message, ex);
            }
        }

        public List<SinhVien> Search(string keyword, string maLop)
        {
            try
            {
                string kw = string.IsNullOrWhiteSpace(keyword) ? "%" : $"%{keyword.Trim()}%";
                string sql = @"SELECT * FROM SinhVien
                               WHERE (@KW = '%' OR MaSV LIKE @KW OR HoTen LIKE @KW OR Email LIKE @KW OR DienThoai LIKE @KW)
                                 AND (@MaLop = '' OR MaLop = @MaLop)
                               ORDER BY MaSV";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@KW", kw),
                    new SqlParameter("@MaLop", maLop ?? "")
                };
                DataTable dt = dataHelper.GetDataTable(sql, parameters);
                var list = new List<SinhVien>();
                foreach (DataRow r in dt.Rows)
                {
                    list.Add(MapRow(r));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm sinh viên: " + ex.Message, ex);
            }
        }

        // Tương thích với các phương thức cũ nếu tầng BUL gọi
        public List<SinhVien> GetAll() => GetAllSinhVien();
        public SinhVien? GetByMaSV(string maSV) => GetSinhVienByMaSV(maSV);
        public void Add(SinhVien sv) => AddSinhVien(sv);
        public void Update(SinhVien sv) => UpdateSinhVien(sv);
        public void Delete(string maSV) => DeleteSinhVien(maSV);

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

        private static SinhVien MapRow(DataRow dr) => new SinhVien
        {
            MaSV      = dr["MaSV"].ToString()!,
            HoTen     = dr["HoTen"].ToString()!,
            NgaySinh  = Convert.ToDateTime(dr["NgaySinh"]),
            GioiTinh  = dr["GioiTinh"].ToString()!,
            Email     = dr["Email"].ToString()!,
            DienThoai = dr["DienThoai"].ToString()!,
            Diem      = Convert.ToDouble(dr["Diem"]),
            MaLop     = dr["MaLop"].ToString()!,
            TrangThai = dr["TrangThai"].ToString()!
        };
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using StudentManagementt.Data.Entity;

namespace StudentManagementt.Data.DAL
{
    public class LopHocDAL
    {
        private readonly DataHelper dataHelper = new DataHelper();

        public List<LopHoc> GetAllLopHoc()
        {
            try
            {
                List<LopHoc> list = new List<LopHoc>();
                DataTable dt = dataHelper.GetDataTable("SELECT MaLop, TenLop FROM LopHoc ORDER BY MaLop");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(MapRow(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải danh sách lớp học: " + ex.Message, ex);
            }
        }

        public LopHoc? GetLopHocByMaLop(string maLop)
        {
            try
            {
                SqlParameter[] parameters = { new SqlParameter("@MaLop", maLop) };
                DataTable dt = dataHelper.GetDataTable("SELECT MaLop, TenLop FROM LopHoc WHERE MaLop = @MaLop", parameters);
                if (dt.Rows.Count == 0) return null;
                return MapRow(dt.Rows[0]);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm lớp học có mã '{maLop}': " + ex.Message, ex);
            }
        }

        public void AddLopHoc(LopHoc lop)
        {
            try
            {
                string sql = "INSERT INTO LopHoc (MaLop, TenLop) VALUES (@MaLop, @TenLop)";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@MaLop",  lop.MaLop),
                    new SqlParameter("@TenLop", lop.TenLop)
                };
                dataHelper.ExecuteNonQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm lớp học '{lop.MaLop}': " + ex.Message, ex);
            }
        }

        public void UpdateLopHoc(LopHoc lop)
        {
            try
            {
                string sql = "UPDATE LopHoc SET TenLop = @TenLop WHERE MaLop = @MaLop";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@TenLop", lop.TenLop),
                    new SqlParameter("@MaLop",  lop.MaLop)
                };
                dataHelper.ExecuteNonQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật lớp học '{lop.MaLop}': " + ex.Message, ex);
            }
        }

        public void DeleteLopHoc(string maLop)
        {
            try
            {
                string sql = "DELETE FROM LopHoc WHERE MaLop = @MaLop";
                SqlParameter[] parameters = { new SqlParameter("@MaLop", maLop) };
                dataHelper.ExecuteNonQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xoá lớp học '{maLop}': " + ex.Message, ex);
            }
        }

        // Tương thích với các phương thức gọi cũ
        public List<LopHoc> GetAll() => GetAllLopHoc();
        public LopHoc? GetByMaLop(string maLop) => GetLopHocByMaLop(maLop);
        public void Add(LopHoc lop) => AddLopHoc(lop);
        public void Update(LopHoc lop) => UpdateLopHoc(lop);
        public void Delete(string maLop) => DeleteLopHoc(maLop);

        private static LopHoc MapRow(DataRow row) => new LopHoc
        {
            MaLop  = row["MaLop"].ToString()!,
            TenLop = row["TenLop"].ToString()!
        };
    }
}

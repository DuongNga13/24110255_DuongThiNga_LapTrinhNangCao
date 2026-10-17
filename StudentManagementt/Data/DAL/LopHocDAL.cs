using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using StudentManagementt.Data.Entity;

namespace StudentManagementt.Data.DAL
{
    public class LopHocDAL
    {
        private readonly DataHelper _db = new DataHelper();

        public List<LopHoc> GetAll()
        {
            string sql = "SELECT MaLop, TenLop FROM LopHoc ORDER BY MaLop";
            DataTable table = _db.ExecuteQueryResult(sql);
            return MapTable(table);
        }

        public LopHoc? GetByMaLop(string maLop)
        {
            string sql = "SELECT MaLop, TenLop FROM LopHoc WHERE MaLop = @MaLop";
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaLop", maLop)
            };
            DataTable table = _db.ExecuteQueryResult(sql, parameters);
            if (table.Rows.Count == 0) return null;
            return MapRow(table.Rows[0]);
        }

        public bool Add(LopHoc lop)
        {
            try
            {
                string sql = "INSERT INTO LopHoc (MaLop, TenLop) VALUES (@MaLop, @TenLop)";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@MaLop",  lop.MaLop),
                    new SqlParameter("@TenLop", lop.TenLop)
                };
                _db.ExecuteQuery(sql, parameters);
                return true;
            }
            catch { return false; }
        }

        public bool Update(LopHoc lop)
        {
            try
            {
                string sql = "UPDATE LopHoc SET TenLop = @TenLop WHERE MaLop = @MaLop";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@TenLop", lop.TenLop),
                    new SqlParameter("@MaLop",  lop.MaLop)
                };
                _db.ExecuteQuery(sql, parameters);
                return true;
            }
            catch { return false; }
        }

        public bool Delete(string maLop)
        {
            try
            {
                string sql = "DELETE FROM LopHoc WHERE MaLop = @MaLop";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@MaLop", maLop)
                };
                _db.ExecuteQuery(sql, parameters);
                return true;
            }
            catch { return false; }
        }

        private static List<LopHoc> MapTable(DataTable table)
        {
            var list = new List<LopHoc>();
            foreach (DataRow row in table.Rows)
                list.Add(MapRow(row));
            return list;
        }

        private static LopHoc MapRow(DataRow row) => new LopHoc
        {
            MaLop  = row["MaLop"].ToString()!,
            TenLop = row["TenLop"].ToString()!
        };
    }
}

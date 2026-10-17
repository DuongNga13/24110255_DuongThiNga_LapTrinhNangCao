using System.Data;
using Microsoft.Data.SqlClient;

namespace StudentManagementt.Data.DAL
{
    public class DataHelper
    {
        private SqlConnection _con;
        private readonly string _connectionString =
            @"Server=(localdb)\MSSQLLocalDB;Database=QuanLySinhVien;Trusted_Connection=True;TrustServerCertificate=True;";

        public DataHelper()
        {
            _con = new SqlConnection(_connectionString);
        }

        public void OpenConnection()
        {
            if (_con.State == ConnectionState.Closed)
            {
                _con.Open();
            }
        }

        public void CloseConnection()
        {
            if (_con.State == ConnectionState.Open)
            {
                _con.Close();
            }
        }

        // Thực thi câu lệnh INSERT / UPDATE / DELETE
        public void ExecuteQuery(string sql)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand(sql, _con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            CloseConnection();
        }

        // Thực thi câu lệnh INSERT / UPDATE / DELETE có tham số (tránh SQL Injection)
        public void ExecuteQuery(string sql, SqlParameter[] parameters)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand(sql, _con);
            cmd.Parameters.AddRange(parameters);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            CloseConnection();
        }

        // Thực thi câu lệnh SELECT — trả về DataTable để hiển thị lên DataGridView
        public DataTable ExecuteQueryResult(string sql)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand(sql, _con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmd.Dispose();
            CloseConnection();
            return table;
        }

        // Thực thi câu lệnh SELECT có tham số — trả về DataTable
        public DataTable ExecuteQueryResult(string sql, SqlParameter[] parameters)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand(sql, _con);
            cmd.Parameters.AddRange(parameters);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmd.Dispose();
            CloseConnection();
            return table;
        }

        // Thực thi câu lệnh trả về 1 giá trị duy nhất (COUNT, SUM, MAX,...)
        public object ExecuteScalar(string sql)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand(sql, _con);
            object result = cmd.ExecuteScalar();
            cmd.Dispose();
            CloseConnection();
            return result;
        }
    }
}

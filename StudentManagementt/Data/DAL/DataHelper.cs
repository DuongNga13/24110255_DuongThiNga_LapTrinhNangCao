using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace StudentManagementt.Data.DAL
{
    public class DataHelper
    {
        private SqlConnection con;
        string connectionString;

        public DataHelper()
        {
            this.connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=QuanLySinhVien;Integrated Security=True;TrustServerCertificate=true";
            con = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void CloseConnection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public void ExecuteNonQuery(string sqlExecuteQuery)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand(sqlExecuteQuery, con);
                command.ExecuteNonQuery();
                command.Dispose();
                CloseConnection();
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw new Exception(ex.Message, ex);
            }
        }

        public void ExecuteNonQuery(string sqlExecuteQuery, SqlParameter[] parameters)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand(sqlExecuteQuery, con);
                command.Parameters.AddRange(parameters);
                command.ExecuteNonQuery();
                command.Dispose();
                CloseConnection();
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw new Exception(ex.Message, ex);
            }
        }

        public SqlDataReader ExcuteReader(string sqlSelect)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand(sqlSelect, con);
                return command.ExecuteReader();
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw new Exception(ex.Message, ex);
            }
        }

        public DataTable GetDataTable(string sqlSelect)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sqlSelect, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public DataTable GetDataTable(string sqlSelect, SqlParameter[] parameters)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sqlSelect, con);
                cmd.Parameters.AddRange(parameters);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}

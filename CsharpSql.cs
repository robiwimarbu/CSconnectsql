using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace ProFelipe
{
    class CsharpSql
    {
        public static string connectionString = "Data Source=Robin-pc\\SQLROBIN;Initial Catalog=siv;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public void OpenConnection()
        {
            try
            {

                connection.Open();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message.ToString(), "ERROR");
            }


        }

        public void CloseConnection()
        {
            connection.Close();
        }
        public int Insertar(String Tabla,String Campos,String Valores)
        {
            String sql = "";
            int r=0;
            
            try
            {
                sql = "INSERT INTO " + Tabla + "(" + Campos + ") VALUES (" + Valores + ")";
                OpenConnection();
                SqlCommand s = new SqlCommand(sql,connection);
                r = s.ExecuteNonQuery();
                CloseConnection();
                return r;
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message.ToString(), "Error");
            }
            return r;
        }
        public DataTable Consulta(String Tabla, String Campos, String Condicion)
        {

            string sql = "";
            DataTable r = new DataTable();
            try
            {
                sql += "SELECT " + Campos + " FROM " + Tabla + " WHERE " + Condicion;
                OpenConnection();
                SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
                dataadapter.Fill(r);
                CloseConnection();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message.ToString(), "ERROR");
            }

            return r;

        }
        public int Modificar(String Upset, String Tabla, String Condicion)
        {
            int r = 0;
            try
            {
             
                String sql = "";
                sql += "UPDATE " + Tabla + " SET " + Upset + " WHERE " + Condicion;
                OpenConnection();
                SqlCommand ret = new SqlCommand(sql, connection);
                r = ret.ExecuteNonQuery();
                CloseConnection();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message.ToString(), "ERROR");
            }

            return r;
        }
        public int Delete(String Tabla, String Condicion)
        {
            int r = 0;
            try
            {
            String sql = "";
            sql += "Delete FROM " + Tabla + " WHERE " + Condicion;
            OpenConnection();
            SqlCommand ret = new SqlCommand(sql, connection);
            r = ret.ExecuteNonQuery();
            CloseConnection();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message.ToString(), "ERROR");
            }
            return r;

        }
    }

}

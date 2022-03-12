using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace aca1
{
    public class DatabaseConnection
    {
        private string ConnectionString = "Data Source=NICOLAS\\SQLEXPRESS;Initial Catalog=GeneracionFacturas;Integrated Security=True";
        public SqlConnection con;

        public DatabaseConnection()
        {
            con = new SqlConnection();
            con.ConnectionString = ConnectionString;
        }

        public void OpenConection()
        {
            try
            {
                con.Open();
                Console.WriteLine("Conexion abierta");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            
        }

        public void CloseConnection()
        {
            con.Close();
        }

        public void ExecuteQueries(string Query_)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(Query_, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            
        }

        public SqlDataReader DataReader(string Query_)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(Query_, con);
                SqlDataReader dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            
        }
    }
}

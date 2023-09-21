using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class DeleteDB
    {
        public static void Delete(DbData db,string table,int Id)
        {

            string connectionString = @$"Data Source={db.Source};Initial Catalog={db.DbName};User={db.User};Password={db.Password};TrustServerCertificate = True";
            string query = $"DELETE FROM {table} WHERE ID=@ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ID", Id);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

        }

    }
}

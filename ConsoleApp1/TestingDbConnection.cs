using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ConsoleApp1
{
    internal class TestingDbConnection
    {
        public static void TestingDBConnection(DbData db) 
        {
            string connectionString = @$"Data Source={db.Source};Initial Catalog={db.DbName};User={db.User};Password={db.Password};TrustServerCertificate = True";
            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                try 
                {
                    connection.Open();
                }
                catch (Exception ex) 
                {
                    throw new Exception($"Error to connect data base:{ex.Message}");
                }
            }
        }
    }
}

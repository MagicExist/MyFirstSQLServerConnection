using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class AddDB
    {
        /// <summary>
        /// This metod insert a certain data
        /// </summary>
        /// <param name="Nombre"></param>
        /// <param name="Apellido"></param>
        /// <param name="Carrera"></param>
        /// <exception cref="Exception"></exception>
        public static void Add(DbData db, string table,string Nombre, string Apellido, string Carrera)
        {

            string connectionString = @$"Data Source={db.Source};Initial Catalog={db.DbName};User={db.User};Password={db.Password};TrustServerCertificate = True";
            string query = $"INSERT INTO {table}(NOMBRE,APELLIDO,CARRERA)" +
                " VALUES (@NOMBRE,@APELLIDO,@CARRERA)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@NOMBRE", Nombre);
                cmd.Parameters.AddWithValue("@APELLIDO", Apellido);
                cmd.Parameters.AddWithValue("@CARRERA", Carrera);
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

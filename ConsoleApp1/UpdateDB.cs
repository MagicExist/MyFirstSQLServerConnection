using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class UpdateDB
    {
        /// <summary>
        /// This function update a record identified by id
        /// </summary>
        /// <param name="Nombre"></param>
        /// <param name="Apellido"></param>
        /// <param name="Carrera"></param>
        /// <param name="Id"></param>
        /// <exception cref="Exception"></exception>
        public static void Update(DbData db, string table,string Nombre, string Apellido, string Carrera, int Id)
        {

            string connectionString = @$"Data Source={db.Source};Initial Catalog={db.DbName};User={db.User};Password={db.Password};TrustServerCertificate = True";
            string query = $"UPDATE {table} SET NOMBRE=@NOMBRE,APELLIDO=@APELLIDO" +
                ",CARRERA=@CARRERA WHERE ID=@ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@NOMBRE", Nombre);
                cmd.Parameters.AddWithValue("@APELLIDO", Apellido);
                cmd.Parameters.AddWithValue("@CARRERA", Carrera);
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

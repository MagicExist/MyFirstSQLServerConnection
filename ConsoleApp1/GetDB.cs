using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class GetDB
    {
        /// <summary>
        /// Este metodo retorna una lista con todos los registros
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<Personas> Get(DbData db,string table)
        {
            string connectionString = @$"Data Source={db.Source};Initial Catalog={db.DbName};User={db.User};Password={db.Password};TrustServerCertificate = True";

            List<Personas> list = new List<Personas>();

            string query = $"SELECT * FROM {table}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Personas oPersona = new Personas();
                        oPersona.Id = reader.GetInt32(0);
                        oPersona.Nombre = reader.GetString(1);
                        oPersona.Apellido = reader.GetString(2);
                        oPersona.Carrera = reader.GetString(3);
                        list.Add(oPersona);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return list;
        }
    }
}

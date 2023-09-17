using Microsoft.Data.SqlClient;
namespace ConsoleApp1
{
    internal class Program
    {

        public static List<Personas> Get() 
        {

            string connectionString = @"Data Source=JOHHAN\SQLEXPRESS;Initial Catalog=PERSONAS;User=sa;Password=12345678;TrustServerCertificate = True";


            List<Personas> list = new List<Personas>();

            string query = "SELECT ID,NOMBRE,APELLIDO,CARRERA FROM ESTUDIANTES";

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

        public static void Add(string Nombre,string Apellido,string Carrera) 
        {
            
            string connectionString = @"Data Source=JOHHAN\SQLEXPRESS;Initial Catalog=PERSONAS;User=sa;Password=12345678;TrustServerCertificate = True";
            string query = "INSERT INTO ESTUDIANTES(NOMBRE,APELLIDO,CARRERA)" +
                " VALUES (@NOMBRE,@APELLIDO,@CARRERA)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@NOMBRE",Nombre);
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
            
            var registro = Get();

        }
        static void Main(string[] args)
            {

            Add("Pedro", "Montoya", "Tecnologia en software");

        }
    }
    
}
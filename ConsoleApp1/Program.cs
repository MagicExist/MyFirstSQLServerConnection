using Microsoft.Data.SqlClient;
using System.Text;
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

        }

        public static void Update(string Nombre, string Apellido, string Carrera,int Id)
        {

            string connectionString = @"Data Source=JOHHAN\SQLEXPRESS;Initial Catalog=PERSONAS;User=sa;Password=12345678;TrustServerCertificate = True";
            string query = "UPDATE ESTUDIANTES SET NOMBRE=@NOMBRE,APELLIDO=@APELLIDO" +
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
        enum menuOption 
        {
            INSERTAR = 1,
            GETALL = 2,
            UPDATE = 3,
        }
        static void Main(string[] args)
            {
            string Nombre = "";
            string Apellido = "";
            string Carrera = "";
            int Id = 0;
            int optc = 0;
            StringBuilder sb = new StringBuilder();
            sb.Append("1.Insertar Datos" +
                      "\n2.Obtener Todos los Datos" +
                      "\n3.Actualizar datos" +
                      "\n  Select:");
           

            while (optc != -1) 
            {
                Console.Clear();
                Console.Write(sb.ToString());
                if (int.TryParse(Console.ReadLine(), out optc))
                {
                    switch ((menuOption)optc)
                    {
                        case menuOption.INSERTAR:
                            Console.Clear();
                            Console.Write("Ingrese Nombre:");
                            Nombre = Console.ReadLine();
                            Console.Write("Ingrese Apellido:");
                            Apellido = Console.ReadLine();
                            Console.Write("Ingrese Carrera:");
                            Carrera = Console.ReadLine();
                            try
                            {
                                Add(Nombre, Apellido, Carrera);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"No se pudo insertar los datos:{ex.Message}");
                                Console.ReadKey();
                                return;
                            }

                            break;
                        case menuOption.GETALL:
                            Console.Clear();
                            List<Personas> list = new List<Personas>();
                            try
                            {
                                list = Get();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"No se pudo obtener los datos:{ex.Message}");
                                Console.ReadKey();
                                return;
                            }
                            foreach (Personas p in list)
                            {
                                Console.WriteLine($"{p.Id} - {p.Nombre} - {p.Apellido} - {p.Carrera}");
                            }
                            Console.ReadKey();
                            break;
                        case menuOption.UPDATE:
                            Console.Clear();
                            Console.Write("Ingrese Nombre:");
                            Nombre = Console.ReadLine();
                            Console.Write("Ingrese Apellido:");
                            Apellido = Console.ReadLine();
                            Console.Write("Ingrese Carrera:");
                            Carrera = Console.ReadLine();
                            Console.Write("Ingrese el Id:");
                            Id = int.Parse(Console.ReadLine());
                            try
                            {
                                Update(Nombre, Apellido, Carrera, Id);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"No se pudo actualizar los datos:{ex.Message}");
                                Console.ReadKey();
                                return;
                            }
                            break;
                    }
                    }
                else 
                {
                    Console.WriteLine("Error:Indice erroneo");
                    Console.ReadKey();

                }

            }



        }
    }
    
}
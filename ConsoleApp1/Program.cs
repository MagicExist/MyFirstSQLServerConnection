﻿using Microsoft.Data.SqlClient;
using System.Text;
namespace ConsoleApp1
{
    internal class Program
    {
        enum menuOption 
        {
            INSERT = 1,
            GETALL = 2,
            UPDATE = 3,
            DELETE = 4,
            EXIT = 5,
        }
        static void Main(string[] args)
        {
            string Nombre = "";
            string Apellido = "";
            string Carrera = "";
            string source = "";
            string dbName = "";
            string user = "";
            string password = "";
            int Id = 0;
            int optc = 0;
            DbData db = null;
            StringBuilder sb = new StringBuilder();

            while (true)
            {
                Console.Clear();
                Console.Write("Insert db source:");
                source = Console.ReadLine();
                Console.Write("\nInsert db name:");
                dbName = Console.ReadLine();
                Console.Write("\nInsert user:");
                user = Console.ReadLine();
                Console.Write("\nInsert password:");
                password = Console.ReadLine();

                try 
                {
                    db = new DbData(source,dbName,user,password);
                    TestingDbConnection.TestingDBConnection(db);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    Console.ReadKey();
                    continue;
                }
                break;
            }

            sb.Append("1.Insertar Datos" +
                      "\n2.Obtener Todos los Datos" +
                      "\n3.Actualizar datos" +
                      "\n4.Eliminar datos" +
                      "\n5.Salir" +
                      "\n  Select:");
           

            while (optc != -1) 
            {
                Console.Clear();
                Console.Write(sb.ToString());
                if (int.TryParse(Console.ReadLine(), out optc))
                {
                    switch ((menuOption)optc)
                    {
                        case menuOption.INSERT:
                            Console.Clear();
                            Console.Write("Ingrese Nombre:");
                            Nombre = Console.ReadLine();
                            Console.Write("Ingrese Apellido:");
                            Apellido = Console.ReadLine();
                            Console.Write("Ingrese Carrera:");
                            Carrera = Console.ReadLine();
                            Console.WriteLine("Ingrese la tabla");
                            tabla = Console.ReadLine();
                            try
                            {
                                AddDB.Add(db,tabla,Nombre, Apellido, Carrera);
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

                            Console.WriteLine("Ingrese la tabla");
                            tabla = Console.ReadLine();
                            try
                            {
                                list = GetDB.Get(db,tabla);
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
                            Console.WriteLine("Ingrese la tabla");
                            tabla = Console.ReadLine();
                            Console.Write("Ingrese el Id:");
                            Id = int.Parse(Console.ReadLine());
                            try
                            {
                                UpdateDB.Update(db,tabla,Nombre, Apellido, Carrera, Id);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"No se pudo actualizar los datos:{ex.Message}");
                                Console.ReadKey();
                                return;
                            }
                            break;
                        case menuOption.DELETE:
                            Console.Clear();
                            Console.WriteLine("Ingrese la tabla");
                            tabla = Console.ReadLine();
                            Console.Write("Ingrese el Id:");
                            Id = int.Parse(Console.ReadLine());
                            try
                            {
                                DeleteDB.Delete(db,tabla,Id);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"No se pudo eliminar los datos:{ex.Message}");
                                Console.ReadKey();
                                return;
                            }
                            break;
                        case menuOption.EXIT:
                            optc = -1;
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
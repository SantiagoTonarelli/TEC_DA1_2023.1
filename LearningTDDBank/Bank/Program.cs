using DataAccess;
using Domain;
using DomainLogic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BankManager aBankManager = new BankManager();
            //aBankManager.AddAccount(new Account()
            //{
            //    UserName = "Juan",
            //    Pass = "123456ORTDA1!"
            //});

            //aBankManager.AddAccount(new Account()
            //{
            //    UserName = "Santiago",
            //    Pass = "912015"
            //});

            //foreach (var account in aBankManager.Accounts)
            //{
            //    Console.WriteLine(account.UserName);
            //}
            // Crear un contexto de base de datos
            MiDbContext context = new MiDbContext();
            context.Usuarios.Add(new Usuario() { Nombre = "Test Juan", Apellido = "Pelicula" });
            var usuario = new Usuario() { Nombre = "Test Juan 2", Apellido = "Pelicula 2" };
            context.Usuarios.Add(usuario);
            context.SaveChanges();

            SQLRequest();

            EFContextRequest();


        }

        private static void SQLRequest()
        {
            // Establecer la cadena de conexión
            string connectionString = "Server=.\\SQLExpress;Database=Obligatorio1DbDA1;Trusted_Connection=True; MultipleActiveResultSets=True;";

            // Crear una conexión
            SqlConnection connection = new SqlConnection(connectionString);

            // Abrir la conexión
            connection.Open();

            // Crear un comando
            string sql = "SELECT Nombre, Apellido FROM Usuarios WHERE Id = @Id";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", 1);

            // Ejecutar la consulta y leer los resultados
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string nombre = reader.GetString(0);
                    string apellido = reader.GetString(1);
                    Console.WriteLine("Nombre: {0}, Apellido: {1}", nombre, apellido);
                }
            }

            // Cerrar la conexión y liberar los recursos
            reader.Close();
            connection.Close();
        }

        private static void EFContextRequest(){
            // Crear un contexto de base de datos
            MiDbContext contexto = new MiDbContext();

            // Realizar la consulta y obtener los resultados
            var usuarios = contexto.Usuarios.Where(u => u.Id == 1);
            foreach (var usuario in usuarios)
            {
                Console.WriteLine("Nombre: {0}, Apellido: {1}", usuario.Nombre, usuario.Apellido);
            }
        }
    }
}

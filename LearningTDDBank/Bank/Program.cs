using DataAccess;
using Domain;
using DomainLogic;
using Logic;
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
            //// Crear un contexto de base de datos
            //MiDbContext context = new MiDbContext();
            //context.Usuarios.Add(new Usuario() { Nombre = "Test Juan", Apellido = "Pelicula" });
            //var usuario = new Usuario() { Nombre = "Test Juan 2", Apellido = "Pelicula 2" };
            //context.Usuarios.Add(usuario);
            //context.SaveChanges();

            //SQLRequest();

            //EFContextRequest();

            TestearLogicaYRepositorio();
        }

        private static void TestearLogicaYRepositorio()
        {
            // Crear el contexto de base de datos
            MiDbContext contexto = new MiDbContext();

            // Crear la instancia de LogicaPersona
            LogicaPersona logicaPersona = new LogicaPersona(new PersonaRepository(contexto));

            try
            {
                // Crear personas con y sin direcciones
                Persona persona1 = new Persona { Nombre = "Persona 1" };
                Direccion direccion1 = new Direccion { Calle = "Calle 1", Ciudad = "Ciudad 1" };
                logicaPersona.AgregarPersonaConDireccion(persona1, direccion1);

                Persona persona2 = new Persona { Nombre = "Persona 2" };
                logicaPersona.AgregarPersonaConDireccion(persona2, null); // Sin dirección

                // Mostrar personas con sus direcciones
                Console.WriteLine("Personas con direcciones:");
                var personasConDireccion = logicaPersona.ObtenerPersonasConDireccion();
                foreach (var persona in personasConDireccion)
                {
                    Console.WriteLine($"ID: {persona.PersonaId}, Nombre: {persona.Nombre}, Calle: {persona.Direccion?.Calle}, Ciudad: {persona.Direccion?.Ciudad}");
                }

                // Actualizar una persona
                int personaIdModificar = persona1.PersonaId;
                string nuevoNombre = "Persona 1 Modificada";
                logicaPersona.ModificarPersona(personaIdModificar, nuevoNombre);

                Console.WriteLine("\nPersonas después de la actualización:");
                personasConDireccion = logicaPersona.ObtenerPersonasConDireccion();
                foreach (var persona in personasConDireccion)
                {
                    Console.WriteLine($"ID: {persona.PersonaId}, Nombre: {persona.Nombre}, Calle: {persona.Direccion?.Calle}, Ciudad: {persona.Direccion?.Ciudad}");
                }

                // Eliminar una persona
                int personaIdEliminar = persona2.PersonaId;
                logicaPersona.EliminarPersona(personaIdEliminar);

                Console.WriteLine("\nPersonas después de la eliminación:");
                personasConDireccion = logicaPersona.ObtenerPersonasConDireccion();
                foreach (var persona in personasConDireccion)
                {
                    Console.WriteLine($"ID: {persona.PersonaId}, Nombre: {persona.Nombre}, Calle: {persona.Direccion?.Calle}, Ciudad: {persona.Direccion?.Ciudad}");
                }
                logicaPersona.EliminarPersona(persona1.PersonaId);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            // Esperar a que el usuario presione una tecla para salir
            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
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
            var usuarios = contexto.Usuarios.Where(u => u.UsuarioId == 1);
            foreach (var usuario in usuarios)
            {
                Console.WriteLine("Nombre: {0}, Apellido: {1}", usuario.Nombre, usuario.Apellido);
            }
        }
    }
}

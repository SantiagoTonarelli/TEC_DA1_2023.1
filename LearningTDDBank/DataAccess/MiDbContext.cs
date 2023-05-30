using Domain;
using System.Data.Entity;

namespace DataAccess
{
    public class MiDbContext : DbContext
    {
        public MiDbContext() : base()
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Curso> Cursos { get; set; }

        //Comandos para correr la migracion desde vs utilizando el package Manager Console
        //Enable-Migrations (Activa la migracion)
        //Add-Migration migration-[version] -StartupProject [Projecto startup] -Verbose
        //Ej: Add-Migration migration-1 -StartupProject Bank -Verbose
        // y luego 
        //Update-Database -StartupProject Bank -Verbose

        //-Verbose la flag nos permite ver las salidas de consola

        //importante tener ef en el projecto de startup y en dataaccess
    }
}

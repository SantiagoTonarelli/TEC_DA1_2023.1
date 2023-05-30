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
    }
}

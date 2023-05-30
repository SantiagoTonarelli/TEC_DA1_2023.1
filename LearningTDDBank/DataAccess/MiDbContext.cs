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
    }
}

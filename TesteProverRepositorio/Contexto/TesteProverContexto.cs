using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TesteProverDominio.Entidades;

namespace TesteProverRepositorio.Contexto
{
    public class TesteProverContexto : DbContext
    {
        public TesteProverContexto() : base("DefaultConnection")
        {
        }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Contato> Contato { get; set; }

        public DbSet<Login> Login { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Cargo>().ToTable("Cargo");
            modelBuilder.Entity<Contato>().ToTable("Contato");
            modelBuilder.Entity<Login>().ToTable("Login");
        }
    }
}

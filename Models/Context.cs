using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .Property(b => b.Perfil)
            .HasConversion(
            v => v.ToString(),
            v => (Models.Perfil)Enum.Parse(typeof(Models.Perfil), v));
        }
    }

}
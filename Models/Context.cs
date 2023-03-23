using System;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class Context : DbContext
    {
       
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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;DataBase=Controle;Uid=root;Pwd=", options => options.EnableRetryOnFailure());
        }
    }


}
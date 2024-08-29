using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class DbContextBase : DbContext
    {
        public DbContextBase(DbContextOptions options) : base(options)
        {
        }

        #region Modelos       
        public DbSet<TB001_USUARIO> TB001_USUARIO { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TB001_USUARIO>(e =>
            {
                e.ToTable("TB001_USUARIO");

                e.HasKey(p => p.NuUsuario).HasName("PK_TB001");

                e.Property(p => p.NuUsuario).HasColumnName("NU_USUARIO");
                e.Property(p => p.IcUsuario).HasColumnName("IC_USUARIO");
                e.Property(p => p.CoSenha).HasColumnName("CO_SENHA");
                e.Property(p => p.NoEmail).HasColumnName("NO_EMAIL");
                e.Property(p => p.NoUsuario).HasColumnName("NO_USUARIO");

            });
        }

    }

}

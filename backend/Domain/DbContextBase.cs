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
        public DbSet<TB003_USUARIO_EMPRESA> TB003_USUARIO_EMPRESA { get; set; }
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

            modelBuilder.Entity<TB003_USUARIO_EMPRESA>(e =>
            {
                e.ToTable("TB003_USUARIO_EMPRESA");

                e.HasKey(p => new { p.NuUsuario, p.NuEmpresa });

                e.Property(p => p.NuUsuario).HasColumnName("NU_USUARIO");
                e.Property(p => p.NuEmpresa).HasColumnName("NU_EMPRESA");

                e.HasOne(n => n.UsuarioNavigation)
                 .WithMany(n => n.UsuarioEmpresaNavigation)
                 .HasForeignKey(f => f.NuUsuario);
            });

            modelBuilder.Entity<TB004_FORNECEDOR>(e =>
            {
                e.ToTable("TB004_FORNECEDOR");

                e.HasKey(p => p.NuFornecedor);

                e.Property(p => p.NuFornecedor).HasColumnName("NU_FORNECEDOR");
                e.Property(p => p.NuEmpresa).HasColumnName("NU_EMPRESA");
                e.Property(p => p.NoFornecedor).HasColumnName("NO_FORNECEDOR");
                e.Property(p => p.VrProdutoFornecedor).HasColumnName("VR_PRODUTO_FORNECEDOR");
                e.Property(p => p.QtProdutoFornecedor).HasColumnName("QT_PRODUTO_FORNECEDOR");

                //e.HasOne(n => n.EmpresaNavigation)
                // .WithMany(n => n.FornecedorNavigation)
                // .HasForeignKey(f => f.NuEmpresa);
            });

            modelBuilder.Entity<TB005_PRODUTO>(e =>
            {
                e.ToTable("TB005_PRODUTO");

                e.HasKey(p => p.NuProduto);

                e.Property(p => p.NuProduto).HasColumnName("NU_PRODUTO");
                e.Property(p => p.NuEmpresa).HasColumnName("NU_EMPRESA");
                e.Property(p => p.NoProduto).HasColumnName("NO_PRODUTO");
                e.Property(p => p.VrProduto).HasColumnName("VR_PRODUTO");

                //e.HasOne(n => n.EmpresaNavigation)
                // .WithMany(n => n.FornecedorNavigation) //LIST TB005
                // .HasForeignKey(f => f.NuEmpresa);
            });

        }

    }

}

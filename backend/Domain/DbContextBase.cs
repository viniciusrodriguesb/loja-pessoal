using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class DbContextBase : DbContext
    {
        public DbContextBase(DbContextOptions options) : base(options) { }

        #region Modelos       
        public DbSet<TB001_USUARIO> TB001_USUARIO { get; set; }
        public DbSet<TB002_EMPRESA> TB002_EMPRESA { get; set; }
        public DbSet<TB003_USUARIO_EMPRESA> TB003_USUARIO_EMPRESA { get; set; }
        public DbSet<TB004_FORNECEDOR> TB004_FORNECEDOR { get; set; }
        public DbSet<TB005_PRODUTO> TB005_PRODUTO { get; set; }
        public DbSet<TB006_GRUPO> TB006_GRUPO { get; set; }
        public DbSet<TB007_PRODUTO_GRUPO> TB007_PRODUTO_GRUPO { get; set; }
        public DbSet<TB008_MOVIMENTACAO> TB008_MOVIMENTACAO { get; set; }
        public DbSet<TB502_LOG_EMPRESA> TB502_LOG_EMPRESA { get; set; }
        public DbSet<TB503_LOG_USUARIO_EMPRESA> TB503_LOG_USUARIO_EMPRESA { get; set; }
        public DbSet<TB504_LOG_FORNECEDOR> TB504_LOG_FORNECEDOR { get; set; }
        public DbSet<TB505_LOG_PRODUTO> TB505_LOG_PRODUTO { get; set; }
        public DbSet<TB506_LOG_GRUPO> TB506_LOG_GRUPO { get; set; }
        public DbSet<TB507_LOG_PRODUTO_GRUPO> TB507_LOG_PRODUTO_GRUPO { get; set; }
        public DbSet<TB508_LOG_MOVIMENTACAO> TB508_LOG_MOVIMENTACAO { get; set; }
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

            modelBuilder.Entity<TB002_EMPRESA>(e =>
            {
                e.ToTable("TB002_EMPRESA");

                e.HasKey(p => p.NuEmpresa).HasName("PK_TB002");

                e.Property(p => p.NuEmpresa).HasColumnName("NU_EMPRESA");
                e.Property(p => p.CoCnpj).HasColumnName("CO_CNPJ");
                e.Property(p => p.NoEmpresa).HasColumnName("NO_EMPRESA");
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

                e.HasOne(n => n.EmpresaNavigation)
                    .WithMany(n => n.UsuariosEmpresaNavigation)
                    .HasForeignKey(f => f.NuEmpresa);
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

                e.HasOne(n => n.EmpresaNavigation)
                    .WithMany(n => n.FornecedoresNavigation)
                    .HasForeignKey(f => f.NuEmpresa);
            });

            modelBuilder.Entity<TB005_PRODUTO>(e =>
            {
                e.ToTable("TB005_PRODUTO");

                e.HasKey(p => p.NuProduto);

                e.Property(p => p.NuProduto).HasColumnName("NU_PRODUTO");
                e.Property(p => p.NuEmpresa).HasColumnName("NU_EMPRESA");
                e.Property(p => p.NoProduto).HasColumnName("NO_PRODUTO");
                e.Property(p => p.VrProduto).HasColumnName("VR_PRODUTO");

                e.HasOne(n => n.EmpresaNavigation)
                    .WithMany(n => n.ProdutosNavigation)
                    .HasForeignKey(f => f.NuEmpresa);
            });

            modelBuilder.Entity<TB006_GRUPO>(e =>
            {
                e.ToTable("TB006_GRUPO");

                e.HasKey(p => p.NuGrupo).HasName("PK_TB006");

                e.Property(p => p.NuGrupo).HasColumnName("NU_GRUPO");
                e.Property(p => p.NoGrupo).HasColumnName("NO_GRUPO");
                e.Property(p => p.VrGrupo).HasColumnName("VR_GRUPO");
            });

            modelBuilder.Entity<TB007_PRODUTO_GRUPO>(e =>
            {
                e.ToTable("TB007_PRODUTO_GRUPO");

                e.HasKey(p => new { p.NuGrupo, p.NuProduto }).HasName("PK_TB007");

                e.Property(p => p.NuGrupo).HasColumnName("NU_GRUPO");
                e.Property(p => p.NuProduto).HasColumnName("NU_PRODUTO");

                e.HasOne(p => p.GrupoNavigation)
                    .WithMany(p => p.ProdutosGrupoNavigation)
                    .HasForeignKey(p => p.NuGrupo);

                e.HasOne(p => p.ProdutoNavigation)
                    .WithMany(p => p.ProdutosGrupoNavigation)
                    .HasForeignKey(p => p.NuProduto);
            });

            modelBuilder.Entity<TB008_MOVIMENTACAO>(e =>
            {
                e.ToTable("TB008_MOVIMENTACAO");

                e.HasKey(p => p.NuMovimentacao).HasName("PK_TB008");

                e.Property(p => p.NuGrupo).HasColumnName("NU_GRUPO");
                e.Property(p => p.NuProduto).HasColumnName("NU_PRODUTO");
                e.Property(p => p.NuMovimentacao).HasColumnName("NU_MOVIMENTACA");
                e.Property(p => p.TpPagamento).HasColumnName("TP_PAGAMENTO");
                e.Property(p => p.DhEvento).HasColumnType("timestamp(6) without time zone").HasColumnName("DH_EVENTO");

                e.HasOne(p => p.ProdutoNavigation)
                 .WithMany(p => p.MovimentacoesNavigation)
                 .HasForeignKey(p => p.NuProduto);

                e.HasOne(p => p.GrupoNavigation)
                    .WithMany(p => p.MovimentacoesNavigation)
                    .HasForeignKey(p => p.NuGrupo);
            });

            #region Tabelas de Log
            modelBuilder.Entity<TB502_LOG_EMPRESA>(e =>
            {
                e.ToTable("TB502_LOG_EMPRESA");

                e.HasKey(p => p.NuLogEmpresa).HasName("PK_TB502");

                e.Property(p => p.NuLogEmpresa).HasColumnName("NU_LOG_EMPRESA");
                e.Property(p => p.NuEmpresa).HasColumnName("NU_EMPRESA");
                e.Property(p => p.NoEmpresa).HasColumnName("NO_EMPRESA");
                e.Property(p => p.CoCnpj).HasColumnName("CO_CNPJ");
                e.Property(p => p.IcOperacao).HasColumnName("IC_OPERACAO");
                e.Property(p => p.DhOperacao).HasColumnType("timestamp(6) without time zone").HasColumnName("DH_OPERACAO");
            });

            modelBuilder.Entity<TB503_LOG_USUARIO_EMPRESA>(e =>
            {
                e.ToTable("TB503_LOG_USUARIO_EMPRESA");

                e.HasKey(p => p.NuLogUsuarioEmpresa).HasName("PK_TB503");

                e.Property(p => p.NuLogUsuarioEmpresa).HasColumnName("NU_LOG_USUARIO_EMPRESA");
                e.Property(p => p.IcOperacao).HasColumnName("IC_OPERACAO");
                e.Property(p => p.DhOperacao).HasColumnType("timestamp(6) without time zone").HasColumnName("DH_OPERACAO");
                e.Property(p => p.NuEmpresa).HasColumnName("NU_EMPRESA");
                e.Property(p => p.NuUsuario).HasColumnName("NU_USUARIO");
            });

            modelBuilder.Entity<TB504_LOG_FORNECEDOR>(e =>
            {
                e.ToTable("TB504_LOG_FORNECEDOR");

                e.HasKey(p => p.NuLogFornecedor).HasName("PK_TB504");

                e.Property(p => p.NuFornecedor).HasColumnName("NU_FORNECEDOR");
                e.Property(p => p.NuEmpresa).HasColumnName("NU_EMPRESA");
                e.Property(p => p.QtProdutoFornecedor).HasColumnName("QT_PRODUTO_FORNECEDOR");
                e.Property(p => p.NoProdutoFornecedor).HasColumnName("NO_PRODUTOO_FORNECEDOR");
                e.Property(p => p.VrProdutoFornecedor).HasColumnName("VR_PRODUTO_FORNECEDOR");
                e.Property(p => p.DhOperacao).HasColumnType("timestamp(6) without time zone").HasColumnName("DH_OPERACAO");
                e.Property(p => p.IcOperacao).HasColumnName("IC_OPERACA");
                e.Property(p => p.NuLogFornecedor).HasColumnName("NU_LOG_FORNECEDOR");
            });

            modelBuilder.Entity<TB505_LOG_PRODUTO>(e =>
            {
                e.ToTable("TB505_LOG_PRODUTO");

                e.HasKey(p => p.NuLogProduto).HasName("PK_TB505");

                e.Property(p => p.NuLogProduto).HasColumnName("NU_LOG_PRODUTO");
                e.Property(p => p.IcOperacao).HasColumnName("IC_OPERACAO");
                e.Property(p => p.VrProduto).HasColumnName("VR_PRODUTO");
                e.Property(p => p.DhOperacao).HasColumnType("timestamp(6) without time zone").HasColumnName("DH_OPERACAO");
                e.Property(p => p.NuEmpresa).HasColumnName("NU_EMPRESA");
                e.Property(p => p.NuProduto).HasColumnName("NU_PRODUTO");
                e.Property(p => p.NoProduto).HasColumnName("NO_PRODUTO");
            });


            modelBuilder.Entity<TB506_LOG_GRUPO>(e =>
            {
                e.ToTable("TB506_LOG_GRUPO");

                e.HasKey(p => p.NuLogGrupo).HasName("PK_TB506");

                e.Property(p => p.NuLogGrupo).HasColumnName("NU_LOG_GRUPO");
                e.Property(p => p.NuGrupo).HasColumnName("NU_GRUPO");
                e.Property(p => p.NoGrupo).HasColumnName("NO_GRUPO");
                e.Property(p => p.VrGrupo).HasColumnName("VR_GRUPO");
                e.Property(p => p.IcOperacao).HasColumnName("IC_OPERACAO");
                e.Property(p => p.DhOperacao).HasColumnType("timestamp(6) without time zone").HasColumnName("DH_OPERACAO");
            });

            modelBuilder.Entity<TB507_LOG_PRODUTO_GRUPO>(e =>
            {
                e.ToTable("TB507_LOG_PRODUTO_GRUPO");

                e.HasKey(p => p.NuLogProdutoGrupo).HasName("PK_TB507");

                e.Property(p => p.NuLogProdutoGrupo).HasColumnName("NU_LOG_PRODUTO_GRUPO");
                e.Property(p => p.NuGrupo).HasColumnName("NU_GRUPO");
                e.Property(p => p.NuProduto).HasColumnName("NU_PRODUTO");
                e.Property(p => p.IcOperacao).HasColumnName("IC_OPERACAO");
                e.Property(p => p.DhOperacao).HasColumnType("timestamp(6) without time zone").HasColumnName("DH_OPERACAO");
            });

            modelBuilder.Entity<TB508_LOG_MOVIMENTACAO>(e =>
            {
                e.ToTable("TB508_LOG_MOVIMENTACAO");

                e.HasKey(p => p.NuLogMovimentacao).HasName("PK_TB508");

                e.Property(p => p.NuLogMovimentacao).HasColumnName("NU_LOG_MOVIMENTACAO");
                e.Property(p => p.NuMovimentacao).HasColumnName("NU_MOVIMENTACAO");
                e.Property(p => p.TpPagamento).HasColumnName("TP_PAGAMENTO");
                e.Property(p => p.NuGrupo).HasColumnName("NU_GRUPO");
                e.Property(p => p.NuProduto).HasColumnName("NU_PRODUTO");
                e.Property(p => p.DhEvento).HasColumnType("timestamp(6) without time zone").HasColumnName("DH_EVENTO");
                e.Property(p => p.IcOperacao).HasColumnName("IC_OPERACAO");
                e.Property(p => p.DhOperacao).HasColumnType("timestamp(6) without time zone").HasColumnName("DH_OPERACAO");
            });
            #endregion
        }
    }
}

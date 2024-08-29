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
        public DbSet<TB002_EMPRESA> TB002_EMPRESA { get; set; }
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

				e.HasOne(p => p.GrupoNavigation).WithMany(p => p.ProdutosGrupoNavigation).HasForeignKey(p => p.NuGrupo);
			});

			modelBuilder.Entity<TB008_MOVIMENTACAO>(e =>
			{
				e.ToTable("TB008_MOVIMENTACAO");

				e.HasKey(p => p.NuMovimentacao).HasName("PK_TB008");
				e.Property(p => p.NuGrupo).HasColumnName("NU_GRUPO");
				e.Property(p => p.NuProduto).HasColumnName("NU_PRODUTO");
				e.Property(p => p.NuMovimentacao).HasColumnName("NU_MOVIMENTACAO");
				e.Property(p => p.TpPagamento).HasColumnName("TP_PAGAMENTO");
				e.Property(p => p.DhEvento).HasColumnName("DH_EVENTO");

				e.HasOne(p => p.GrupoNavigation).WithMany(p => p.MovimentacoesNavigation).HasForeignKey(p => p.NuGrupo);
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
				e.Property(p => p.DhOperacao).HasColumnName("DH_OPERACAO");
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
				e.Property(p => p.DhOperacao).HasColumnName("DH_OPERACAO");
			});

			modelBuilder.Entity<TB507_LOG_PRODUTO_GRUPO>(e =>
			{
				e.ToTable("TB507_LOG_PRODUTO_GRUPO");

				e.HasKey(p => p.NuLogProdutoGrupo).HasName("PK_TB507");

				e.Property(p => p.NuLogProdutoGrupo).HasColumnName("NU_LOG_PRODUTO_GRUPO");
				e.Property(p => p.NuGrupo).HasColumnName("NU_GRUPO");
				e.Property(p => p.NuProduto).HasColumnName("NU_PRODUTO");
				e.Property(p => p.IcOperacao).HasColumnName("IC_OPERACAO");
				e.Property(p => p.DhOperacao).HasColumnName("DH_OPERACAO");
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
				e.Property(p => p.DhEvento).HasColumnName("DH_EVENTO");
				e.Property(p => p.IcOperacao).HasColumnName("IC_OPERACAO");
				e.Property(p => p.DhOperacao).HasColumnName("DH_OPERACAO");
			});

			#endregion
		}

	}

}


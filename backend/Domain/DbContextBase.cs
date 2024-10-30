using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class DbContextBase : DbContext
    {
        public DbContextBase(DbContextOptions<DbContextBase> options) : base(options) { }

        #region Modelos       
        public DbSet<TB001_USUARIO> TB001_USUARIO { get; set; }
        public DbSet<TB002_EMPRESA> TB002_EMPRESA { get; set; }
        public DbSet<TB003_USUARIO_EMPRESA> TB003_USUARIO_EMPRESA { get; set; }
        public DbSet<TB004_FORNECEDOR> TB004_FORNECEDOR { get; set; }
        public DbSet<TB005_PRODUTO> TB005_PRODUTO { get; set; }
        public DbSet<TB006_GRUPO> TB006_GRUPO { get; set; }
        public DbSet<TB007_PRODUTO_GRUPO> TB007_PRODUTO_GRUPO { get; set; }
        public DbSet<TB008_MOVIMENTACAO> TB008_MOVIMENTACAO { get; set; }
        public DbSet<TB501_LOG_USUARIO> TB501_LOG_USUARIO { get; set; }
        public DbSet<TB502_LOG_EMPRESA> TB502_LOG_EMPRESA { get; set; }
        public DbSet<TB503_LOG_USUARIO_EMPRESA> TB503_LOG_USUARIO_EMPRESA { get; set; }
        public DbSet<TB504_LOG_FORNECEDOR> TB504_LOG_FORNECEDOR { get; set; }
        public DbSet<TB505_LOG_PRODUTO> TB505_LOG_PRODUTO { get; set; }
        public DbSet<TB506_LOG_GRUPO> TB506_LOG_GRUPO { get; set; }
        public DbSet<TB507_LOG_PRODUTO_GRUPO> TB507_LOG_PRODUTO_GRUPO { get; set; }
        public DbSet<TB508_LOG_MOVIMENTACAO> TB508_LOG_MOVIMENTACAO { get; set; }
        #endregion

        #region Mapeamento
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AI");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContextBase).Assembly);
        }
        #endregion
    }
}

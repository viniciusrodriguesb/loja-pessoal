using Domain.Entities;
using Domain.Mappings;
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
            base.OnModelCreating(modelBuilder);

            #region Tabelas Principais
            modelBuilder.ApplyConfiguration(new TB001Map());
            modelBuilder.ApplyConfiguration(new TB002Map());
            modelBuilder.ApplyConfiguration(new TB003Map());
            modelBuilder.ApplyConfiguration(new TB004Map());
            modelBuilder.ApplyConfiguration(new TB005Map());
            modelBuilder.ApplyConfiguration(new TB006Map());
            modelBuilder.ApplyConfiguration(new TB007Map());
            modelBuilder.ApplyConfiguration(new TB008Map());
            #endregion

            #region Tabelas de Log

            modelBuilder.ApplyConfiguration(new TB501Map());
            modelBuilder.ApplyConfiguration(new TB502Map());
            modelBuilder.ApplyConfiguration(new TB503Map());
            modelBuilder.ApplyConfiguration(new TB504Map());
            modelBuilder.ApplyConfiguration(new TB505Map());
            modelBuilder.ApplyConfiguration(new TB506Map());
            modelBuilder.ApplyConfiguration(new TB507Map());
            modelBuilder.ApplyConfiguration(new TB508Map());

            #endregion
        } 
        #endregion
    }
}

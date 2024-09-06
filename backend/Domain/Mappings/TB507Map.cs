using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Mappings
{
    public class TB507Map : IEntityTypeConfiguration<TB507_LOG_PRODUTO_GRUPO>
    {
        public void Configure(EntityTypeBuilder<TB507_LOG_PRODUTO_GRUPO> builder)
        {
            builder.ToTable("TB507_LOG_PRODUTO_GRUPO");

            builder.HasKey(p => p.NuLogProdutoGrupo).HasName("PK_TB507");

            builder.Property(p => p.NuLogProdutoGrupo).HasColumnName("NU_LOG_PRODUTO_GRUPO");
            builder.Property(p => p.NuGrupo).HasColumnName("NU_GRUPO");
            builder.Property(p => p.NuProduto).HasColumnName("NU_PRODUTO");
            builder.Property(p => p.IcOperacao).HasColumnName("IC_OPERACAO");
            builder.Property(p => p.DhOperacao).HasColumnType("timestamp(6) without time zone").HasColumnName("DH_OPERACAO");
        }
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Mappings
{
    public class TB508Map : IEntityTypeConfiguration<TB508_LOG_MOVIMENTACAO>
    {
        public void Configure(EntityTypeBuilder<TB508_LOG_MOVIMENTACAO> builder)
        {
            builder.ToTable("TB508_LOG_MOVIMENTACAO");

            builder.HasKey(p => p.NuLogMovimentacao).HasName("PK_TB508");

            builder.Property(p => p.NuLogMovimentacao).HasColumnName("NU_LOG_MOVIMENTACAO");
            builder.Property(p => p.NuMovimentacao).HasColumnName("NU_MOVIMENTACAO");
            builder.Property(p => p.TpPagamento).HasColumnName("TP_PAGAMENTO");
            builder.Property(p => p.NuGrupo).HasColumnName("NU_GRUPO");
            builder.Property(p => p.NuProduto).HasColumnName("NU_PRODUTO");
            builder.Property(p => p.DhEvento).HasColumnType("timestamp(6) without time zone").HasColumnName("DH_EVENTO");
            builder.Property(p => p.IcOperacao).HasColumnName("IC_OPERACAO");
            builder.Property(p => p.DhOperacao).HasColumnType("timestamp(6) without time zone").HasColumnName("DH_OPERACAO");
        }
    }
}

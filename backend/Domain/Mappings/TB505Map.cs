using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Mappings
{
    public class TB505Map : IEntityTypeConfiguration<TB505_LOG_PRODUTO>
    {
        public void Configure(EntityTypeBuilder<TB505_LOG_PRODUTO> builder)
        {
            builder.ToTable("TB505_LOG_PRODUTO");

            builder.HasKey(p => p.NuLogProduto).HasName("PK_TB505");

            builder.Property(p => p.NuLogProduto).HasColumnName("NU_LOG_PRODUTO");
            builder.Property(p => p.IcOperacao).HasColumnName("IC_OPERACAO");
            builder.Property(p => p.VrProduto).HasColumnName("VR_PRODUTO");
            builder.Property(p => p.DhOperacao).HasColumnType("timestamp(6) without time zone").HasColumnName("DH_OPERACAO");
            builder.Property(p => p.NuEmpresa).HasColumnName("NU_EMPRESA");
            builder.Property(p => p.NuProduto).HasColumnName("NU_PRODUTO");
            builder.Property(p => p.NoProduto).HasColumnName("NO_PRODUTO");
        }
    }
}

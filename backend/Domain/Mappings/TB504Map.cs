using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Mappings
{
    public class TB504Map : IEntityTypeConfiguration<TB504_LOG_FORNECEDOR>
    {
        public void Configure(EntityTypeBuilder<TB504_LOG_FORNECEDOR> builder)
        {
            builder.ToTable("TB504_LOG_FORNECEDOR");

            builder.HasKey(p => p.NuLogFornecedor).HasName("PK_TB504");

            builder.Property(p => p.NuFornecedor).HasColumnName("NU_FORNECEDOR");
            builder.Property(p => p.NuEmpresa).HasColumnName("NU_EMPRESA");
            builder.Property(p => p.QtProdutoFornecedor).HasColumnName("QT_PRODUTO_FORNECEDOR");
            builder.Property(p => p.NoProdutoFornecedor).HasColumnName("NO_PRODUTOO_FORNECEDOR");
            builder.Property(p => p.VrProdutoFornecedor).HasColumnName("VR_PRODUTO_FORNECEDOR");
            builder.Property(p => p.DhOperacao).HasColumnType("timestamp(6) without time zone").HasColumnName("DH_OPERACAO");
            builder.Property(p => p.IcOperacao).HasColumnName("IC_OPERACA");
            builder.Property(p => p.NuLogFornecedor).HasColumnName("NU_LOG_FORNECEDOR");
        }
    }
}

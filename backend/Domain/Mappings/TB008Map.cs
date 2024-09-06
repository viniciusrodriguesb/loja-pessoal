using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Mappings
{
    public class TB008Map : IEntityTypeConfiguration<TB008_MOVIMENTACAO>
    {
        public void Configure(EntityTypeBuilder<TB008_MOVIMENTACAO> builder)
        {
            builder.ToTable("TB008_MOVIMENTACAO");

            builder.HasKey(p => p.NuMovimentacao).HasName("PK_TB008");

            builder.Property(p => p.NuGrupo).HasColumnName("NU_GRUPO");
            builder.Property(p => p.NuProduto).HasColumnName("NU_PRODUTO");
            builder.Property(p => p.NuMovimentacao).HasColumnName("NU_MOVIMENTACA");
            builder.Property(p => p.TpPagamento).HasColumnName("TP_PAGAMENTO");
            builder.Property(p => p.DhEvento).HasColumnType("timestamp(6) without time zone").HasColumnName("DH_EVENTO");

            builder.HasOne(p => p.ProdutoNavigation)
             .WithMany(p => p.MovimentacoesNavigation)
             .HasForeignKey(p => p.NuProduto);

            builder.HasOne(p => p.GrupoNavigation)
                .WithMany(p => p.MovimentacoesNavigation)
                .HasForeignKey(p => p.NuGrupo);
        }
    }
}

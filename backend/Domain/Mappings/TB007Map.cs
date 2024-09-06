using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Mappings
{
    public class TB007Map : IEntityTypeConfiguration<TB007_PRODUTO_GRUPO>
    {
        public void Configure(EntityTypeBuilder<TB007_PRODUTO_GRUPO> builder)
        {
            builder.ToTable("TB007_PRODUTO_GRUPO");

            builder.HasKey(p => new { p.NuGrupo, p.NuProduto }).HasName("PK_TB007");

            builder.Property(p => p.NuGrupo).HasColumnName("NU_GRUPO");
            builder.Property(p => p.NuProduto).HasColumnName("NU_PRODUTO");

            builder.HasOne(p => p.GrupoNavigation)
                .WithMany(p => p.ProdutosGrupoNavigation)
                .HasForeignKey(p => p.NuGrupo);

            builder.HasOne(p => p.ProdutoNavigation)
                .WithMany(p => p.ProdutosGrupoNavigation)
                .HasForeignKey(p => p.NuProduto);
        }
    }
}

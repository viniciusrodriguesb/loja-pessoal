using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Mappings
{
    public class TB005Map : IEntityTypeConfiguration<TB005_PRODUTO>
    {
        public void Configure(EntityTypeBuilder<TB005_PRODUTO> builder)
        {

            builder.ToTable("TB005_PRODUTO");

            builder.HasKey(p => p.NuProduto);

            builder.Property(p => p.NuProduto).HasColumnName("NU_PRODUTO");
            builder.Property(p => p.NuEmpresa).HasColumnName("NU_EMPRESA");
            builder.Property(p => p.NoProduto).HasColumnName("NO_PRODUTO");
            builder.Property(p => p.VrProduto).HasColumnName("VR_PRODUTO");

            builder.HasOne(n => n.EmpresaNavigation)
                .WithMany(n => n.ProdutosNavigation)
                .HasForeignKey(f => f.NuEmpresa);
        }
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Mappings
{
    public class TB004Map : IEntityTypeConfiguration<TB004_FORNECEDOR>
    {
        public void Configure(EntityTypeBuilder<TB004_FORNECEDOR> builder)
        {
            builder.ToTable("TB004_FORNECEDOR");

            builder.HasKey(p => p.NuFornecedor);

            builder.Property(p => p.NuFornecedor).HasColumnName("NU_FORNECEDOR");
            builder.Property(p => p.NuEmpresa).HasColumnName("NU_EMPRESA");
            builder.Property(p => p.NoFornecedor).HasColumnName("NO_FORNECEDOR");
            builder.Property(p => p.NoProdutoFornecedor).HasColumnName("NO_PRODUTO_FORNECEDOR");
            builder.Property(p => p.VrProdutoFornecedor).HasColumnName("VR_PRODUTO_FORNECEDOR");
            builder.Property(p => p.QtProdutoFornecedor).HasColumnName("QT_PRODUTO_FORNECEDOR");

            builder.HasOne(n => n.EmpresaNavigation)
                .WithMany(n => n.FornecedoresNavigation)
                .HasForeignKey(f => f.NuEmpresa);
        }
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Mappings
{
    public class TB002Map : IEntityTypeConfiguration<TB002_EMPRESA>
    {
        public void Configure(EntityTypeBuilder<TB002_EMPRESA> builder)
        {
            builder.ToTable("TB002_EMPRESA");

            builder.HasKey(p => p.NuEmpresa).HasName("PK_TB002");

            builder.Property(p => p.NuEmpresa).HasColumnName("NU_EMPRESA");
            builder.Property(p => p.CoCnpj).HasColumnName("CO_CNPJ");
            builder.Property(p => p.NoEmpresa).HasColumnName("NO_EMPRESA");
        }
    }
}

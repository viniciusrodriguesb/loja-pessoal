using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Mappings
{
    public class TB006Map : IEntityTypeConfiguration<TB006_GRUPO>
    {
        public void Configure(EntityTypeBuilder<TB006_GRUPO> builder)
        {
            builder.ToTable("TB006_GRUPO");

            builder.HasKey(p => p.NuGrupo).HasName("PK_TB006");

            builder.Property(p => p.NuGrupo).HasColumnName("NU_GRUPO");
            builder.Property(p => p.NoGrupo).HasColumnName("NO_GRUPO");
            builder.Property(p => p.VrGrupo).HasColumnName("VR_GRUPO");
        }
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Mappings
{
    public class TB506Map : IEntityTypeConfiguration<TB506_LOG_GRUPO>
    {
        public void Configure(EntityTypeBuilder<TB506_LOG_GRUPO> builder)
        {
            builder.ToTable("TB506_LOG_GRUPO");

            builder.HasKey(p => p.NuLogGrupo).HasName("PK_TB506");

            builder.Property(p => p.NuLogGrupo).HasColumnName("NU_LOG_GRUPO");
            builder.Property(p => p.NuGrupo).HasColumnName("NU_GRUPO");
            builder.Property(p => p.NoGrupo).HasColumnName("NO_GRUPO");
            builder.Property(p => p.VrGrupo).HasColumnName("VR_GRUPO");
            builder.Property(p => p.IcOperacao).HasColumnName("IC_OPERACAO");
            builder.Property(p => p.DhOperacao).HasColumnType("timestamp(6) without time zone").HasColumnName("DH_OPERACAO");
        }
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Mappings
{
    public class TB503Map : IEntityTypeConfiguration<TB503_LOG_USUARIO_EMPRESA>
    {
        public void Configure(EntityTypeBuilder<TB503_LOG_USUARIO_EMPRESA> builder)
        {
            builder.ToTable("TB503_LOG_USUARIO_EMPRESA");

            builder.HasKey(p => p.NuLogUsuarioEmpresa).HasName("PK_TB503");

            builder.Property(p => p.NuLogUsuarioEmpresa).HasColumnName("NU_LOG_USUARIO_EMPRESA");
            builder.Property(p => p.IcOperacao).HasColumnName("IC_OPERACAO");
            builder.Property(p => p.DhOperacao).HasColumnType("timestamp(6) without time zone").HasColumnName("DH_OPERACAO");
            builder.Property(p => p.NuEmpresa).HasColumnName("NU_EMPRESA");
            builder.Property(p => p.NuUsuario).HasColumnName("NU_USUARIO");
        }
    }
}

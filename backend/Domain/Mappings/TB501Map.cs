using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Mappings
{
    public class TB501Map : IEntityTypeConfiguration<TB501_LOG_USUARIO>
    {
        public void Configure(EntityTypeBuilder<TB501_LOG_USUARIO> builder)
        {
            builder.ToTable("TB501_LOG_USUARIO");

            builder.HasKey(p => p.NuLogUsuario).HasName("PK_TB501");

            builder.Property(p => p.IcOperacao).HasColumnName("IC_OPERACAO");
            builder.Property(p => p.IcUsuario).HasColumnName("IC_USUARIO");
            builder.Property(p => p.DhOperacao).HasColumnType("timestamp(6) without time zone").HasColumnName("DH_OPERACAO");
            builder.Property(p => p.NuLogUsuario).HasColumnName("NU_LOG_USUARIO");
            builder.Property(p => p.NuUsuario).HasColumnName("NU_USUARIO");
            builder.Property(p => p.CoSenha).HasColumnName("CO_SENHA");
            builder.Property(p => p.NoEmail).HasColumnName("NO_EMAIL");
            builder.Property(p => p.NoUsuario).HasColumnName("NO_USUARIO");
        }
    }
}

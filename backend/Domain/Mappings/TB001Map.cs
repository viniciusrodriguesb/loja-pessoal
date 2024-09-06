using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Mappings
{
    public class TB001Map : IEntityTypeConfiguration<TB001_USUARIO>
    {
        public void Configure(EntityTypeBuilder<TB001_USUARIO> builder)
        {
            builder.ToTable("TB001_USUARIO");

            builder.HasKey(p => p.NuUsuario).HasName("PK_TB001");

            builder.Property(p => p.NuUsuario).HasColumnName("NU_USUARIO");
            builder.Property(p => p.IcUsuario).HasColumnName("IC_USUARIO");
            builder.Property(p => p.CoSenha).HasColumnName("CO_SENHA");
            builder.Property(p => p.NoEmail).HasColumnName("NO_EMAIL");
            builder.Property(p => p.NoUsuario).HasColumnName("NO_USUARIO");
        }
    }
}

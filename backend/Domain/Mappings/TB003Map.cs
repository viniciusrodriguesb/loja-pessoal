using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Mappings
{
    public class TB003Map : IEntityTypeConfiguration<TB003_USUARIO_EMPRESA>
    {
        public void Configure(EntityTypeBuilder<TB003_USUARIO_EMPRESA> builder)
        {
            builder.ToTable("TB003_USUARIO_EMPRESA");

            builder.HasKey(p => new { p.NuUsuario, p.NuEmpresa });

            builder.Property(p => p.NuUsuario).HasColumnName("NU_USUARIO");
            builder.Property(p => p.NuEmpresa).HasColumnName("NU_EMPRESA");

            builder.HasOne(n => n.UsuarioNavigation)
                   .WithMany(n => n.UsuarioEmpresaNavigation)
                   .HasForeignKey(f => f.NuUsuario);

            builder.HasOne(n => n.EmpresaNavigation)
                   .WithMany(n => n.UsuariosEmpresaNavigation)
                   .HasForeignKey(f => f.NuEmpresa);
        }
    }
}

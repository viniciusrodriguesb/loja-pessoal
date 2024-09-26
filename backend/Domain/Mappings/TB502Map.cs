using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Mappings
{
    public class TB502Map : IEntityTypeConfiguration<TB502_LOG_EMPRESA>
    {
        public void Configure(EntityTypeBuilder<TB502_LOG_EMPRESA> builder)
        {
            builder.ToTable("TB502_LOG_EMPRESA");

            builder.HasKey(p => p.NuLogEmpresa).HasName("PK_TB502");

            builder.Property(p => p.NuLogEmpresa).HasColumnName("NU_LOG_EMPRESA");
            builder.Property(p => p.NuEmpresa).HasColumnName("NU_EMPRESA");
            builder.Property(p => p.NoEmpresa).HasColumnName("NO_EMPRESA");
            builder.Property(p => p.CoCnpj).HasColumnName("CO_CNPJ");
            builder.Property(p => p.IcOperacao).HasColumnName("IC_OPERACAO");
            builder.Property(p => p.DhOperacao).HasColumnType("timestamp(6) without time zone").HasColumnName("DH_OPERACAO");
        }
    }
}

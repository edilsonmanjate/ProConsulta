using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProConsulta.Models;

namespace ProConsulta.Data.Configurations
{
    public class EspecialidadeConfiguration : IEntityTypeConfiguration<Especialidade>
    {
        public void Configure(EntityTypeBuilder<Especialidade> builder)
        {
            builder.ToTable("Especialidades");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

            builder.Property(p => p.Descricao)
                    .IsRequired(false)
                    .HasColumnType("varchar(150)");
            builder.HasMany(p => p.Medicos)
                .WithOne(p => p.Especialidade)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

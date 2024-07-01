using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProConsulta.Models;

namespace ProConsulta.Data.Configurations
{
    public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("Pacientes");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome)
                    .IsRequired() 
                    .HasColumnType("varchar(50)");
            builder.Property(p => p.Documento)
                   .IsRequired()
                   .HasColumnType("nvarchar(20)");

            builder.Property(p => p.Email)
                  .IsRequired()
                  .HasColumnType("varchar(50)");

            builder.Property(p => p.Celular)
                 .IsRequired()
                 .HasColumnType("nvarchar(15)");

            builder.HasIndex(p => p.Documento)
                  .IsUnique();

            builder.HasMany(a => a.Agendamentos)
              .WithOne(p => p.Paciente)
              .HasForeignKey(a => a.PacienteId)
              .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProConsulta.Models;

namespace ProConsulta.Data.Configurations
{
    public class MedicoConfiguration : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable("Medicos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

            builder.Property(p => p.Documento)
                   .IsRequired()
                   .HasColumnType("nvarchar(20)");

            builder.Property(p => p.CRM)
             .IsRequired()
             .HasColumnType("nvarchar(8)");


            builder.Property(p => p.Celular)
             .IsRequired()
             .HasColumnType("nvarchar(15)");

            builder.Property(p => p.EspecialidadeId)
                  .IsRequired();


            builder.HasIndex(p => p.Documento)
                  .IsUnique();

            builder.HasMany(a => a.Agendamentos)
                .WithOne(p => p.Medico)
                .HasForeignKey(a => a.MedicoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

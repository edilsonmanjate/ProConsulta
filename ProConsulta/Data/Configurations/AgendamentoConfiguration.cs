using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProConsulta.Models;

namespace ProConsulta.Data.Configurations
{
    public class AgendamentoConfiguration : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.ToTable("Agendamentos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Data)
                    .IsRequired()
                    .HasColumnType("date");
            builder.Property(p => p.Hora)
                .IsRequired()
                     .HasColumnType("time");
            builder.Property(p => p.Observacao)
                .HasColumnType("varchar(200)");
       
            builder.Property(p => p.PacienteId)
                    .IsRequired();
            builder.Property(p => p.MedicoId)
                .IsRequired();

        }
    }
}

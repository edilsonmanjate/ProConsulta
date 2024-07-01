using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using ProConsulta.Models;

using System.Reflection;

namespace ProConsulta.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Medico> Medicos { get; set; } 
        public DbSet<Paciente> Pacientes { get; set; } 
        public DbSet<Agendamento> Agendamentos { get; set; } 
        public DbSet<Especialidade> Especialidades { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            new DbInitializer(builder).Seed();
            base.OnModelCreating(builder); builder.Entity<Medico>();
        }
    }

}

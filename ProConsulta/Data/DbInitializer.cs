using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using ProConsulta.Models;

namespace ProConsulta.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        internal void Seed()
        {
            _modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "Medico", NormalizedName = "MEDICO" },
                new IdentityRole { Id = "3", Name = "Atendente", NormalizedName = "ATENDENTE" }
            );

            var hasher = new PasswordHasher<IdentityUser>();
            _modelBuilder.Entity<Atendente>().HasData(
                new Atendente
                {
                    Id = "1",
                    Nome = "Pro Consulta",
                    Email = "proconsulta@mail.com",
                    UserName = "proconsulta@mail.com",
                    EmailConfirmed = true,
                    NormalizedEmail = "PROCONSULTA@MAIL.COM",
                    NormalizedUserName = "PROCONSULTA@MAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "ProConsulta@123"),

                });

            _modelBuilder.Entity<IdentityUserRole<String>>().HasData(
                new IdentityUserRole<string> { UserId = "1", RoleId = "3" }
             );


            _modelBuilder.Entity<Especialidade>().HasData(
            // Descrições para cada especialidade
            new Especialidade { Id = 1, Nome = "Cardiologia", Descricao = "Especialidade que lida com o diagnóstico e tratamento de doenças cardíacas" },
            new Especialidade { Id = 2, Nome = "Dermatologia", Descricao = "Especialidade que se concentra no diagnóstico e tratamento de condições da pele" },
            new Especialidade { Id = 3, Nome = "Endocrinologia", Descricao = "Especialidade que lida com o diagnóstico e tratamento de distúrbios hormonais" },
            new Especialidade { Id = 4, Nome = "Gastroenterologia", Descricao = "Especialidade que se concentra no diagnóstico e tratamento de distúrbios do sistema digestivo" },
            new Especialidade { Id = 5, Nome = "Ginecologia", Descricao = "Especialidade que lida com o diagnóstico e tratamento de distúrbios do sistema reprodutor feminino" },
            new Especialidade { Id = 6, Nome = "Infectologia", Descricao = "Especialidade que se concentra no diagnóstico e tratamento de doenças infecciosas" },
            new Especialidade { Id = 7, Nome = "Neurologia", Descricao = "Especialidade que lida com o diagnóstico e tratamento de distúrbios do sistema nervoso" },
            new Especialidade { Id = 8, Nome = "Oftalmologia", Descricao = "Especialidade que se concentra no diagnóstico e tratamento de distúrbios oculares" },
            new Especialidade { Id = 9, Nome = "Ortopedia", Descricao = "Especialidade que lida com o diagnóstico e tratamento de distúrbios do sistema musculoesquelético" },
            new Especialidade { Id = 10, Nome = "Otorrinolaringologia", Descricao = "Especialidade que se concentra no diagnóstico e tratamento de distúrbios do ouvido, nariz e garganta" },
            new Especialidade { Id = 11, Nome = "Pediatria", Descricao = "Especialidade que lida com o atendimento médico de bebês, crianças e adolescentes" },
            new Especialidade { Id = 12, Nome = "Pneumologia", Descricao = "Especialidade que se concentra no diagnóstico e tratamento de distúrbios do sistema respiratório" },
            new Especialidade { Id = 13, Nome = "Psiquiatria", Descricao = "Especialidade que lida com o diagnóstico e tratamento de distúrbios mentais" },
            new Especialidade { Id = 14, Nome = "Reumatologia", Descricao = "Especialidade que se concentra no diagnóstico e tratamento de doenças reumáticas" },
            new Especialidade { Id = 15, Nome = "Urologia", Descricao = "Especialidade que lida com o diagnóstico e tratamento de distúrbios do sistema urinário" }

            );
        }
    }
}

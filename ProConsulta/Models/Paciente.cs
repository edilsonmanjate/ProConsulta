using System.ComponentModel.DataAnnotations;

namespace ProConsulta.Models
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Celular { get; set; } = null!;
        public DateTime DataNascimento { get; set; }

        public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
    }
}

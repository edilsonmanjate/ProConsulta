using System.ComponentModel.DataAnnotations;

namespace ProConsulta.Models
{
    public class Agendamento
    {
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; } 
        public string? Observacao { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public Medico Medico { get; set; } = null!;
        public Paciente Paciente { get; set; } = null!;

    }
}

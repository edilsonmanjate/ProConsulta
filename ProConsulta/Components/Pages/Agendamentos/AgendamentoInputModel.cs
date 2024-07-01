using System.ComponentModel.DataAnnotations;

namespace ProConsulta.Components.Pages.Agendamentos
{
    public class AgendamentoInputModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Data é obrigatório")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "O campo Hora é obrigatório")]
        public TimeSpan Hora { get; set; }
        [MaxLength(250, ErrorMessage = "O campo Observação deve ter no máximo 250 caracteres")]
        public string? Observacao { get; set; }

        [Required(ErrorMessage = "O campo Paciente é obrigatório")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Valor inválido")]
        public int PacienteId { get; set; }

        [Required(ErrorMessage = "O campo Médico é obrigatório")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Valor inválido")]
        public int MedicoId { get; set; }
    }
}

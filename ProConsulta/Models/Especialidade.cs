using System.ComponentModel.DataAnnotations;

namespace ProConsulta.Models
{
    public class Especialidade
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string? Descricao { get; set; }
        public ICollection<Medico> Medicos { get; set; } = new List<Medico>();



    }
}

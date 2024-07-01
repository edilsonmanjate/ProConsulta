using ProConsulta.Models;

namespace ProConsulta.Repositories.Agendamentos;
public interface IAgendamentoRepository
{
    Task<List<Agendamento>> GetAllAsync();
    Task<Agendamento?> GetByIdAsync(int id);
    Task AddAsync(Agendamento agendamento);
    Task UpdateAsync(Agendamento agendamento);
    Task DeleteAsync(int id);
    Task<List<AgendamentosAnuais>> GetReportAsync();
}


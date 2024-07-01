using ProConsulta.Models;

namespace ProConsulta.Repositories.Especialidades
{
    public interface IEspecialidadeRepository
    {
        Task<List<Especialidade>> GetAllAsync();
        Task<Especialidade?> GetByIdAsync(int id);
        Task AddAsync(Especialidade especialidade);
        Task UpdateAsync(Especialidade especialidade);
        Task DeleteAsync(int id);
    }

}

using ProConsulta.Models;

namespace ProConsulta.Repositories.Medicos
{
    public interface IMedicoRespository
    {
        Task AddAsync(Medico medico);
        Task UpdateAsync(Medico medico);
        Task<Medico?> GetByIdAsync(int id);
        Task<List<Medico>> GetAllAsync();
        Task DeleteByIdAsync(int id);


    }
}

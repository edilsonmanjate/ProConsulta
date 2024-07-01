using ProConsulta.Models;

namespace ProConsulta.Repositories.Pacientes
{
	public interface IPacienteRespository
    {
        Task AddAsync(Paciente paciente);
        Task UpdateAsync(Paciente paciente);
        Task<Paciente?> GetByIdAsync(int id);
        Task<List<Paciente>> GetAllAsync();
        Task DeleteByIdAsync(int id);


    }
}

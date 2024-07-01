using Microsoft.EntityFrameworkCore;

using ProConsulta.Data;
using ProConsulta.Models;

namespace ProConsulta.Repositories.Pacientes
{
	public class PacienteRespository : IPacienteRespository
	{
        private readonly ApplicationDbContext _context;
        public PacienteRespository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Paciente paciente)
        {
            await _context.Pacientes.AddAsync(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var paciente = await GetByIdAsync(id);
            if (paciente != null)
            {
                _context.Pacientes.Remove(paciente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Paciente>> GetAllAsync()
        {
            return await _context
                .Pacientes
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Paciente?> GetByIdAsync(int id)
        {
            return await _context.Pacientes.SingleOrDefaultAsync(p=>p.Id==id);
        }

        public async Task UpdateAsync(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);
            await _context.SaveChangesAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;

using ProConsulta.Data;
using ProConsulta.Models;

namespace ProConsulta.Repositories.Especialidades
{

    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly ApplicationDbContext _context;

        public EspecialidadeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Especialidade>> GetAllAsync()
        {
            return await _context
                .Especialidades
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Especialidade?> GetByIdAsync(int id)
        {
            return await _context.Especialidades.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddAsync(Especialidade especialidade)
        {
            try
            {
                _context.Especialidades.Add(especialidade);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                _context.ChangeTracker.Clear();
                throw;
            }
        }

        public async Task UpdateAsync(Especialidade especialidade)
        {
            try
            {
                _context.Especialidades.Update(especialidade);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                _context.ChangeTracker.Clear();
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var especialidade = await GetByIdAsync(id);
            if (especialidade != null)
            {
                _context.Especialidades.Remove(especialidade);
                await _context.SaveChangesAsync();
            }
        }
    }
}


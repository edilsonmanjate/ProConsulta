using Microsoft.EntityFrameworkCore;

using ProConsulta.Data;
using ProConsulta.Models;

namespace ProConsulta.Repositories.Medicos
{
    public class MedicoRespository : IMedicoRespository
    {
        private readonly ApplicationDbContext _context;
        public MedicoRespository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Medico medico)
        {
            try
                {
                await _context.Medicos.AddAsync(medico);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _context.ChangeTracker.Clear();
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            var medico = await GetByIdAsync(id);
            if (medico != null)
            {
                _context.Medicos.Remove(medico);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Medico>> GetAllAsync()
        {
            return await _context
                .Medicos
                .Include(x => x.Especialidade)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Medico?> GetByIdAsync(int id)
        {
            return await _context.Medicos.SingleOrDefaultAsync(p=>p.Id==id);
        }

        public async Task UpdateAsync(Medico medico)
        {
            try
            {
                _context.Medicos.Update(medico);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _context.ChangeTracker.Clear();
                throw new Exception(ex.Message);
            }
        }
    }
}

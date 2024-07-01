using Microsoft.EntityFrameworkCore;

using ProConsulta.Data;
using ProConsulta.Models;

namespace ProConsulta.Repositories.Agendamentos;
public class AgendamentoRepository : IAgendamentoRepository
{
    // Assuming you have a DbContext or similar for data access
    private readonly ApplicationDbContext _context;

    public AgendamentoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Agendamento>> GetAllAsync()
    {
        return await _context
            .Agendamentos
            .Include(a => a.Paciente)
            .Include(a => a.Medico)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Agendamento?> GetByIdAsync(int id)
    {
        return await _context.Agendamentos
            .Include(a => a.Paciente)
            .Include(a => a.Medico)
            .SingleOrDefaultAsync(a => a.Id == id);
    }

    public async Task AddAsync(Agendamento agendamento)
    {
        _context.Agendamentos.Add(agendamento);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Agendamento agendamento)
    {
        _context.Agendamentos.Update(agendamento);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var agendamento = await GetByIdAsync(id);
        if (agendamento != null)
        {
            _context.Agendamentos.Remove(agendamento);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<AgendamentosAnuais>> GetReportAsync()
    {
        var result= _context.Database.SqlQuery<AgendamentosAnuais>(
            $"Select month(data) as mes, count(*) as QuantidadeAgendamentos from agendamentos where year(Data) = year(getdate()) group by month(data) order by mes ")
            .ToList();

        return await Task.FromResult(result);
    }
}


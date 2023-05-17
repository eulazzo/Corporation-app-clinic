using Core.Domain;
using Data.Context;
using Manager.Interfaces.Repositories;

namespace Data.Repository;

public class EspecialidadeRepository : IEspecialidadeRepository
{
    private readonly DataContext _context;

    public EspecialidadeRepository(DataContext context)
    {
        this._context = context;
    }
    public async Task<Especialidade> Especialidade(Guid id)
    {
        return await _context.Especialidades.FindAsync(id);
    }

    public async Task<bool> ExisteAsync(Guid id)
    {
        return await _context.Especialidades.FindAsync(id) != null;
    }
}

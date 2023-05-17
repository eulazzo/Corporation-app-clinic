
using Core.Domain;

namespace Manager.Interfaces.Repositories;

public interface IEspecialidadeRepository
{
    Task<Especialidade> Especialidade(Guid id );
    Task<bool> ExisteAsync(Guid id);
}

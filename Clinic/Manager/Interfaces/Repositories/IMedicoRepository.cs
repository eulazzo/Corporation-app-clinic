using Core.Domain;
 
namespace Manager.Interfaces.Repositories;
public interface IMedicoRepository
{
    Task<IEnumerable<Medico>> GetMedicosAsync();

    Task<Medico> GetMedicoAsync(Guid id);

    Task<Medico> InsertMedicoAsync(Medico medico);

    Task<Medico> UpdateMedicoAsync(Medico medico);

    Task<Medico> DeleteMedicoAsync(Guid id);
}

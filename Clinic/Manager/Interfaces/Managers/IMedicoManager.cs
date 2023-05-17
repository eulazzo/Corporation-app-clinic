 
using ClCoreShared.ModelViews.Medico;
 

namespace Manager.Interfaces.Managers;

public interface IMedicoManager
{
    Task DeleteMedicoAsync(Guid id);

    Task<MedicoView> GetMedicoAsync(Guid id);

    Task<IEnumerable<MedicoView>> GetMedicosAsync();

    Task<MedicoView> InsertMedicoAsync(NovoMedico novoMedico);

    Task<MedicoView> UpdateMedicoAsync(AlteraMedico alteraMedico);
}

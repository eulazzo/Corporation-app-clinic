
using ClCoreShared.ModelViews.Cliente;

namespace Manager.Interfaces.Managers;

public interface IClienteManager
{
    Task<ClienteView> DeleteClientAsync(Guid id);

    Task<ClienteView> GetClientAsync(Guid id);

    Task<IEnumerable<ClienteView>> GetClientsAsync();

    Task<ClienteView> InsertClientAsync(NovoCliente cliente);

    Task<ClienteView> UpdateClientAsync(AlteraCliente cliente);
    //Task DeleteClientAsync(Guid id);
    //Task<ClienteView> GetClientAsync(Guid id);
    //Task<IEnumerable<ClienteView>> GetClientsAsync();

    //Task<ClienteView> InsertClientAsync(NovoCliente client);
    //Task<ClienteView> UpdateClientAsync(AlteraCliente client);
}

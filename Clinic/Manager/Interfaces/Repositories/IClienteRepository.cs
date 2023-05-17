
using Core.Domain;

namespace Manager.Interfaces.Repositories;

//Interface diz quais regras o repositorio associado a ela deve fazer

public interface IClienteRepository
{
    Task<Client> DeleteClientAsync(Guid id);

    Task<Client> GetClientAsync(Guid id);

    Task<IEnumerable<Client>> GetClientsAsync();

    Task<Client> InsertClientAsync(Client cliente);

    Task<Client> UpdateClientAsync(Client cliente);
}
    //Task DeleteClientAsync(Guid id);
    //Task<Client> GetClientAsync(Guid id);
    //Task<IEnumerable<Client>> GetClientsAsync();
    //Task<Client> InsertClientAsync(Client client);
    //Task<Client> UpdateClientAsync(Client client);

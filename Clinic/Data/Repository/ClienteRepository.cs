using Core.Domain;
using Data.Context;
using Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository;

//Acesso aos dados - Primeiro trazer o contexto
public class ClienteRepository : IClienteRepository
{
    private readonly DataContext _context;

    public ClienteRepository(DataContext context)
    {
        this._context = context;
    }

    //EM metodos async Sempre usar  task como return
    // Usar metodos com sufixs Async
    public async Task<IEnumerable<Client>> GetClientsAsync()
    {
        return await _context
            .Clients
            .Include(c => c.Telefones)
            .Include(c => c.Endereco)
            .ToListAsync();
    }


    public async Task<Client> GetClientAsync(Guid id)
    {
        return await _context
            .Clients
            .Include(c => c.Telefones)
            .Include(c=>c.Endereco)
            .SingleOrDefaultAsync(p=>p.Id == id);
    }

    //Insert
    public async Task<Client> InsertClientAsync(Client client)
    {
        await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync();  
        return client;
    }
    //Update
    public async Task<Client> UpdateClientAsync(Client client)
    {
        var clientFounded = await _context.Clients.FindAsync(client.Id);
        if (clientFounded == null)
        {
            return null;
        }

        _context.Entry(clientFounded).CurrentValues.SetValues(client);

        await _context.SaveChangesAsync();
        return clientFounded;
    }

    //Delete
    public async Task<Client> DeleteClientAsync(Guid id)
    {
        var clienteConsultado = await _context.Clients.FindAsync(id);
        if (clienteConsultado == null)
        {
            return null;
        }
        var clienteRemovido = _context.Clients.Remove(clienteConsultado);
        await _context.SaveChangesAsync();
        return clienteRemovido.Entity;
    }
}

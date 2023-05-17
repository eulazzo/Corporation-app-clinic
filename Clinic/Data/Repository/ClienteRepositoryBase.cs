using Core.Domain;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class ClienteRepositoryBase
    {
        private readonly DataContext _context;

        public ClienteRepositoryBase(DataContext context)
        {
            this._context = context;
        }

        public async Task<Client> GetClientAsync(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        //EM metodos async Sempre usar  task como return
        // Usar metodos com sufixs Async
        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await _context.Clients.ToListAsync();
        }
    }
}
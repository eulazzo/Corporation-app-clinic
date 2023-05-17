using AutoMapper;
using ClCoreShared.ModelViews;
using ClCoreShared.ModelViews.Cliente;
using Core.Domain;
using Manager.Interfaces;
using Manager.Interfaces.Managers;
using Manager.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using System;

namespace Manager.Implementatios;

public class ClientManager : IClienteManager
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;


    // Tiramos o aclopamento entre o negocio e o repositorio pq apontamos apenas para
    // o IClienteRepository no caso a interface. Essa classe em si nao conhece 
    // a implementaçao do cliente repositorio
    public ClientManager(IClienteRepository clienteRepository, IMapper _mapper,ILogger<ClientManager> logger)
    {
        this._clienteRepository = clienteRepository;
        this._mapper=_mapper;
        this._logger=logger;
    }

    public async Task<IEnumerable<ClienteView>> GetClientsAsync()
    {
        var clientes = await _clienteRepository.GetClientsAsync();
        return _mapper.Map<IEnumerable<Client>, IEnumerable<ClienteView>>(clientes);
    }

    public async Task<ClienteView> GetClientAsync(Guid id)
    {
        var cliente = await _clienteRepository.GetClientAsync(id);
        return _mapper.Map<ClienteView>(cliente);
    }

    public async Task<ClienteView> DeleteClientAsync(Guid id)
    {
        var cliente = await _clienteRepository.DeleteClientAsync(id);
        return _mapper.Map<ClienteView>(cliente);
    }

    public async Task<ClienteView> InsertClientAsync(NovoCliente novoClient)
    {
        _logger.LogInformation("Call for insert a customer !");
        var cliente = _mapper.Map<Client>(novoClient);
        cliente = await _clienteRepository.InsertClientAsync(cliente);
        return _mapper.Map<ClienteView>(cliente);
    }

    public async Task<ClienteView> UpdateClientAsync(AlteraCliente alteraCliente)
    {
        var cliente = _mapper.Map<Client>(alteraCliente);
        cliente = await _clienteRepository.UpdateClientAsync(cliente);
        return _mapper.Map<ClienteView>(cliente);
    }
}

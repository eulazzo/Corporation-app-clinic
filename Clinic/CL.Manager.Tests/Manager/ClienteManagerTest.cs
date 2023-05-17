using AutoMapper;
using Cl.FakeData.ClientData;
using ClCoreShared.ModelViews.Cliente;
using Core.Domain;
using FluentAssertions;
using Manager.Implementatios;
using Manager.Interfaces.Managers;
using Manager.Interfaces.Repositories;
using Manager.Mappings;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace CL.Manager.Tests.Manager;

public class ClienteManagerTest
{
    private readonly IClienteRepository repository;
    private readonly ILogger<ClientManager> logger;
    private readonly IMapper mapper;
    private readonly IClienteManager manager;
    private readonly Client client;
    private readonly NovoCliente NovoCliente;
    private readonly AlteraCliente AlteraCliente;
    private readonly ClienteFaker ClienteFaker;
    private readonly NovoClienteFaker NovoClienteFaker;
    private readonly AlteraClienteFaker AlteraClienteFaker;

    public ClienteManagerTest()
    {
        repository = Substitute.For<IClienteRepository>();
        logger = Substitute.For<ILogger<ClientManager>>();
        mapper = new MapperConfiguration(p => p.AddProfile<NewClientMappingsProfile>()).CreateMapper();
        manager = new ClientManager(repository, mapper, logger);
        ClienteFaker = new ClienteFaker();
        NovoClienteFaker = new NovoClienteFaker();
        AlteraClienteFaker = new AlteraClienteFaker();

        client = ClienteFaker.Generate();
        NovoCliente = NovoClienteFaker.Generate();
        AlteraCliente = AlteraClienteFaker.Generate();
    }

    [Fact]
    public async Task GetClientesAsync_Sucesso()
    {
        var listaClientes = ClienteFaker.Generate(10);
        repository.GetClientsAsync().Returns(listaClientes);
        var controle = mapper.Map<IEnumerable<Client>, IEnumerable<ClienteView>>(listaClientes);
        var retorno = await manager.GetClientsAsync();

        await repository.Received().GetClientsAsync();
        retorno.Should().BeEquivalentTo(controle);
    }

    [Fact]
    public async Task GetClientesAsync_Vazio()
    {
        repository.GetClientsAsync().Returns(new List<Client>());

        var retorno = await manager.GetClientsAsync();

        await repository.Received().GetClientsAsync();
        retorno.Should().BeEquivalentTo(new List<Client>());
    }

    [Fact]
    public async Task GetClienteAsync_Sucesso()
    {
        repository.GetClientAsync(Arg.Any<Guid>()).Returns(client);
        var controle = mapper.Map<ClienteView>(client);
        var retorno = await manager.GetClientAsync(client.Id);

        await repository.Received().GetClientAsync(Arg.Any<Guid>());
        retorno.Should().BeEquivalentTo(controle);
    }

    [Fact]
    public async Task GetClienteAsync_NaoEncontrado()
    {
        repository.GetClientAsync(Arg.Any<Guid>()).Returns(new Client());
        var controle = mapper.Map<ClienteView>(new Client());
        var retorno = await manager.GetClientAsync(new Guid());

        await repository.Received().GetClientAsync(Arg.Any<Guid>());
        retorno.Should().BeEquivalentTo(controle);
    }

    [Fact]
    public async Task InsertClienteAsync_Sucesso()
    {
        repository.InsertClientAsync(Arg.Any<Client>()).Returns(client);
        var controle = mapper.Map<ClienteView>(client);
        var retorno = await manager.InsertClientAsync(NovoCliente);

        await repository.Received().InsertClientAsync(Arg.Any<Client>());
        retorno.Should().BeEquivalentTo(controle);
    }

    [Fact]
    public async Task UpdateClienteAsync_Sucesso()
    {
        repository.UpdateClientAsync(Arg.Any<Client>()).Returns(client);
        var controle = mapper.Map<ClienteView>(client);
        var retorno = await manager.UpdateClientAsync(AlteraCliente);

        await repository.Received().UpdateClientAsync(Arg.Any<Client>());
        retorno.Should().BeEquivalentTo(controle);
    }

    [Fact]
    public async Task UpdateClienteAsync_NaoEncontrado()
    {
        repository.UpdateClientAsync(Arg.Any<Client>()).ReturnsNull();

        var retorno = await manager.UpdateClientAsync(AlteraCliente);

        await repository.Received().UpdateClientAsync(Arg.Any<Client>());
        retorno.Should().BeNull();
    }

    [Fact]
    public async Task DeleteClienteAsync_Sucesso()
    {
        repository.DeleteClientAsync(Arg.Any<Guid>()).Returns(client);
        var controle = mapper.Map<ClienteView>(client);
        var retorno = await manager.DeleteClientAsync(client.Id);

        await repository.Received().DeleteClientAsync(Arg.Any<Guid>());
        retorno.Should().BeEquivalentTo(controle);
    }

    [Fact]
    public async Task DeleteClienteAsync_NaoEncontrado()
    {
        repository.DeleteClientAsync(Arg.Any<Guid>()).ReturnsNull();

        var retorno = await manager.DeleteClientAsync(new Guid());

        await repository.Received().DeleteClientAsync(Arg.Any<Guid>());
        retorno.Should().BeNull();
    }
}


using Cl.FakeData.ClientData;
using Core.Domain;
using Data.Context;
using Data.Repository;
using Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using Cl.FakeData.TelefoneData;

namespace Cl.Repository.test.Repository;

public class ClienteRepositoryTest : IDisposable
{
    private readonly IClienteRepository repository;
    private readonly DataContext context;
    private readonly Client cliente;
    private readonly ClienteFaker clienteFaker;

    public ClienteRepositoryTest()
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());

        context = new DataContext(optionsBuilder.Options);
        repository = new ClienteRepository(context);

        clienteFaker = new ClienteFaker();
        cliente = clienteFaker.Generate();
    }
    //Garante que o Clean seja executado antes de cada teste ser executado!
    public void Dispose()
    {
        context.Database.EnsureDeleted();
    }

    private async Task<List<Client>> InsereRegistros()
    {
        var clients = clienteFaker.Generate(10);
        foreach (var item in clients)
        {
            //item.Id = 0;
            await context.Clients.AddAsync(item);
        }

        await context.SaveChangesAsync();
        return clients;
    }

    [Fact]
    public async Task GetClientsAsync_ComRetorno()
    {
        var registro = await InsereRegistros();
        var retorno = await repository.GetClientsAsync();

        retorno.Should().HaveCount(registro.Count);
        retorno.First().Endereco.Should().NotBeNull();
        retorno.First().Telefones.Should().NotBeNull();

    }

    [Fact]
    public async Task GetClientsAsync_Vazio()
    {
        var retorno = await repository.GetClientsAsync();
        retorno.Should().HaveCount(0);

    }

    public async Task GetClienteAsync_Encontrado()
    {
        var registros = await InsereRegistros();
        var retorno = await repository.GetClientAsync(registros.First().Id);
        retorno.Should().BeEquivalentTo(registros.First());
    }

    [Fact]
    public async Task GetClienteAsync_NaoEncontrado()
    {
        var retorno = await repository.GetClientAsync(new Guid());
        retorno.Should().BeNull();
    }

    [Fact]
    public async Task InsereClientAsync_Sucesso()
    {
        var retorno = await repository.InsertClientAsync(cliente);
        retorno.Should().BeEquivalentTo(cliente);
    }

    [Fact]
    public async Task UpdateClienteAsync_Sucesso()
    {
        var registros = await InsereRegistros(); // Gera 10 e insere no db
        var clienteAlterado = clienteFaker.Generate();
        clienteAlterado.Id = registros.First().Id;
        var retorno = await repository.UpdateClientAsync(clienteAlterado);
        retorno.Should().BeEquivalentTo(clienteAlterado);
    }

    [Fact]
    public async Task UpdateClienteAsync_AdicionaTelefone()
    {
        var registros = await InsereRegistros();
        var clienteAlterado = registros.First();
        clienteAlterado.Telefones.Add(new TelefoneFaker(clienteAlterado.Id).Generate());
        var retorno = await repository.UpdateClientAsync(clienteAlterado);
        retorno.Should().BeEquivalentTo(clienteAlterado);
    }


    [Fact]
    public async Task UpdateClienteAsync_RemoveTelefone()
    {
        var registros = await InsereRegistros();
        var clienteAlterado = registros.First();
        clienteAlterado.Telefones.Remove(clienteAlterado.Telefones.First());
        var retorno = await repository.UpdateClientAsync(clienteAlterado);
        retorno.Should().BeEquivalentTo(clienteAlterado);
    }

    [Fact]
    public async Task UpdateClienteAsync_RemoveTodosTelefones()
    {
        var registros = await InsereRegistros();
        var clienteAlterado = registros.First();
        clienteAlterado.Telefones.Clear();
        var retorno = await repository.UpdateClientAsync(clienteAlterado);
        retorno.Should().BeEquivalentTo(clienteAlterado);
    }
    [Fact]
    public async Task UpdateClienteAsync_NaoEncontrado()
    {
        var retorno = await repository.UpdateClientAsync(cliente);
        retorno.Should().BeNull();
    }

    [Fact]
    public async Task DeleteClienteAsync_Sucesso()
    {
        var registros = await InsereRegistros();
        var retorno = await repository.DeleteClientAsync(registros.First().Id);
        retorno.Should().BeEquivalentTo(registros.First());
    }
    [Fact]
    public async Task DeleteClienteAsync_NaoEncontrado()
    {
        var retorno = await repository.DeleteClientAsync(new Guid());
        retorno.Should().BeNull();
    }

}

using Api.Controllers;
using Manager.Interfaces.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;

using ClCoreShared.ModelViews.Cliente;
using Cl.ClientData.fakeData;
using Cl.FakeData.ClientData;
using NSubstitute.ReturnsExtensions;
using FluentAssertions;

namespace Cl.WebAPI.Tests.Controllers;

public class ClientesControllerTest
{
    private readonly IClienteManager _manager;
    private readonly ILogger<ClientsController> _logger;
    private readonly ClientsController controller;
    private readonly ClienteView clienteView;
    private readonly NovoCliente novoClient;
     
    private readonly List<ClienteView> ListaClienteView;
    public ClientesControllerTest()
    {
        _manager = Substitute.For<IClienteManager>();
        _logger = Substitute.For<ILogger<ClientsController>>();
        this.controller = new ClientsController(_manager, _logger);
        this.clienteView = new ClienteViewFaker().Generate();
        this.ListaClienteView = new ClienteViewFaker().Generate(50);
        this.novoClient = new NovoClienteFaker().Generate();
    }
    [Fact]
    public async Task Get_Ok()
    {


        var control = new List<ClienteView>();
        this.ListaClienteView.ForEach(p => control.Add(p.CloneTipado()));
        _manager.GetClientsAsync().Returns(this.ListaClienteView);

        var result = (ObjectResult)await controller.Get();


        await _manager.Received().GetClientsAsync();
        result.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.Value.Should().BeEquivalentTo(control);
    }

    [Fact]
    public async Task Get_NotFound()
    {
        _manager.GetClientsAsync().Returns(new List<ClienteView>());
        var result = (StatusCodeResult)await controller.Get();
        await _manager.Received().GetClientsAsync();
        result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }
    [Fact]

    public async Task GetById_OK()
    {
        _manager.GetClientAsync(Arg.Any<Guid>()).Returns(clienteView.CloneTipado());

        var resultado = (ObjectResult)await controller.Get(clienteView.Id);

        await _manager.Received().GetClientAsync(Arg.Any<Guid>());
        resultado.Value.Should().BeEquivalentTo(clienteView);
        resultado.Value.Should().Be(StatusCodes.Status200OK);

    }
    [Fact]

    public async Task GetById_NotFound()
    {
        _manager.GetClientAsync(Arg.Any<Guid>()).Returns(new ClienteView());

        var resultado = (StatusCodeResult)await controller.Get(new Guid());

        await _manager.Received().GetClientAsync(Arg.Any<Guid>());
        resultado.StatusCode.Should().Be(StatusCodes.Status404NotFound);

    }

    [Fact]

    public async Task Post_Created()
    {
        _manager.InsertClientAsync(Arg.Any<NovoCliente>()).Returns(clienteView.CloneTipado());

        var resultado = (ObjectResult)await controller.Post(novoClient);

        await _manager.Received().InsertClientAsync(Arg.Any<NovoCliente>());
        resultado.StatusCode.Should().Be(StatusCodes.Status201Created);
        resultado.Value.Should().BeEquivalentTo(clienteView);
    }

    [Fact]
    public async Task Put_Ok()
    {
        _manager.UpdateClientAsync(Arg.Any<AlteraCliente>()).Returns(clienteView.CloneTipado());

        var resultado = (ObjectResult)await controller.Put(new AlteraCliente());

        await _manager.Received().UpdateClientAsync(Arg.Any<AlteraCliente>());
        resultado.StatusCode.Should().Be(StatusCodes.Status200OK);
        resultado.Value.Should().BeEquivalentTo(clienteView);
    }

    [Fact]
    public async Task Put_NotFound()
    {
        _manager.UpdateClientAsync(Arg.Any<AlteraCliente>()).ReturnsNull();

        var resultado = (StatusCodeResult)await controller.Put(new AlteraCliente());

        await _manager.Received().UpdateClientAsync(Arg.Any<AlteraCliente>());
        resultado.StatusCode.Should().Be(StatusCodes.Status404NotFound);

    }

    [Fact]
    public async Task Delete_NoContent()
    {
        _manager.DeleteClientAsync(Arg.Any<Guid>()).Returns(clienteView);

        var resultado = (StatusCodeResult)await controller.Delete(new Guid());

        await _manager.Received().DeleteClientAsync(Arg.Any<Guid>());
        resultado.StatusCode.Should().Be(StatusCodes.Status204NoContent);
    }

    [Fact]
    public async Task NotFound_NotFound()
    {
        _manager.DeleteClientAsync(Arg.Any<Guid>()).ReturnsNull();

        var resultado = (StatusCodeResult)await controller.Delete(new Guid());

        await _manager.Received().DeleteClientAsync(Arg.Any<Guid>());
        resultado.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }


}
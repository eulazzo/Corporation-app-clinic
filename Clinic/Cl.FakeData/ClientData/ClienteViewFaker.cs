using Bogus;
using Bogus.Extensions.Brazil;
using Cl.FakeData.EnderecoData;
using Cl.FakeData.TelefoneData;
using ClCoreShared.ModelViews.Cliente;

namespace Cl.ClientData.fakeData;

public class ClienteViewFaker:Faker<ClienteView>
{
	public ClienteViewFaker()
	{
		var id = new Guid();
		RuleFor(p => p.Id, f => id);
		RuleFor(p => p.Nome, f => f.Person.FullName);
		RuleFor(p => p.Sexo, f => f.PickRandom<SexoView>());
		RuleFor(p => p.Documento, f =>f.Person.Cpf());
		RuleFor(p => p.Criacao, f =>f.Date.Past());
		RuleFor(p => p.UltimaAtualizacao, f =>f.Date.Past());
		RuleFor(p => p.DataNascimento, f => f.Date.Past());
        RuleFor(p => p.Telefones, _ => new TelefoneViewFaker().Generate(3));
        RuleFor(p => p.Endereco, _ => new EnderecoViewFaker().Generate());
    }
}

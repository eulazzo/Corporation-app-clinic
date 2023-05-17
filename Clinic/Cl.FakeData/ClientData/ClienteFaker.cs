using Bogus;
using Core.Domain;
using Bogus.Extensions.Brazil;
using Cl.FakeData.TelefoneData;
using Cl.FakeData.EnderecoData;

namespace Cl.FakeData.ClientData;

public class ClienteFaker : Faker<Client>
{
    public ClienteFaker()
    {
        var id = new Guid();
        RuleFor(o => o.Id, _ => id);
        RuleFor(o => o.Nome, f => f.Person.FullName);
        RuleFor(o => o.Sexo, f => f.PickRandom<Sexo>());
        RuleFor(o => o.Documento, f => f.Person.Cpf());
        RuleFor(o => o.Criacao, f => f.Date.Past());
        RuleFor(o => o.UltimaAtualizacao, f => f.Date.Past());
        RuleFor(o => o.Telefones, _ => new TelefoneFaker(id).Generate(3));
        RuleFor(o => o.Endereco, _ => new EnderecoFaker(id).Generate());
    }
}

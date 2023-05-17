using Bogus;
using ClCoreShared.ModelViews.Cliente;
 
namespace Cl.FakeData.ClientData;
public class AlteraClienteFaker : Faker<AlteraCliente>
{
    public AlteraClienteFaker()
    {
        var id = new Guid();
        RuleFor(o => o.Id, _ => id);
        RuleFor(o => o.Nome, f => f.Person.FullName);
        RuleFor(o => o.Sexo, f => f.PickRandom<SexoView>());
        RuleFor(o => o.Telefones, _ => new NovoTelefoneFaker().Generate(3));
        RuleFor(o => o.Endereco, _ => new NovoEnderecoFaker().Generate());
    }
}
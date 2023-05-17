
using Bogus;
using ClCoreShared.ModelViews.Telefone;

namespace Cl.FakeData.TelefoneData;

public class TelefoneViewFaker : Faker<TelefoneView>
{
    public TelefoneViewFaker()
    {
        RuleFor(p => p.Id, f => f.Random.Number(1, 10));
        RuleFor(p => p.Numero, f => f.Person.Phone);
    }
}
using Bogus;
using ClCoreShared.ModelViews.Telefone;

public class NovoTelefoneFaker : Faker<NovoTelefone>
{
    public NovoTelefoneFaker()
    {
        RuleFor(p => p.Numero, f => f.Person.Phone);
    }
}

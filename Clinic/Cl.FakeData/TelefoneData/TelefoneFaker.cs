using Bogus;
using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cl.FakeData.TelefoneData;

public class TelefoneFaker : Faker<Telefone>
{
    public TelefoneFaker(Guid clientId)
    {
        RuleFor(o => o.ClientId, _ => clientId);
        RuleFor(o => o.Numero, f => f.Person.Phone);
    }
}

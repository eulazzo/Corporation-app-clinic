using ClCoreShared.ModelViews;
using ClCoreShared.ModelViews.Cliente;
using FluentValidation;

namespace Manager.Validator;

public class NewClientValidator : AbstractValidator<AlteraCliente>
{
    public NewClientValidator()
    {

        RuleFor(x => x.Nome).NotNull().NotEmpty().MinimumLength(10).MaximumLength(150);
        RuleFor(x => x.DataNascimento).NotNull().NotEmpty().LessThan(DateTime.Now).GreaterThan(DateTime.Now.AddYears(-130));
        RuleFor(x => x.Documento).NotNull().NotEmpty().MinimumLength(4).MaximumLength(14);
        RuleFor(x => x.Telefones).NotNull().NotEmpty();
        RuleFor(x => x.Sexo).NotNull().NotEmpty(); 
        RuleFor(x => x.Endereco).SetValidator(new NewAddressValidator());

    }


}

namespace Manager.Validator;

using ClCoreShared.ModelViews;
using ClCoreShared.ModelViews.Telefone;
using FluentValidation;

public class NovoTelefoneValidator:AbstractValidator<NovoTelefone>
{
    public NovoTelefoneValidator()
    {
        RuleFor(c => c.Numero).Matches("[1-9][0-]{10}").WithMessage("O telefone tem que ter o formato [2-9][0-9]{10}");

    }
}

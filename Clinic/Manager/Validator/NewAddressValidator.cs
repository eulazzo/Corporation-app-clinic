using ClCoreShared.ModelViews;
using ClCoreShared.ModelViews.Endereco;
using FluentValidation;

namespace Manager.Validator;
public class NewAddressValidator : AbstractValidator<NovoEndereco>
{
	public NewAddressValidator()
	{
		RuleFor(p => p.Cidade).NotEmpty().NotNull().MaximumLength(200);
		RuleFor(p => p.Estado).NotNull();
    }
}

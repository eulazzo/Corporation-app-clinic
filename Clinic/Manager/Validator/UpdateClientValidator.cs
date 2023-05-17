
using ClCoreShared.ModelViews;
using ClCoreShared.ModelViews.Cliente;
using FluentValidation;

namespace Manager.Validator;

public class UpdateClientValidator :  AbstractValidator<AlteraCliente> 
{
	public UpdateClientValidator()
	{
        RuleFor(x => x.Id).NotNull().NotEmpty();
        Include(new NewClientValidator());

    }
}

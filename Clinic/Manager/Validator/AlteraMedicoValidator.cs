using ClCoreShared.ModelViews.Medico;
using FluentValidation;
using Manager.Interfaces.Repositories;

namespace Manager.Validator;
public class AlteraMedicoValidator : AbstractValidator<AlteraMedico>
{
	public AlteraMedicoValidator(IEspecialidadeRepository repository)
	{
		RuleFor(p => p.CRM).NotEmpty();
		RuleFor(p => p.Id).NotEmpty().NotNull();
		Include(new NovoMedicoValidator(repository));
	}
}

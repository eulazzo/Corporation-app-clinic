using ClCoreShared.ModelViews.Medico;
using FluentValidation;
using Manager.Interfaces.Repositories;

namespace Manager.Validator;
public class NovoMedicoValidator : AbstractValidator<NovoMedico>
{
    public NovoMedicoValidator(IEspecialidadeRepository especialidadeRepository)
    {
        RuleFor(p => p.Nome).NotEmpty().NotNull().MaximumLength(200);
        RuleFor(p => p.CRM).NotNull().NotEmpty().GreaterThan(0);
        RuleForEach(p => p.Especialidades).SetValidator(new ReferenciaEspecialidadeValidator(especialidadeRepository));
    }
}

using ClCoreShared.ModelViews.Especialidade;
using ClCoreShared.ModelViews.Medico;
using FluentValidation;
using Manager.Interfaces.Managers;
using Manager.Interfaces.Repositories;

namespace Manager.Validator;
public class ReferenciaEspecialidadeValidator : AbstractValidator<ReferenciaEspecialidade>
{
    private readonly IEspecialidadeRepository _especialidadeRepository;

    public ReferenciaEspecialidadeValidator(IEspecialidadeRepository especialidadeRepository)
    {
        this._especialidadeRepository = especialidadeRepository;
        RuleFor(p => p.Id)
            .NotNull()
           //.MustAsync(ExisteNaBase)
            .WithMessage("Especialidade não cadastrada!");
    }
     
    private async Task<bool> ExisteNaBase(Guid id, CancellationToken cancellationToken)
    {
        return await _especialidadeRepository.ExisteAsync(id);

    }
}

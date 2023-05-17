using ClCoreShared.ModelViews.Especialidade;

namespace ClCoreShared.ModelViews.Medico;

public class MedicoView
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public int CRM { get; set; }

    public ICollection<EspecialidadeView> Especialidades { get; set; }
}

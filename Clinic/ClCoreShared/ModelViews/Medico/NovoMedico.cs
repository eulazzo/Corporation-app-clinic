

using ClCoreShared.ModelViews.Especialidade;

namespace ClCoreShared.ModelViews.Medico;

public class NovoMedico
{
    public string Nome { get; set; }
    public int CRM { get; set; }
    public ICollection<ReferenciaEspecialidade> Especialidades { get; set; }
}

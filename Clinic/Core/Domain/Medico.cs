namespace Core.Domain;

public class Medico
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string CRM{ get; set; }

    public ICollection<Especialidade> Especialidades { get; set; }

    public Medico()
    {
        Especialidades = new HashSet<Especialidade>();
    }
}

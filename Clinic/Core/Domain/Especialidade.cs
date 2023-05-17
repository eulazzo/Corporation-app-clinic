namespace Core.Domain;

public class Especialidade
{
    public Guid Id { get; set; }
    public string Descricao { get; set; }
    public ICollection<Medico> Medicos { get; set; }
}
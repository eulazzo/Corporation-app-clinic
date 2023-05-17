namespace Core.Domain;

public class Telefone
{
    //Aqui vamos definir clientId e Numero como chaves compostas.
    public Guid ClientId { get; set; }
    public string Numero { get; set; } 
    public Client Client{ get; set; }
}
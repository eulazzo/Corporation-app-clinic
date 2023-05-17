namespace Core.Domain; 

public class Endereco
{
    public Guid ClientId{ get; set; }
    public int CEP  { get; set; }
    public Estado Estado{ get; set; }
    public string Cidade{ get; set; }
    public string Logradouro{ get; set; }
    public string Numero{ get; set; }
    public string Complemento { get; set; }
    public Client Cliente { get; set; }
}
namespace ClCoreShared.ModelViews.Endereco;

public class NovoEndereco
{
    /// <example>39390000 </example>
    public int CEP { get; set; }
    public EstadoView Estado { get; set; }
    /// <example>Bocaiuva </example>

    public string Cidade { get; set; }
    /// <example>Rua A </example>

    public string Logradouro { get; set; }
    /// <example>652 </example>

    public string Numero { get; set; }
    /// <example>Casa </example>

    public string Complemento { get; set; }
}

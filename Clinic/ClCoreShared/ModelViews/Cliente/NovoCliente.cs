using ClCoreShared.ModelViews.Endereco;
using ClCoreShared.ModelViews.Telefone;
using Core.Domain;

namespace ClCoreShared.ModelViews.Cliente;

/// <summary>
///     Object used to insert a customer into the database
/// </summary>
public class NovoCliente
{
    public Guid Id { get; set; }
    /// <summary>
    ///   Customer name
    /// </summary>
    /// <example>Jhon Doe</example>
    public string Nome { get; set; } = String.Empty;
    /// <summary>
    ///  Customer Birthday
    /// </summary>
    /// <example>2000-01-01</example>
    public DateTime DataNascimento { get; set; }
    /// <summary>
    /// Customer Gender
    /// </summary>
    /// <example>F</example>
    public SexoView Sexo { get; set; } 

    /// <summary>
    ///  Customer Register : CNH, CPF or RG
    /// </summary>
    /// <example>12938293829</example>
    public string Documento { get; set; } = string.Empty;
    public NovoEndereco Endereco { get; set; }

    public ICollection<NovoTelefone> Telefones { get; set; }
}


using Core.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Data.Configurations;

public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        //Essa linha nao é necessaria dependendo da configuraçao la na entidade
        //Se tivermos Objeto de endereco em cliente e cliente em endereço por padrao EF ja sabe que 
        //trata de uma relaciomaneot 1:1
        //builder.HasOne(p => p.Cliente).WithOne(p => p.Endereco).HasForeignKey<Endereco>(p => p.ClienteId);

        builder.HasKey(p => p.ClientId);

        builder.Property(x => x.Estado)
            .HasConversion(p => p.ToString(), p => (Estado)Enum.Parse(typeof(Estado), p));
    }
}

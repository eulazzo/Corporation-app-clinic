using Core.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Data.Configurations;

public class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
{
    public void Configure(EntityTypeBuilder<Telefone> builder)
    {
        //Essa config nao precisa porque ja configuramos nas entidades de forma implicita
        //builder.HasOne(p => p.Client).WithMany(p => p.Telefones).IsRequired().OnDelete(DeleteBehavior.Cascade);
        builder.HasKey(p => new { p.ClientId, p.Numero });
    }
}

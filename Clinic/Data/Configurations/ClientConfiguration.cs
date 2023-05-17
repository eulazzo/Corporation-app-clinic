

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Core.Domain;

namespace Data.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Customers");

        //builder.HasKey(p => p.Id);
        builder.Property(p => p.Nome)
            .HasColumnType("varchar")
            .HasMaxLength(180).IsRequired();
        builder.Property(x => x.Sexo).HasConversion(p => p.ToString(), p => (Sexo)Enum.Parse(typeof(Sexo), p)); ;
        //builder.Property(p => p.Sexo)
        //    .HasColumnType("varchar")
        //    .HasMaxLength(1).IsRequired();
        //builder.Property(p => p.Telefone)
        //    .HasColumnType("varchar")
        //    .HasMaxLength(14).IsRequired();
        //builder.Property(p => p.DataNascimento)
        //  .IsRequired();
        //builder.Property(p => p.Criacao)
        //  .IsRequired();
        //builder.Property(p => p.Documento)
        //.HasColumnType("varchar")
        //.HasMaxLength(14)
        //  .IsRequired();
        //builder.Property(p => p.UltimaAtualizacao)
        // .IsRequired(); 
    }
}

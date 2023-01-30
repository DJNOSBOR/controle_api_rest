using Controle.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Controle.Data.EntityConfig
{
    public class CarteiraEntityConfig : IEntityTypeConfiguration<Carteira>
    {
        public void Configure(EntityTypeBuilder<Carteira> builder)
        {
            builder.ToTable("Carteira");
            builder.HasAlternateKey(c => c.Id);

            builder.Property(c => c.Nome).IsRequired();
            builder.Property(c => c.Valor).IsRequired();
        }
    }
}

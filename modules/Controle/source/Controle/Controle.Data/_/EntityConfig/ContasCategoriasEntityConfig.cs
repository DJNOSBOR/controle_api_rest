using Controle.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Controle.Services.EntityConfig
{
    public class ContasCategoriasEntityConfig : IEntityTypeConfiguration<ContasCategorias>
    {
        public void Configure(EntityTypeBuilder<ContasCategorias> builder)
        {
            builder.ToTable("ContasCategorias");
            builder.HasAlternateKey(c => c.Id);

            builder.Property(c => c.Nome).IsRequired();
            builder.Property(c => c.DataInsersao).IsRequired();
            builder.Property(c => c.Color).IsRequired(false);

        }
    }
}

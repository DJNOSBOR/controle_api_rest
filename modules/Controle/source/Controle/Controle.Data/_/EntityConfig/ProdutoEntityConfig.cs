using Controle.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Controle.Services.EntityConfig
{
    public class ProdutoEntityConfig : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");
            builder.HasAlternateKey(c => c.Id);

            builder.Property(c => c.Nome).IsRequired();
            builder.Property(c => c.Valor).IsRequired(false);
            builder.Property(c => c.DataCriacao).IsRequired(false);

        }
    }
}

using Controle.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Data.EntityConfig
{
    public class ProdutoCategoriaEntityConfig : IEntityTypeConfiguration<ProdutoCategoria>
    {
        public void Configure(EntityTypeBuilder<ProdutoCategoria> builder)
        {
            builder.ToTable("ProdutoCategoria");
            builder.HasAlternateKey(c => c.Id);

            builder.Property(c => c.Nome).IsRequired();
            builder.Property(c => c.DataInsercao).IsRequired(false);
            builder.Property(c => c.Color).IsRequired(false);
            
        }
    }
}

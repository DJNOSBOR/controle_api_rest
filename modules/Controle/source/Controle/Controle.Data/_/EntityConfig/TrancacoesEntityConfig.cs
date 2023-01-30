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
    public class TrancacoesEntityConfig : IEntityTypeConfiguration<Transacoes>
    {
        public void Configure(EntityTypeBuilder<Transacoes> builder)
        {
            builder.ToTable("Transacoes");
            builder.HasAlternateKey(c => c.Id);

            builder.Property(c => c.TipoTransacao).IsRequired();
            builder.Property(c => c.Nome).IsRequired();
            builder.Property(c => c.Valor).IsRequired(false);
            builder.Property(c => c.Data).IsRequired(false);
            builder.Property(c => c.Data).IsRequired(false);
            builder.Property(c => c.IdConta).IsRequired(false);
            builder.Property(c => c.IdParcela).IsRequired(false);

        }
    }
}

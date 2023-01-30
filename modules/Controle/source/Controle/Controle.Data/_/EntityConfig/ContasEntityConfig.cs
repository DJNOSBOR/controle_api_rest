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
    public class ContasEntityConfig : IEntityTypeConfiguration<Contas>
    {
        public void Configure(EntityTypeBuilder<Contas> builder)
        {
            builder.ToTable("Contas");
            builder.HasAlternateKey(c => c.Id);

            builder.Property(c => c.NomeConta).IsRequired();
            builder.Property(c => c.DataInsercao).IsRequired(false);
            builder.Property(c => c.ValorTotal).IsRequired(false);
            builder.Property(c => c.ContaFixa).IsRequired(false);
            builder.Property(c => c.IsPago).IsRequired(false);
            builder.Property(c => c.CategoriaConta).IsRequired(false);

        }
    }
}

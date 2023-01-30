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
    public class ContasParcelasEntityConfig : IEntityTypeConfiguration<ContasParcelas>
    {
        public void Configure(EntityTypeBuilder<ContasParcelas> builder)
        {
            builder.ToTable("ContasParcelas");
            builder.HasAlternateKey(c => c.Id);

            builder.Property(c => c.Valor).IsRequired();
            builder.Property(c => c.DataVencimento).IsRequired(false);
            builder.Property(c => c.IsPago).IsRequired(false);
            builder.HasOne(c => c.Contas).WithMany(d=> d.Parcelas).HasForeignKey(d => d.IdConta);
        }
    }
}

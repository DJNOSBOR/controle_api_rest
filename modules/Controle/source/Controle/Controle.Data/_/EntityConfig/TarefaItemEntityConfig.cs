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
    public class TarefaItemEntityConfig : IEntityTypeConfiguration<TarefasItem>
    {
        public void Configure(EntityTypeBuilder<TarefasItem> builder)
        {
            builder.ToTable("TarefaItem");
            builder.HasAlternateKey(c => c.Id);

            builder.Property(c => c.Nome).IsRequired();
            builder.Property(c => c.Dia).IsRequired();            
            builder.HasOne(c => c.Tarefa).WithMany(d => d.Tarefas).HasForeignKey(d => d.TarefaId);
        }
    }
}

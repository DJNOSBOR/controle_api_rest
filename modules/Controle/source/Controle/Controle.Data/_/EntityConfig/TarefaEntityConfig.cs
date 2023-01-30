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
    public class TarefaEntityConfig : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("Tarefa");
            builder.HasAlternateKey(c => c.Id);

            builder.Property(c => c.Nome).IsRequired();
            builder.Property(c => c.Dia).IsRequired();            
        }
    }
}

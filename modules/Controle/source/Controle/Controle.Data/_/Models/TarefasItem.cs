using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Data.Models
{
    public class TarefasItem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Dia { get; set; }
        public int? TarefaId { get; set; }
        public Tarefa? Tarefa { get; set; }
    }
}

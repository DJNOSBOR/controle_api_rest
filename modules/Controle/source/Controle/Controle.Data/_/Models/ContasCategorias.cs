using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Data.Models
{
    public class ContasCategorias
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public DateTime? DataInsersao { get; set; }
        public string? Color { get; set; }
    }
}

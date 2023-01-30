using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Data.Models
{
    public class Contas
    {
        public int Id { get; set; }
        public string? NomeConta { get; set; }
        public DateTime? DataInsercao { get; set; }
        public decimal? ValorTotal { get; set; }
        public bool? ContaFixa { get; set; }
        public bool? IsPago { get; set; }
        public int? CategoriaConta { get; set; }   
        public List<ContasParcelas>? Parcelas { get; set; }
    }
}

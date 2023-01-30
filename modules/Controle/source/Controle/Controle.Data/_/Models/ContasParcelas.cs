using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Data.Models
{
    public class ContasParcelas
    {
        public int Id { get; set; }
        public decimal? Valor { get; set; }
        public DateTime? DataVencimento { get; set; }
        public bool? IsPago { get; set; }
        public int? IdConta { get; set; }
        public Contas? Contas { get; set; }

    }
}

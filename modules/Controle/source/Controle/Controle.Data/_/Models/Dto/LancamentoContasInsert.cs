using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Data.Models.Dto
{
    public class LancamentoContasInsert
    {
        public Contas Conta { get; set; }
        public int QuantidadeParcelas {get;set;}
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}

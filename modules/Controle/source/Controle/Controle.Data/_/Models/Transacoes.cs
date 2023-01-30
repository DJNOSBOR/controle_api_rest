using Controle.Data.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Data.Models
{
    public class Transacoes
    {
        public int Id { get; set; }
        public TipoTransacaoEnum TipoTransacao { get; set; }
        public string Nome { get; set; }
        public float? Valor { get; set; }
        public DateTime? Data { get; set; }
        public int? IdConta { get; set; }
        public int? IdParcela { get; set; }
        public bool? Cancelado { get; set; }
    }
}

using Controle.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Data.Interfaces
{
    public interface ITransacoesService: IDisposable
    {
        Task<List<Transacoes>> GetTransacoesAsync();

        Task<Transacoes> GetTransacoesByIdAsync(int id);

        Task<Transacoes> PostOrPutTransacoesAsync(Transacoes data);

        Task<bool> DeleteTransacoesAsync(int Id);

    }
}

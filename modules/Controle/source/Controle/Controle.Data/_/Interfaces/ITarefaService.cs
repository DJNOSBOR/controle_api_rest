using Controle.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Data.Interfaces
{
    public interface ITarefaService : IDisposable
    {
        Task<bool> DeleteTarefaItemAsync(int id);

        Task<List<Tarefa>> GetTarefaAsync();

        Task<Tarefa> GetTarefaByIdAsync(int id);

        Task<Tarefa> PostOrPutTarefaAsync(Tarefa data);

        Task<bool> DeleteTarefaAsync(int Id);
    }
}

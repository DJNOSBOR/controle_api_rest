using Controle.Data.Context;
using Controle.Data.Interfaces;
using Controle.Data.Models;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Controle.Services
{
    public class TarefaService : ITarefaService, ISelfBindable
    {
        private ControleDbContext _controleDbContext;
        public TarefaService(ControleDbContext controleDbContext)
        {
            _controleDbContext = controleDbContext;
        }

        public void Dispose()
        {
            try
            {
                _controleDbContext.Dispose();
            }
            catch (Exception ex)
            {
                throw ex.Failin();
            }
        }

        public async Task<bool> DeleteTarefaItemAsync(int id)
        {
            try
            {
                var data = this._controleDbContext.TarefasItens.Find(id);
                if(data != null)
                {
                    this._controleDbContext.TarefasItens.Remove(data);
                    this._controleDbContext.SaveChanges();
                    return await Task.FromResult(true);
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

        public async Task<List<Tarefa>> GetTarefaAsync()
        {
            try
            {
                var data = await this._controleDbContext.Tarefas.ToListAsync();
                foreach (var item in data)
                {
                    item.Tarefas = this._controleDbContext.TarefasItens.Where((a) => a.TarefaId == item.Id).ToList();
                }
                var t = data.OrderBy((a) => a.Dia).ToList();
                
                return await Task.FromResult(t);
            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

        public async Task<Tarefa> GetTarefaByIdAsync(int id)
        {
            try
            {
                var data = await this._controleDbContext.Tarefas.FindAsync(id);
                if(data != null){
                    data.Tarefas = this._controleDbContext.TarefasItens.Where((a) => a.TarefaId == data.Id).ToList();
                }
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

        public async Task<Tarefa> PostOrPutTarefaAsync(Tarefa data)
        {
            try
            {
                this._controleDbContext.Tarefas.AddOrUpdate(data);
                this._controleDbContext.SaveChanges();

                return await Task.FromResult(data);

            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

        public async Task<bool> DeleteTarefaAsync(int Id)
        {
            try
            {
                var data = this._controleDbContext.Tarefas.Find(Id);
                if (data != null)
                {
                    data.Tarefas = this._controleDbContext.TarefasItens.Where((a) => a.TarefaId == data.Id).ToList();
                }
                if (data != null)
                {
                    this._controleDbContext.Tarefas.Remove(data);
                    this._controleDbContext.SaveChanges();
                    return await Task.FromResult(true);
                }
                else
                {
                    return await Task.FromResult(false);
                }

            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

    

    }
}

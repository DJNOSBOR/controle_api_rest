using Controle.Data.Context;
using Controle.Data.Interfaces;
using Controle.Data.Models;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Controle.Services
{
    public class TransacoesService : ITransacoesService, ISelfBindable
    {
        private ControleDbContext _controleDbContext;
        public TransacoesService(ControleDbContext controleDbContext)
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

        public async Task<List<Transacoes>> GetTransacoesAsync()
        {
            try
            {
                var data = await this._controleDbContext.Transacoes.ToListAsync();
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

        public async Task<Transacoes> GetTransacoesByIdAsync(int id)
        {
            try
            {
                var data = await this._controleDbContext.Transacoes.FindAsync(id);
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

        public async Task<Transacoes> PostOrPutTransacoesAsync(Transacoes data)
        {
            try
            {
                this._controleDbContext.Transacoes.AddOrUpdate(data);
                this._controleDbContext.SaveChanges();

                return await Task.FromResult(data);

            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

        public async Task<bool> DeleteTransacoesAsync(int Id)
        {
            try
            {
                var meta = this._controleDbContext.Transacoes.Find(Id);
                if (meta != null)
                {
                    this._controleDbContext.Transacoes.Remove(meta);
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

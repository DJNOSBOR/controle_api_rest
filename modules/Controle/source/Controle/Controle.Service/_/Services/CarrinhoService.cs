using Controle.Data.Context;
using Controle.Data.Interfaces;
using Controle.Data.Models;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Controle.Services
{
    public class CarrinhoService : ICarrinhoService, ISelfBindable
    {
        private ControleDbContext _controleDbContext;
        public CarrinhoService(ControleDbContext controleDbContext)
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

        public async Task<List<Carrinho>> GetCarrinhoAsync()
        {
            try
            {
                var data = await this._controleDbContext.Carrinhos.ToListAsync();
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

        public async Task<Carrinho> GetCarrinhoByIdAsync(int id)
        {
            try
            {
                var data = await this._controleDbContext.Carrinhos.FindAsync(id);
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

        public async Task<Carrinho> PostOrPutCarrinhoAsync(Carrinho data)
        {
            try
            {
                this._controleDbContext.Carrinhos.AddOrUpdate(data);
                this._controleDbContext.SaveChanges();

                return await Task.FromResult(data);

            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

        public async Task<bool> DeleteCarrinhoAsync(int Id)
        {
            try
            {
                var meta = this._controleDbContext.Carrinhos.Find(Id);
                if (meta != null)
                {
                    this._controleDbContext.Carrinhos.Remove(meta);
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

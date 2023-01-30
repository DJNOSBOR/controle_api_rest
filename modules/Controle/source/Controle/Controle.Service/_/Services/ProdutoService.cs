using Controle.Data.Context;
using Controle.Data.Interfaces;
using Controle.Data.Models;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Controle.Api.Services
{
    public class ProdutoService: IProdutoService, ISelfBindable
    {
        private ControleDbContext _controleDbContext;
        public ProdutoService(ControleDbContext controleDbContext)
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

        public async Task<List<Produto>> GetProdutosAsync()
        {
            try
            {
                var data = await this._controleDbContext.Produtos.ToListAsync();
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

        public async Task<Produto> GetProdutoByIdAsync(int id)
        {
            try
            {
                var data = await this._controleDbContext.Produtos.FindAsync(id);
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

        public async Task<Produto> PostOrPutProdutoAsync(Produto data)
        {
            try
            {
                this._controleDbContext.Produtos.AddOrUpdate(data);
                this._controleDbContext.SaveChanges();

                return await Task.FromResult(data); 

            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

        public async Task<bool> DeleteProdutoAsync(int Id)
        {
            try
            {
                var meta = this._controleDbContext.Produtos.Find(Id);
                if (meta != null)
                {
                    this._controleDbContext.Produtos.Remove(meta);
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

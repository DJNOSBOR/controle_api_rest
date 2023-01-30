using Controle.Data.Context;
using Controle.Data.Interfaces;
using Controle.Data.Models;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Controle.Services
{
    public class ProdutoCategoriaService: IProdutoCategoriaService, ISelfBindable
    {
        private ControleDbContext _controleDbContext;
        public ProdutoCategoriaService(ControleDbContext controleDbContext)
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

        public async Task<List<ProdutoCategoria>> GetProdutoCategoriaAsync()
        {
            try
            {
                var data = await this._controleDbContext.ProdutoCategorias.ToListAsync();
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

        public async Task<ProdutoCategoria> GetProdutoCategoriaByIdAsync(int id)
        {
            try
            {
                var data = await this._controleDbContext.ProdutoCategorias.FindAsync(id);
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

        public async Task<ProdutoCategoria> PostOrPutProdutoCategoriaAsync(ProdutoCategoria data)
        {
            try
            {
                this._controleDbContext.ProdutoCategorias.AddOrUpdate(data);
                this._controleDbContext.SaveChanges();

                return await Task.FromResult(data); 

            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

        public async Task<bool> DeleteProdutoCategoriaAsync(int Id)
        {
            try
            {
                var meta = this._controleDbContext.ProdutoCategorias.Find(Id);
                if (meta != null)
                {
                    this._controleDbContext.ProdutoCategorias.Remove(meta);
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

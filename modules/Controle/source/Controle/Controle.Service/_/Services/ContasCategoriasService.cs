using Controle.Data.Context;
using Controle.Data.Interfaces;
using Controle.Data.Models;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Controle.Services
{
    public class ContasCategoriasService : IContasCategoriasService, ISelfBindable
    {
        private ControleDbContext _controleDbContext;
        public ContasCategoriasService(ControleDbContext controleDbContext)
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

        public async Task<List<ContasCategorias>> GetContasCategoriasAsync()
        {
            try
            {
                var data = await this._controleDbContext.ContasCategorias.ToListAsync();
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

        public async Task<ContasCategorias> GetContasCategoriasByIdAsync(int id)
        {
            try
            {
                var data = await this._controleDbContext.ContasCategorias.FindAsync(id);
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

        public async Task<ContasCategorias> PostOrPutContasCategoriasAsync(ContasCategorias data)
        {
            try
            {
                this._controleDbContext.ContasCategorias.AddOrUpdate(data);
                this._controleDbContext.SaveChanges();

                return await Task.FromResult(data); 

            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

        public async Task<bool> DeleteContasCategoriasAsync(int Id)
        {
            try
            {
                var meta = this._controleDbContext.ContasCategorias.Find(Id);
                if (meta != null)
                {
                    this._controleDbContext.ContasCategorias.Remove(meta);
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

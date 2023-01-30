using Controle.Data.Context;
using Controle.Data.Interfaces;
using Controle.Data.Models;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Controle.Services
{
    public class ContasParcelasService : IContasParcelasService, ISelfBindable
    {
        private ControleDbContext _controleDbContext;
        public ContasParcelasService(ControleDbContext controleDbContext)
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

        public async Task<List<ContasParcelas>> GetParcelasIsPago(bool isPago, DateTime dataInicial, DateTime dataFinal)
        {
            try
            {

                var data = this._controleDbContext.ContasParcelas.Where((a) => a.IsPago == isPago && a.DataVencimento >= dataInicial && a.DataVencimento <= dataFinal).ToList();

                return await Task.FromResult(data);

            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

        public async Task<List<ContasParcelas>> GetContasParcelasAsync()
        {
            try
            {
                var data = await this._controleDbContext.ContasParcelas.ToListAsync();
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

        public async Task<ContasParcelas> GetContasParcelasByIdAsync(int id)
        {
            try
            {
                var data = await this._controleDbContext.ContasParcelas.FindAsync(id);
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

        public async Task<ContasParcelas> PostOrPutContasParcelasAsync(ContasParcelas data)
        {
            try
            {
                this._controleDbContext.ContasParcelas.AddOrUpdate(data);
                this._controleDbContext.SaveChanges();

                return await Task.FromResult(data);

            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

        public async Task<bool> DeleteContasParcelasAsync(int Id)
        {
            try
            {
                var meta = this._controleDbContext.ContasParcelas.Find(Id);
                if (meta != null)
                {
                    this._controleDbContext.ContasParcelas.Remove(meta);
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

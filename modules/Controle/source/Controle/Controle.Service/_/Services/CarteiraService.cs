using Controle.Data.Context;
using Controle.Data.Interfaces;
using Controle.Data.Models;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Controle.Services
{
    public class CarteiraService : ICarteiraService, ISelfBindable
    {
        private ControleDbContext _controleDbContext;
        public CarteiraService(ControleDbContext controleDbContext)
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

        public async Task<List<Carteira>> GetCarteiraAsync()
        {
            try
            {
                var data = await this._controleDbContext.Carteiras.ToListAsync();
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

        public async Task<Carteira> GetCarteiraByIdAsync(int id)
        {
            try
            {
                var data = await this._controleDbContext.Carteiras.FindAsync(id);
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

        public async Task<Carteira> PostOrPutCarteiraAsync(Carteira data)
        {
            try
            {
                transacoes(data);
                if (data.Id != null && data.Id > 0)
                {
                    var d = this._controleDbContext.Carteiras.Find(data.Id);
                    if(d != null)
                    {
                        data.Valor = data.Valor + d.Valor;
                    }
                }
                this._controleDbContext.Carteiras.AddOrUpdate(data);
                this._controleDbContext.SaveChanges();

                return await Task.FromResult(data);

            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

        public async Task<bool> DeleteCarteiraAsync(int Id)
        {
            try
            {
                var meta = this._controleDbContext.Carteiras.Find(Id);
                if (meta != null)
                {
                    this._controleDbContext.Carteiras.Remove(meta);
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

        private void transacoes(Carteira carteira)
        {
            try
            {
                var data = this._controleDbContext.Carteiras.Find(carteira.Id);
                if(data != null)
                {
                    this._controleDbContext.Transacoes.AddOrUpdate(new Transacoes
                    {
                        Id = carteira.Id,
                        Nome = $"Nova entrada - {carteira.Nome} - Com o Valor de R$ {carteira.Valor}. Somando o Valor de {carteira.Valor + data.Valor}",
                        TipoTransacao = Data.Models.Dto.TipoTransacaoEnum.Entrada,
                        Valor = carteira.Valor + data.Valor,
                        Data = DateTime.UtcNow              
                    });
                }
                else
                {
                    this._controleDbContext.Transacoes.AddOrUpdate(new Transacoes
                    {
                        Nome = $"Nova Carteira - {carteira.Nome} - Com o Valor de R$ {carteira.Valor}",
                        TipoTransacao = Data.Models.Dto.TipoTransacaoEnum.Entrada,
                        Valor = carteira.Valor,
                        Data = DateTime.UtcNow
                    });
                }
            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

    }
}

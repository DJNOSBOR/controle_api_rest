using Controle.Data.Context;
using Controle.Data.Interfaces;
using Controle.Data.Models;
using Controle.Data.Models.Dto;
using Core;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace Controle.Services
{
    public class ContasService : IContasService, ISelfBindable
    {
        private ControleDbContext _controleDbContext;
        public ContasService(ControleDbContext controleDbContext)
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

        public async Task<List<Contas>> GetMonthIsPago(bool pago, int month, int year)
        {
            try
            {
                var data = await this._controleDbContext.Contas.Where((a) => a.IsPago == pago).ToListAsync();
                List<Contas> con = new List<Contas>();
                if (data != null)
                {
                    foreach (var item in data)
                    {
                        var parcelas = ObterParcelasContasById(item.Id);
                        item.Parcelas = new List<ContasParcelas>();

                        item.Parcelas = parcelas;
                        foreach (var item1 in parcelas)
                        {
                            if (item1.DataVencimento.Value.Month == month && item1.DataVencimento.Value.Year == year)
                                if (item1.IsPago == pago)
                                    con.Add(item);
                        }
                    }

                }

                return await Task.FromResult(con);
            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

        public async Task<List<Contas>> GetContasAsync()
        {
            try
            {
                var data = await this._controleDbContext.Contas.ToListAsync();
                foreach (var item in data)
                {
                    var parcelas = ObterParcelasContasById(item.Id);
                    item.Parcelas = new List<ContasParcelas>();

                    item.Parcelas = parcelas;
                }
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {

                throw ex.Failin();

            }
        }
        public async Task<Contas> GetContasByIdAsync(int id)
        {
            try
            {
                var data = this._controleDbContext.Contas.Where((a) => a.Id == id).Single();
                var parcelas = ObterParcelasContasById(id);
                if (data.Parcelas == null)
                    data.Parcelas = new List<ContasParcelas>();

                data.Parcelas = parcelas;
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

        public async Task<Contas> PostNewContaAsync(LancamentoContasInsert lancamentoContasInsert)
        {
            try
            {
                if (lancamentoContasInsert.Conta.ContaFixa.Value)
                {
                    if (lancamentoContasInsert.Conta.Parcelas == null)
                    {
                        lancamentoContasInsert.Conta.Parcelas = new List<ContasParcelas>();
                    }

                    lancamentoContasInsert.Conta.Parcelas.Add(
                        new ContasParcelas
                        {
                            DataVencimento = lancamentoContasInsert.DataVencimento,
                            IsPago = lancamentoContasInsert.Conta.IsPago,
                            Valor = lancamentoContasInsert.Valor
                        }
                        );
                }
                else
                {
                    if (lancamentoContasInsert.Conta.Parcelas == null)
                    {
                        lancamentoContasInsert.Conta.Parcelas = new List<ContasParcelas>();
                    }
                    var datavenc = lancamentoContasInsert.DataVencimento;
                    do
                    {
                        lancamentoContasInsert.Conta.Parcelas.Add(
                        new ContasParcelas
                        {
                            DataVencimento = datavenc,
                            IsPago = false,
                            Valor = lancamentoContasInsert.Valor
                        }
                        );
                        datavenc = datavenc.AddMonths(1);
                    } while (lancamentoContasInsert.Conta.Parcelas.Count != lancamentoContasInsert.QuantidadeParcelas);
                }
                await this._controleDbContext.Contas.AddOrUpdateAsync(lancamentoContasInsert.Conta);
                await this._controleDbContext.SaveChangesAsync();

                return await Task.FromResult(lancamentoContasInsert.Conta);
            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

        public async Task<Contas> PutContasAsync(Contas data)
        {
            try
            {
                var parcelas = this._controleDbContext.ContasParcelas.AsNoTracking().Where((a) => a.IdConta == data.Id).ToList();
                if(parcelas != null)
                {
                    foreach (var item in parcelas)
                    {
                        foreach (var item1 in data.Parcelas)
                        {
                            if (item.Id == item1.Id)
                            {
                                if (item.IsPago != item1.IsPago)
                                {
                                    Transacoes(data.Id, item1.Id, (float)item1.Valor.Value, data.NomeConta, item1.IsPago.Value);
                                    if (item1.IsPago.Value)
                                    {
                                        if (data.ContaFixa == true && item1.DataVencimento > item1.DataVencimento)
                                        {
                                            var n = item1;
                                            n.Id = 0;
                                            n.DataVencimento = item1.DataVencimento.Value.AddMonths(1);
                                            data.Parcelas.Add(n);
                                        }
                                    }

                                }
                            }
                        }
                    }
                }

                this._controleDbContext.Contas.AddOrUpdate(data);
                this._controleDbContext.SaveChanges();

                return await Task.FromResult(data);

            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

        public async Task<bool> DeleteContasAsync(int Id)
        {
            try
            {
                var parcela = this._controleDbContext.ContasParcelas.Where((a) => a.IdConta == Id).ToList();

                foreach (var item in parcela)
                {
                    this._controleDbContext.ContasParcelas.Remove(item);
                }

                var meta = this._controleDbContext.Contas.Find(Id);
                if (meta != null)
                {
                    this._controleDbContext.Contas.Remove(meta);
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

        private List<ContasParcelas> ObterParcelasContasById(int idConta)
        {
            try
            {
                var parcelas = this._controleDbContext.ContasParcelas.Where((a) => a.IdConta.Value == idConta).ToList();
                return parcelas;
            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

        private void Transacoes(int idConta, int idParcela, float valor, string nome, bool isPago)
        {
            try
            {
                if (isPago)
                {
                    var d = this._controleDbContext.Transacoes.Where((a) => a.IdConta.Value == idConta && a.IdParcela.Value == idParcela).ToList();
                    if (d != null && d.Count > 0)
                    {
                        foreach (var item in d)
                        {
                            item.Cancelado = true;

                            this._controleDbContext.Transacoes.AddOrUpdate(item);
                        }
                    }
                    else
                    {
                        this._controleDbContext.Transacoes.AddOrUpdate(new Transacoes
                        {
                            TipoTransacao = TipoTransacaoEnum.Saida,
                            Nome = $"Transação de Pagamento - {DateTime.Now.ToString("dd/MM/yyyy")} - {nome}",
                            Valor = valor,
                            Data = DateTime.UtcNow,
                            IdConta = idConta,
                            IdParcela = idParcela
                        });
                    }
                }
                else
                {
                    var d = this._controleDbContext.Transacoes.Where((a) => a.IdConta.Value == idConta && a.IdParcela.Value == idParcela).ToList();
                    if (d != null)
                    {
                        foreach (var item in d)
                        {
                            item.Cancelado = true;

                            this._controleDbContext.Transacoes.AddOrUpdate(item);
                        }
                    }
                }
                this._controleDbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex.Failin();
            }
        }

    }
}

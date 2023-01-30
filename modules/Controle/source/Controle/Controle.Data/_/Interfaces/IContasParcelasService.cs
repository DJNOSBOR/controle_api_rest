using Controle.Data.Models;

namespace Controle.Data.Interfaces
{
    public interface IContasParcelasService: IDisposable
    {
        Task<List<ContasParcelas>> GetParcelasIsPago(bool isPago, DateTime dataInicial, DateTime dataFinal);

        Task<List<ContasParcelas>> GetContasParcelasAsync();

        Task<ContasParcelas> GetContasParcelasByIdAsync(int id);

        Task<ContasParcelas> PostOrPutContasParcelasAsync(ContasParcelas data);

        Task<bool> DeleteContasParcelasAsync(int Id);
    }
}


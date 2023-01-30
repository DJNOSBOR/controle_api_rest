using Controle.Data.Models;
using Controle.Data.Models.Dto;

namespace Controle.Data.Interfaces
{
    public interface IContasService: IDisposable
    {
        Task<List<Contas>> GetMonthIsPago(bool pago, int month, int year);

        Task<List<Contas>> GetContasAsync();

        Task<Contas> GetContasByIdAsync(int id);

        Task<Contas> PostNewContaAsync(LancamentoContasInsert lancamentoContasInsert);

        Task<Contas> PutContasAsync(Contas data);

        Task<bool> DeleteContasAsync(int Id);
    }
}

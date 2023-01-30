using Controle.Data.Models;

namespace Controle.Data.Interfaces
{
    public interface ICarteiraService : IDisposable
    {
        Task<List<Carteira>> GetCarteiraAsync();

        Task<Carteira> GetCarteiraByIdAsync(int id);

        Task<Carteira> PostOrPutCarteiraAsync(Carteira data);

        Task<bool> DeleteCarteiraAsync(int Id);
    }
}

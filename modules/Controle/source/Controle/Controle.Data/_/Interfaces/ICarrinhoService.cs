using Controle.Data.Models;

namespace Controle.Data.Interfaces
{
    public interface ICarrinhoService: IDisposable
    {
        Task<List<Carrinho>> GetCarrinhoAsync();

        Task<Carrinho> GetCarrinhoByIdAsync(int id);

        Task<Carrinho> PostOrPutCarrinhoAsync(Carrinho data);

        Task<bool> DeleteCarrinhoAsync(int Id);
    }
}

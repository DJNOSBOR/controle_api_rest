using Controle.Data.Models;

namespace Controle.Data.Interfaces
{
    public interface IProdutoService: IDisposable
    {
        Task<List<Produto>> GetProdutosAsync();

        Task<Produto> GetProdutoByIdAsync(int id);

        Task<Produto> PostOrPutProdutoAsync(Produto data);

        Task<bool> DeleteProdutoAsync(int Id);
    }
}

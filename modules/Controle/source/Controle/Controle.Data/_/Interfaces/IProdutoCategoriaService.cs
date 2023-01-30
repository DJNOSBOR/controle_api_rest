using Controle.Data.Models;

namespace Controle.Data.Interfaces
{
    public interface IProdutoCategoriaService: IDisposable
    {
        Task<List<ProdutoCategoria>> GetProdutoCategoriaAsync();

        Task<ProdutoCategoria> GetProdutoCategoriaByIdAsync(int id);

        Task<ProdutoCategoria> PostOrPutProdutoCategoriaAsync(ProdutoCategoria data);

        Task<bool> DeleteProdutoCategoriaAsync(int Id);
    }
}

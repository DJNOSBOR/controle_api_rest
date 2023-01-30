using Controle.Data.Models;

namespace Controle.Data.Interfaces
{
    public interface IContasCategoriasService: IDisposable
    {
        Task<List<ContasCategorias>> GetContasCategoriasAsync();

        Task<ContasCategorias> GetContasCategoriasByIdAsync(int id);

        Task<ContasCategorias> PostOrPutContasCategoriasAsync(ContasCategorias data);

        Task<bool> DeleteContasCategoriasAsync(int Id);
    }
}


namespace Controle.Data.Models
{
    public class Carrinho
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public List<Produto>? Produtos { get; set; } 
    }
}

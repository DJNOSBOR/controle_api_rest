namespace Controle.Data.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public decimal? Valor { get; set; }
        public DateTime? DataCriacao { get; set; }
        public ProdutoCategoria? CategoriaProduto { get; set; }
    }
}

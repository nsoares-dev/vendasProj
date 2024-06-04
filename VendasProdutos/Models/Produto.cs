namespace VendasProdutos.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string? NomeProduto { get; set; }
        public string? Descricao { get; set; }
        public string? UrlImagem { get; set; }
        public double Preco { get; set; }
        public int QtdEstoque { get; set; }
    }
}

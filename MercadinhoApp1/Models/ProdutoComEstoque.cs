namespace MercadinhoApp1.Models;

public class ProdutoComEstoque
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int QuantidadeEmEstoque { get; set; }
}

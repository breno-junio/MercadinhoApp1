namespace MercadinhoApp1.Models;

public class Venda
{
    public Venda() { }

    public Venda(int id, DateTime dataVenda, List<ItemVenda> itens)
    {
        Id = id;
        DataVenda = dataVenda;
        Itens = itens;
    }

    public int Id { get; set; }
    public DateTime DataVenda { get; set; } = DateTime.Now;
    public List<ItemVenda> Itens { get; set; } = new();
    public decimal ValorTotal => Itens.Sum(i => i.Subtotal);
}

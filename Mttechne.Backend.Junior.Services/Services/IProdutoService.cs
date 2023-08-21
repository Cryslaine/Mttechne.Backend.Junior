using Mttechne.Backend.Junior.Services.Model;

namespace Mttechne.Backend.Junior.Services.Services;

public interface IProdutoService
{
    List<Produto> GetListaProdutos();
    List<Produto> GetListaProdutosPorNome(string nome);
    List<Produto> GetListaProdutosProValorOrdenado(string ordenada);
    List<Produto> GetListaProdutosProValorComparacao(int valor1, int valor2);
    List<Produto> GetListaProdutosProValorMax();
    List<Produto> GetListaProdutosProValorMin();

}
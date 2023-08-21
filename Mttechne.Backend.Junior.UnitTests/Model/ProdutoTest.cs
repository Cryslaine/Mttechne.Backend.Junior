using Mttechne.Backend.Junior.Services.Model;
using Mttechne.Backend.Junior.Services.Services;
using System.Collections.Generic;
using System.Drawing;
using Xunit.Sdk;

namespace Mttechne.Backend.Junior.UnitTests.Model;

public class ProdutoTest
{
    [Fact(DisplayName = "Should Create A Product With Success")]
    public void ShouldCreateAProductWithSuccess()
    {
        var teclado = new Produto() { Nome = "Teclado", Valor = 100 };

        Assert.Equal(100, teclado.Valor);
        Assert.Equal("Teclado", teclado.Nome);
    }


    [Fact(DisplayName = "Should Create A Product With Success By Name")]
    public void ShouldCreateAProductWithSuccessByName()
    {
        var teste = new ProdutoService() { };
        teste.GetListaProdutosPorNome("");
        teste.GetListaProdutosPorNome("Memoria");
        teste.GetListaProdutosPorNome("Memória");
        teste.GetListaProdutosPorNome("memória");
        teste.GetListaProdutosPorNome("mem");

        teste.Equals("");
        teste.Equals("Memoria");
        teste.Equals("Memória");
        teste.Equals("memória");
    }

    [Fact(DisplayName = "Should Create A Product With Success By Comparison")]
    public void ShouldCreateAProductWithSuccessByComparison()
    {
        var teste = new ProdutoService() { };
        teste.GetListaProdutosProValorComparacao(1000, 2000);

        teste.Equals(teste);
    }

    [Fact(DisplayName = "Should Create A Product With Success Ordered ")]
    public void ShouldCreateAProductWithSuccessOrdered()
    {
        var teste = new ProdutoService() { };
        teste.GetListaProdutosProValorOrdenado("1");
        teste.GetListaProdutosProValorOrdenado("");

        teste.Equals("1");
        teste.Equals("2");
    }
    [Fact(DisplayName = "Should Create A Lis Product With Success Greatest Value ")]
    public void CreateALisProductWithSuccessGreatestValue()
    {
        var teste = new ProdutoService() { };
        teste.GetListaProdutosProValorMax();

        teste.Equals("");
    }
    [Fact(DisplayName = "Should Create A Lis Product With Success Smaller Value ")]
    public void CreateALisProductWithSuccessSmalllerValue()
    {
        var teste = new ProdutoService();
        teste.GetListaProdutosProValorMin();

        teste.Equals("");
    }

}
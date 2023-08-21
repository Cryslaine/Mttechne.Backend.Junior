using Mttechne.Backend.Junior.Services.Model;

namespace Mttechne.Backend.Junior.Services.Services;

public class ProdutoService : IProdutoService
{
    public List<Produto> GetListaProdutos()
    {
        Produto produto1 = new Produto() { Nome = "Placa de Vídeo", Valor = 1000 };
        Produto produto2 = new Produto() { Nome = "Placa de Vídeo", Valor = 1500 };
        Produto produto3 = new Produto() { Nome = "Placa de Vídeo", Valor = 1350 };
        Produto produto4 = new Produto() { Nome = "Processador", Valor = 2000 };
        Produto produto5 = new Produto() { Nome = "Processador", Valor = 2100 };
        Produto produto6 = new Produto() { Nome = "Memória", Valor = 300 };
        Produto produto7 = new Produto() { Nome = "Memória", Valor = 350 };
        Produto produto8 = new Produto() { Nome = "Placa mãe", Valor = 1100 };
        
        List<Produto> produtosCadastrados = new List<Produto>()
        {
            produto1, produto2, produto3, produto4, produto5, produto6, produto7, produto8
        };
        
        return produtosCadastrados;
    }

    public List<Produto> GetListaProdutosPorNome(string nome)
    {
        var listaProdutos = GetListaProdutos();

        Produto validacaoCampo = new Produto();

        //Verifica se o campo esta preenchido
        if (string.IsNullOrEmpty(nome))
        {
            Console.Write("Digite um nome!");
        }
        else
        {
            string validacao = ValidacaoCampNome(nome).ToLower();

            listaProdutos = listaProdutos.Where(x => ValidacaoCampNome(x.Nome).ToLower().Contains(ValidacaoCampNome(nome).ToLower())).ToList();

            Console.Write("Pesquisa realizada com sucesso!");

        }

        return listaProdutos;
        //return listaProdutos.Where(x => x.Nome == nome).ToList();
    }

    public static string ValidacaoCampNome(string texto)
    {
        //Validação da pesquisa por nome
        string comAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
        string semAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

        for (int i = 0; i < comAcentos.Length; i++)
        {
            texto = texto.Replace(comAcentos[i].ToString(), semAcentos[i].ToString());
        }
        return texto;
    }
    public List<Produto> GetListaProdutosProValorOrdenado(string ordenada)
    {
        var listaValor = GetListaProdutos();

        if (ordenada.Trim().Equals("1"))
        {
            ////Alteração ordem crescente
            listaValor = listaValor.OrderBy(x => x.Valor).ToList();
        }
        else
        {
            ////Alteração ordem descrecente
            listaValor = listaValor.OrderByDescending(x => x.Valor).ToList();
        }


        return listaValor;
    }
    public List<Produto> GetListaProdutosProValorComparacao(int valor1, int valor2)
    {
        // Busca entre dois valores
        var listaProdutoMaxMen = GetListaProdutos();

        var teste = listaProdutoMaxMen.Where(x => (x.Valor >= valor1 && x.Valor <= valor2) || (x.Valor >= valor2 && x.Valor <= valor1)).ToList();

        return teste;
    }
    public List<Produto> GetListaProdutosProValorMax()
    {
        var listaProdutos = GetListaProdutos();

        //Retorna uma lista com os produtos maior valor de cada um.
        var maior = from s in listaProdutos
                    group s by new { s.Nome } into g
                    select new Produto
                    {
                        Nome = g.Key.Nome,
                        Valor = g.Max(p => p.Valor)
                    };
        return maior.ToList();
    }

    public List<Produto> GetListaProdutosProValorMin()
    {
        var listaProdutos = GetListaProdutos();

        //Retorna uma lista com os produtos maior valor de cada um.
        var menor = from s in listaProdutos
                    group s by new { s.Nome } into g
                    select new Produto
                    {
                        Nome = g.Key.Nome,
                        Valor = g.Min(p => p.Valor)
                    };
        return menor.ToList();
    }
}
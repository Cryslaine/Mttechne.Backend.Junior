using Microsoft.AspNetCore.Mvc;
using Mttechne.Backend.Junior.Services.Services;

namespace Mttechne.Backend.Junior.Interface.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private static IProdutoService _service;

    public ProdutoController(IProdutoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetListaProdutos() => Ok(_service.GetListaProdutos());

    [HttpGet("{nome}")]
    public async Task<IActionResult> GetListaProdutosProNome([FromRoute] string nome) => Ok(_service.GetListaProdutosPorNome(nome));

    [HttpGet("digite 1 para crescente e 2 para decrecente/{ordenada}")]
    public async Task<IActionResult> GetListaProdutosProValorOrdenado([FromRoute] string ordenada = " ") => Ok(_service.GetListaProdutosProValorOrdenado(ordenada));

    [HttpGet("range")]
    public async Task<IActionResult> GetListaProdutosProValorComparacao(int valor1, int valor2) => Ok(_service.GetListaProdutosProValorComparacao(valor1, valor2));

    [HttpGet("max")]
    public async Task<IActionResult> GetListaProdutosProValorMax() => Ok(_service.GetListaProdutosProValorMax());
    [HttpGet("min")]
    public async Task<IActionResult> GetListaProdutosProValorMin() => Ok(_service.GetListaProdutosProValorMin());
}
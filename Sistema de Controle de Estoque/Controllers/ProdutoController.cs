using Microsoft.AspNetCore.Mvc;
using Sistema_de_Controle_de_Estoque.Models;
using Sistema_de_Controle_de_Estoque.Models.Dtos;
using Sistema_de_Controle_de_Estoque.Repositories;

namespace Sistema_de_Controle_de_Estoque.Controllers
{
    [ApiController]
    [Route("Produto")]
    public class ProdutoController : Controller
    {
        private readonly ProdutoRepository _produtoRepository;

        public ProdutoController(ProdutoRepository produto)
        {
            _produtoRepository = produto;
        }

        [HttpPost]
        [Route("Cadastrar")]
        public async Task<ActionResult<Produto>> cadastroProduto([FromBody] CadastroProduto produto)
        {
            await _produtoRepository.cadastrarProduto(produto);

            return Ok("Produto Cadastrado");
        }

        [HttpGet]
        [Route("ListarTodos")]
        public async Task<ActionResult<List<Produto>>> listarTodos ()
        {
            List<Produto> produtos = await _produtoRepository.listarTodos();

            return Ok(produtos);
        }

        [HttpGet]
        [Route("ListarEstoqueBaixo")]
        public async Task<List<Produto>> listarPorEstoque ()
        {
            List<Produto> produtos = await _produtoRepository.listarEstoqueBaixo();
            return produtos;
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<ActionResult<Produto>> atualizarProduto (int id, [FromBody] DtoAtualizarProduto produto)
        {
            Produto produto1 = await _produtoRepository.atualizarProduto(id, produto);

            return Ok(produto1);
        }
    }
}

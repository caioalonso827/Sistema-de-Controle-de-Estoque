using Microsoft.AspNetCore.Mvc;
using Sistema_de_Controle_de_Estoque.Models;
using Sistema_de_Controle_de_Estoque.Models.Dtos;
using Sistema_de_Controle_de_Estoque.Repositories;

namespace Sistema_de_Controle_de_Estoque.Controllers
{
    [ApiController]
    [Route("Movimentacao")]
    public class MovimentacaoController : Controller
    {
        private readonly MovimentacaoRepository _movimentacao;

        public MovimentacaoController(MovimentacaoRepository movimentacao)
        {
            _movimentacao = movimentacao;
        }

        [HttpPost]
        [Route("Cadastrar")]
        public async Task<ActionResult<Movimentacao>> cadastroMovimentacao([FromBody] DtoCadastrarMovimentacao movimentacao)
        {
            await _movimentacao.cadastrarMovimentacao(movimentacao);

            return Ok("Movimentacao Feita");
        }

        [HttpGet]
        [Route("ListarTodas")]
        public async Task<ActionResult<List<Movimentacao>>> listarTodas()
        {
            List<Movimentacao> movimentacaos = await _movimentacao.listarTodas();

            return Ok(movimentacaos);
        }

        [HttpGet]
        [Route("ListarPorDia")]
        public async Task<ActionResult<List<Movimentacao>>> listarPorDia()
        {
            List<Movimentacao> movimentacaos = await _movimentacao.listarPorDia();

            return Ok(movimentacaos);
        }
    }
}

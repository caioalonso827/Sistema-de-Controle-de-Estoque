using Microsoft.AspNetCore.Mvc;
using Sistema_de_Controle_de_Estoque.Models;
using Sistema_de_Controle_de_Estoque.Repositories;

namespace Sistema_de_Controle_de_Estoque.Controllers
{
    [ApiController]
    [Route("Categoria")]
    public class CategoriaController : Controller
    {
        private readonly CategoriaRepository _categoriaRepository;

        public CategoriaController(CategoriaRepository categoria)
        { 
            _categoriaRepository = categoria;
        }

        [HttpPost]
        [Route("Cadastrar")]
        public async Task<ActionResult<Categoria>> cadastroProduto([FromBody] Categoria categoria)
        {
            await _categoriaRepository.cadastrarCategoria(categoria);

            return Ok("Categoria cadastrada");
        }

        [HttpGet]
        [Route("ListarTodas")]
        public async Task<ActionResult<List<Categoria>>> listarTodos()
        {
            List<Categoria> categorias = await _categoriaRepository.listarTodas();

            return Ok(categorias);
        }

        [HttpDelete]
        [Route("Remover")]
        public async Task<ActionResult<String>> removerCategoria (int id)
        {
            await _categoriaRepository.removeCategoria(id);
            return Ok("Categoria Removida");
        }
    }
}

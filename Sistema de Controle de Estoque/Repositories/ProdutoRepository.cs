using Microsoft.EntityFrameworkCore;
using Sistema_de_Controle_de_Estoque.Data;
using Sistema_de_Controle_de_Estoque.Models;
using Sistema_de_Controle_de_Estoque.Models.Dtos;

namespace Sistema_de_Controle_de_Estoque.Repositories
{
    public class ProdutoRepository
    {
        private readonly AppDbContext _contex;

        public ProdutoRepository(AppDbContext appDbContext)
        {
            _contex = appDbContext;
        }


        public async Task<Produto> cadastrarProduto (Produto produto)
        {
            Categoria categoria = await _contex.categoria.FirstOrDefaultAsync(x => x.Id == produto.IdCategoria);
            if (categoria == null) { throw new Exception("Não existe essa categoria"); }

            produto.Categoria = categoria;

            await _contex.produtos.AddAsync(produto);

            await _contex.SaveChangesAsync();
            return produto;
        }

        public async Task<List<Produto>> listarTodos ()
        {
            List<Produto> produtos = _contex.produtos.ToList ();

            return produtos;
        }

        public async Task<List<Produto>> listarEstoqueBaixo ()
        {
            List<Produto> produtos = await _contex.produtos.Where(x => x.quantidade < 5).ToListAsync();
            return produtos;
        }

        public async Task<Produto> atualizarProduto (int id, DtoAtualizarProduto produto)
        {
            Produto produtoBuscado = await _contex.produtos.FirstOrDefaultAsync(x=> x.Id == id);
            if (produtoBuscado == null) { new Exception("Não existe esse Produto"); }

            if (produto.categoria != null) { produtoBuscado.Categoria = produto.categoria; }
            if (produto.Nome != null) { produtoBuscado.Nome = produto.Nome; }

            await _contex.SaveChangesAsync();
            return produtoBuscado;
        }

        public async Task<string> removerProduto (int id)
        {
            Produto produto = await _contex.produtos.FirstOrDefaultAsync (x=> x.Id == id);
            _contex.produtos.Remove(produto);

            await _contex.SaveChangesAsync ();

            return null;
        }
    }
}

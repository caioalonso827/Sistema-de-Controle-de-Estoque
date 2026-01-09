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


        public async Task<Produto> cadastrarProduto (CadastroProduto produto)
        {
            Categoria categoria = await _contex.categoria.FirstOrDefaultAsync(x => x.Nome == produto.NomeCategoria);
            if (categoria == null) { throw new Exception("Não existe essa categoria"); }

            Produto produto1 = new Produto();
            produto1.Nome = produto.Nome;
            produto1.Categoria = categoria;
            produto1.quantidade = produto.quantidade;

            await _contex.produtos.AddAsync(produto1);

            await _contex.SaveChangesAsync();
            return produto1;
        }

        public async Task<List<Produto>> listarTodos ()
        {
            List<Produto> produtos = _contex.produtos.Include(i => i.Categoria).ToList ();

            return produtos;
        }

        public async Task<List<Produto>> listarEstoqueBaixo ()
        {
            List<Produto> produtos = await _contex.produtos.Include(x=>x.Categoria).Where(x => x.quantidade < 5).ToListAsync();
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

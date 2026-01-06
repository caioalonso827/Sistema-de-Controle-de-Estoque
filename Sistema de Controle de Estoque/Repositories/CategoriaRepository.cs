using Microsoft.EntityFrameworkCore;
using Sistema_de_Controle_de_Estoque.Data;
using Sistema_de_Controle_de_Estoque.Models;

namespace Sistema_de_Controle_de_Estoque.Repositories
{
    public class CategoriaRepository
    {
        private readonly AppDbContext _contex;

        public CategoriaRepository(AppDbContext appDbContext)
        {
            _contex = appDbContext;
        }


        public async Task<Categoria> cadastrarCategoria(Categoria categoria)
        {
            await _contex.categoria.AddAsync(categoria);

            await _contex.SaveChangesAsync();
            return categoria;
        }

        public async Task<List<Categoria>> listarTodas()
        {
            List<Categoria> categorias = _contex.categoria.ToList();

            return categorias;
        }

        public async Task<string> removeCategoria (int id)
        {
            Categoria categoria = await _contex.categoria.FirstOrDefaultAsync (c => c.Id == id);

            _contex.categoria.Remove(categoria);

            await _contex.SaveChangesAsync();

            return ("Removido Com Sucesso");
        }
    }
}

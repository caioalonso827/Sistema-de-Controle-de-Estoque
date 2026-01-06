using Microsoft.EntityFrameworkCore;
using Sistema_de_Controle_de_Estoque.Models;

namespace Sistema_de_Controle_de_Estoque.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<Produto> produtos { get; set; }
        public DbSet<Movimentacao> movimentacao { get; set; }
        public DbSet<Categoria> categoria { get; set; }
        
    }
}

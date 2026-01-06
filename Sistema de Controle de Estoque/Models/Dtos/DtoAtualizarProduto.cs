using Sistema_de_Controle_de_Estoque.Models.Enums;

namespace Sistema_de_Controle_de_Estoque.Models.Dtos
{
    public class DtoAtualizarProduto
    {
        public Categoria categoria { get; set; }
        public string Nome { get; set; }
    }
}

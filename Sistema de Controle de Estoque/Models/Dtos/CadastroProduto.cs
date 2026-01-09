using System.Text.Json.Serialization;

namespace Sistema_de_Controle_de_Estoque.Models.Dtos
{
    public class CadastroProduto
    {
        public string Nome { get; set; }

        public string NomeCategoria { get; set; }

        public int quantidade { get; set; }
    }
}

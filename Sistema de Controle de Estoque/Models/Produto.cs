using Sistema_de_Controle_de_Estoque.Models.Enums;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Sistema_de_Controle_de_Estoque.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [JsonIgnore]
        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
        public int quantidade { get; set; }
        [JsonIgnore]
        public List<Movimentacao> movimentacaosParticipadas { get; set; } = new List<Movimentacao>();
     }
}

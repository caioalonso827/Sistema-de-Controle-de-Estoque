using Sistema_de_Controle_de_Estoque.Models.Enums;
using System.Text.Json.Serialization;

namespace Sistema_de_Controle_de_Estoque.Models
{
    public class Movimentacao
    {
        public int Id { get; set; }
        public MovimentacaoEnum Tipo { get; set; }

        public int quantidade { get; set; }

        [JsonIgnore]
        public int IdProduto { get; set; }

        public Produto produto { get; set; }

        public DateOnly data {  get; set; }
    }
}

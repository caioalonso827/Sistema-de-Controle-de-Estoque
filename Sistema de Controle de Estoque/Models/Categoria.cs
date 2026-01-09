using System.Text.Json.Serialization;

namespace Sistema_de_Controle_de_Estoque.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [JsonIgnore]
        public List<Produto>? produtos { get; set; }
    }
}

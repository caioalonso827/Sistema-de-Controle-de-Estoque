using Sistema_de_Controle_de_Estoque.Models.Enums;
using System.Text.Json.Serialization;

namespace Sistema_de_Controle_de_Estoque.Models.Dtos
{
    public class DtoCadastrarMovimentacao
    {
        public MovimentacaoEnum Tipo { get; set; }

        public int quantidade { get; set; }

        public string NomeProduto { get; set; }

        public DateOnly data { get; set; }
    }
}

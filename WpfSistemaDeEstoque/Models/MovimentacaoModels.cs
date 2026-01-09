using Sistema_de_Controle_de_Estoque.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using WpfSistemaDeEstoque.MVVM.View;

namespace WpfSistemaDeEstoque.Models
{
    class MovimentacaoModels
    {
        public int Id { get; set; }
        public MovimentacaoEnum Tipo { get; set; }

        public int quantidade { get; set; }

        [JsonIgnore]
        public int IdProduto { get; set; }

        public ProdutosModel produto { get; set; }

        public DateOnly data { get; set; }
    }
}

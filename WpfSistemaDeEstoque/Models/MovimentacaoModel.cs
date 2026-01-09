using Sistema_de_Controle_de_Estoque.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfSistemaDeEstoque.Models
{
    class MovimentacaoModel
    {
        public MovimentacaoEnum Tipo { get; set; }

        public int quantidade { get; set; }

        public string NomeProduto { get; set; }

        public DateOnly data { get; set; }
    }
}

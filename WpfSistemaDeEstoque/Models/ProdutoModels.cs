using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using WpfSistemaDeEstoque.MVVM.View;

namespace WpfSistemaDeEstoque.Models
{
    class ProdutoModels
    {
        public string Nome { get; set; }

        public string NomeCategoria { get; set; }

        public int quantidade { get; set; }


    }
}

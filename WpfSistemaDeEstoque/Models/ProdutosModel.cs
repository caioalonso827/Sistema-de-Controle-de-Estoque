using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WpfSistemaDeEstoque.Models
{
    class ProdutosModel
    {
        public int Id { get; set; } 
        public string Nome { get; set; }
        public Categoria Categoria { get; set; }
        public int quantidade { get; set; }
    }
}

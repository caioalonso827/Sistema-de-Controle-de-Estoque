using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfSistemaDeEstoque.Data;
using WpfSistemaDeEstoque.Models;

namespace WpfSistemaDeEstoque.MVVM.View
{
    /// <summary>
    /// Interação lógica para Inicio.xam
    /// </summary>
    public partial class Inicio : UserControl
    {
        public Inicio()
        {
            InitializeComponent();
            
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var api = new ApiSevice();
            var categorias = await api.listarCategorias();
            InputCategoria.ItemsSource = categorias;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var api = new ApiSevice();
            var categorias = await api.listarCategorias();

            var produto = new ProdutoModels()
            {
                Nome = InputNome.Text,
                quantidade = int.Parse(InputQuantidade.Text),
                NomeCategoria = (string)InputCategoria.SelectedValue
            };


            var reponse = api.cadastroProduto(produto);

            if (reponse != null)
            {
                MessageBox.Show("Produto Cadastrado");
            }

            else
            {
                MessageBox.Show("Erro ao cadastrar o Porduto. Verifique os Campos");
            }
        }
    }
}

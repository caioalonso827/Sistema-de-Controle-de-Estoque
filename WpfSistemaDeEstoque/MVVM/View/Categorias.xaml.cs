using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
using WpfSistemaDeEstoque.MVVM.ViewModel;

namespace WpfSistemaDeEstoque.MVVM.View
{
    /// <summary>
    /// Interação lógica para Categorias.xam
    /// </summary>
    public partial class Categorias : UserControl
    {
        public Categorias()
        {
            InitializeComponent();
        }

        public async void User_Loaded (object sender, RoutedEventArgs e)
        {
            var vm = DataContext as CategoriaViewModel;
            await vm.listarCategorias();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var api = new ApiSevice();

            var categoria = new Categoria
            {
                Nome = InputNome.Text
            };

            var response = await api.cadastrarCategoria(categoria);

            if (response == null)
            {
                MessageBox.Show("Categoria Registrada"); 
            }

            else { MessageBox.Show("Erro ao cadastrar"); }
        }
    }
}

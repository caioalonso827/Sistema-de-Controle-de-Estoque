using Sistema_de_Controle_de_Estoque.Models.Enums;
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
using System.Windows.Shapes;
using WpfSistemaDeEstoque.Data;
using WpfSistemaDeEstoque.Models;
using WpfSistemaDeEstoque.MVVM.ViewModel;

namespace WpfSistemaDeEstoque.MVVM.View
{
    /// <summary>
    /// Lógica interna para CadastroMovimentacao.xaml
    /// </summary>
    public partial class CadastroMovimentacao : Window
    {
        public CadastroMovimentacao()
        {
            InitializeComponent();
        }

        private async void Win_Loaded(object sender, RoutedEventArgs e)
        {
            var api = new ApiSevice();
            var categorias = await api.listarTodos();
            InputProduto.ItemsSource = categorias;

            InputTipo.ItemsSource = Enum.GetValues(typeof(MovimentacaoEnum));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var api = new ApiSevice();

            var movimentacao = new MovimentacaoModel
            {
                data = DateOnly.FromDateTime(InputData.SelectedDate.Value),
                quantidade = int.Parse(InputQuatidade.Text),
                NomeProduto = (string)InputProduto.SelectedValue,
                Tipo = (MovimentacaoEnum)InputTipo.SelectedValue
            };

            var response = await api.cadatroMovimentacao(movimentacao);

            if (response == null)
            {
                MessageBox.Show("Movimentação Cadastrada");
                Close();
            }

            else
            {
                MessageBox.Show("Erro ao cadastrar");
            }
        }
    }
}

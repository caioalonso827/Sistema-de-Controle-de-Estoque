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
using WpfSistemaDeEstoque.MVVM.ViewModel;

namespace WpfSistemaDeEstoque.MVVM.View
{
    /// <summary>
    /// Interação lógica para Movimentacao.xam
    /// </summary>
    public partial class Movimentacao : UserControl
    {
        public Movimentacao()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var popup = new CadastroMovimentacao();
            popup.Show();
            
        }

        private async void Mov_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as MovimentacaoViewModel;
            vm.ListarMovimentacaos();
        }
    }
}

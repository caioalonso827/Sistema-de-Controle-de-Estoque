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
    /// Interação lógica para Relatorios.xam
    /// </summary>
    public partial class Relatorios : UserControl
    {
        public async void Rel_Loaded (object sender, RoutedEventArgs e)
        {
            var vm = DataContext as RelatoriaViewModel;
            vm.listarEstoqueBaixo();

            vm.listarMovimentacaoDia();
        }

        public Relatorios()
        {
            InitializeComponent();
        }
    }
}

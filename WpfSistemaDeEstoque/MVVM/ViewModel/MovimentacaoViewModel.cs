using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using WpfSistemaDeEstoque.Data;
using WpfSistemaDeEstoque.Models;

namespace WpfSistemaDeEstoque.MVVM.ViewModel
{
    class MovimentacaoViewModel : ObjetoObservavel
    {
        private readonly ApiSevice apiSevice = new ApiSevice();

        private ObservableCollection<MovimentacaoModels> _movimentacao;

        public ObservableCollection<MovimentacaoModels> Movimentacaos
        {
            get { return _movimentacao; }
            set { _movimentacao = value; OnPropertyChanged(); }
        }

        public async void ListarMovimentacaos()
        {
            var movimentacao = await apiSevice.listarMovimentacaos();
            Movimentacaos = new ObservableCollection<MovimentacaoModels>(movimentacao);
        }



    }
}

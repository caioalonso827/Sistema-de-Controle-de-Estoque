using System;
using System.Collections.Generic;
using System.Text;
using WpfSistemaDeEstoque.Data;
using WpfSistemaDeEstoque.MVVM.View;

namespace WpfSistemaDeEstoque.MVVM.ViewModel
{
    internal class MainViewModel : ObjetoObservavel
    {
		private Inicio inicioVm {  get; set; }
        private Produtos produtosVm { get; set; }
        private Categorias categoriasVm { get; set; }
        private Movimentacao movimentacaoVm { get; set; }
        private Relatorios relatoriosVm { get; set; }


        public RelayCommand inicioRelayCommand { get; set; }
        public RelayCommand ProdutosRelayCommand { get; set; }
        public RelayCommand categoriaRelayCommand { get; set; }
        public RelayCommand movimentacaoRelayCommand { get; set; }
        public RelayCommand relatorioRelayCommand { get; set; }


		private object _currentView;

		public object CurrentView
		{
			get { return _currentView; }
			set { _currentView = value; OnPropertyChanged(); }
		}

        public MainViewModel()
        {
            inicioVm = new Inicio();
            produtosVm = new Produtos();
            categoriasVm = new Categorias();
            movimentacaoVm = new Movimentacao();
            relatoriosVm = new Relatorios();
            CurrentView = inicioVm;

            ProdutosRelayCommand = new RelayCommand ( o => { CurrentView = produtosVm; });
            inicioRelayCommand = new RelayCommand(o => { CurrentView = inicioVm; });
            categoriaRelayCommand = new RelayCommand(o => { CurrentView = categoriasVm; });
            movimentacaoRelayCommand = new RelayCommand(o => {CurrentView = movimentacaoVm; });
            relatorioRelayCommand = new RelayCommand(o => { CurrentView = relatoriosVm; });
            
        }
    }
}

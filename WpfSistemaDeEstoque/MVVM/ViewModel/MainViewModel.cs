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


        public RelayCommand inicioRelayCommand { get; set; }
        public RelayCommand ProdutosRelayCommand { get; set; }
        public RelayCommand categoriaRelayCommand { get; set; }


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
            CurrentView = inicioVm;

            ProdutosRelayCommand = new RelayCommand ( o => { CurrentView = produtosVm; });
            inicioRelayCommand = new RelayCommand(o => { CurrentView = inicioVm; });
            categoriaRelayCommand = new RelayCommand(o => { CurrentView = categoriasVm; });
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WpfSistemaDeEstoque.Data;
using WpfSistemaDeEstoque.Models;

namespace WpfSistemaDeEstoque.MVVM.ViewModel
{
    class RelatoriaViewModel : ObjetoObservavel
    {
        private ApiSevice apiSevice = new ApiSevice();

		private ObservableCollection<ProdutosModel> _produtosEstoque;

		public ObservableCollection<ProdutosModel> ProdutosEstoque
		{
			get { return _produtosEstoque; }
			set { _produtosEstoque = value; OnPropertyChanged(); }
		}

        public async void listarEstoqueBaixo()
        {
            var produtos = await apiSevice.listarEstoqueBaixo();
            ProdutosEstoque = new ObservableCollection<ProdutosModel>(produtos);
        }



		private ObservableCollection<MovimentacaoModels> _movimentacaoDia;

		public ObservableCollection<MovimentacaoModels> MovimentacaoDia
		{
			get { return _movimentacaoDia; }
			set { _movimentacaoDia = value; OnPropertyChanged(); }
		}

		public async void listarMovimentacaoDia ()
		{
			var mov = await apiSevice.listarMovimentaçoesDia();
			MovimentacaoDia = new ObservableCollection<MovimentacaoModels>(mov);
		}
	}
}

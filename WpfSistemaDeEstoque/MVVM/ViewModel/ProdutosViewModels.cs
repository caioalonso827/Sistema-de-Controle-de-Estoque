using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WpfSistemaDeEstoque.Data;
using WpfSistemaDeEstoque.Models;

namespace WpfSistemaDeEstoque.MVVM.ViewModel
{
    class ProdutosViewModels : ObjetoObservavel
    {
        public ApiSevice apiSevice = new ApiSevice();

        private ObservableCollection<ProdutosModel> _produtos;

		public ObservableCollection<ProdutosModel> Produtos
		{
			get { return _produtos; }
			set { _produtos = value; OnPropertyChanged(); }
		}



        public async Task listarProdutos()
        {
            var produtos = await apiSevice.listarTodos();
            Produtos = new ObservableCollection<ProdutosModel>(produtos);
        }

    }
}

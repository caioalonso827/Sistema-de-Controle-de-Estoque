using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WpfSistemaDeEstoque.Data;
using WpfSistemaDeEstoque.Models;

namespace WpfSistemaDeEstoque.MVVM.ViewModel
{
    class CategoriaViewModel : ObjetoObservavel
    {
        private readonly ApiSevice api = new ApiSevice();

		private ObservableCollection<Categoria> _categoria;

		public ObservableCollection<Categoria> Categoria
		{
			get { return _categoria; }
			set { _categoria = value; OnPropertyChanged(); }

			
		}

        public async Task listarCategorias()
        {
            var categorias = await api.listarCategorias();
            Categoria = new ObservableCollection<Categoria>(categorias);
        }

    }
}

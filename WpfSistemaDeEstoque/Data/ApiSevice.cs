using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using WpfSistemaDeEstoque.Models;

namespace WpfSistemaDeEstoque.Data
{
    class ApiSevice
    {
        private readonly HttpClient httpClient;

        public ApiSevice()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://sistema-de-controle-de-estoque-rmi1.onrender.com/");
        }

        public async Task<ProdutoModels> cadastroProduto(ProdutoModels produtoModels)
        {
            var response = await httpClient.PostAsJsonAsync("Produto/Cadastrar", produtoModels);

            if (response.IsSuccessStatusCode)
            {
                try { return await response.Content.ReadFromJsonAsync<ProdutoModels>(); }
                catch { Console.WriteLine("Erro na Api"); return null; }
            }

            else
            {
                MessageBox.Show("Erro Apii");
                return null;
            }
        }

        public async Task<List<ProdutosModel>> listarTodos()
        {
            var response = await httpClient.GetAsync("Produto/ListarTodos");

            if (response.IsSuccessStatusCode)
            {
                try { return await response.Content.ReadFromJsonAsync<List<ProdutosModel>>(); }
                catch { Console.WriteLine("Erro Api"); return new List<ProdutosModel>(); }
            }

            else
            {
                MessageBox.Show("Erro Api");
                return null;
            }
        }






        public async Task<List<Categoria>> listarCategorias()
        {
            var response = await httpClient.GetAsync("Categoria/ListarTodas");

            if (response.IsSuccessStatusCode)
            {
                try { return await response.Content.ReadFromJsonAsync<List<Categoria>>(); }
                catch { Console.WriteLine("Erro Api"); return new List<Categoria>(); }
            }

            else
            {
                MessageBox.Show("Erro Apii");
                return null;
            }

        }

        public async Task<Categoria> cadastrarCategoria(Categoria categoria)
        {
            var response = await httpClient.PostAsJsonAsync("Categoria/Cadastrar", categoria);

            if (response.IsSuccessStatusCode)
            {
                try { return await response.Content.ReadFromJsonAsync<Categoria>(); }
                catch { Console.WriteLine("Erro na Api"); return null; }
            }

            else
            {
                MessageBox.Show("Erro Api");
                return null;
            }
        }

        public async Task<List<MovimentacaoModels>> listarMovimentacaos()
        {
            var response = await httpClient.GetAsync("Movimentacao/ListarTodas");

            if (response.IsSuccessStatusCode)
            {
                try { return await response.Content.ReadFromJsonAsync<List<MovimentacaoModels>>(); }
                catch { Console.WriteLine("Erro api"); return null; }
            }

            else { MessageBox.Show("Erro na Api"); return null; }
        }

        public async Task<MovimentacaoModel> cadatroMovimentacao(MovimentacaoModel model)
        {
            var reponse = await httpClient.PostAsJsonAsync("Movimentacao/Cadastrar", model);

            if (reponse.IsSuccessStatusCode)
            {
                try { return await reponse.Content.ReadFromJsonAsync<MovimentacaoModel>(); }
                catch { Console.WriteLine("Erro api"); return null; }
            }

            else { MessageBox.Show("Erro na Api"); return null; }
        }

        public async Task<List<ProdutosModel>> listarEstoqueBaixo()
        {
            var response = await httpClient.GetAsync("Produto/ListarEstoqueBaixo");

            if (response.IsSuccessStatusCode)
            {
                try { return await response.Content.ReadFromJsonAsync<List<ProdutosModel>>(); }
                catch { Console.WriteLine("Erro na Api"); return null; }
            }

            else { Console.WriteLine("Erro na Api"); return null; }
        }

        public async Task<List<MovimentacaoModels>> listarMovimentaçoesDia()
        {
            var response = await httpClient.GetAsync("Movimentacao/ListarPorDia");

            if (response.IsSuccessStatusCode)
            {
                try { return await response.Content.ReadFromJsonAsync<List<MovimentacaoModels>>(); }
                catch { Console.WriteLine("Erro api"); return null; }
            }

            else { Console.WriteLine("Erro api"); return null; }
        }
    }
}

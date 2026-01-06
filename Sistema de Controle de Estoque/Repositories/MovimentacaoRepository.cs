using Microsoft.EntityFrameworkCore;
using Sistema_de_Controle_de_Estoque.Data;
using Sistema_de_Controle_de_Estoque.Models;
using Sistema_de_Controle_de_Estoque.Models.Dtos;

namespace Sistema_de_Controle_de_Estoque.Repositories
{
    public class MovimentacaoRepository
    {
            private readonly AppDbContext _contex;

            public MovimentacaoRepository(AppDbContext appDbContext)
            {
                _contex = appDbContext;
            }


            public async Task<Movimentacao> cadastrarMovimentacao( DtoCadastrarMovimentacao movimentacaoDto)
            {
                Produto produto = await _contex.produtos.FirstOrDefaultAsync(n=> n.Nome == movimentacaoDto.NomeProduto);
            if (produto == null) { throw new Exception("Não existe esse produto"); }
                
                if (movimentacaoDto.Tipo == Models.Enums.MovimentacaoEnum.Entrada) { produto.quantidade = produto.quantidade += movimentacaoDto.quantidade; }
                else if (movimentacaoDto.Tipo == Models.Enums.MovimentacaoEnum.Saída) { produto.quantidade = produto.quantidade -= movimentacaoDto.quantidade; }

                if (movimentacaoDto.Tipo == Models.Enums.MovimentacaoEnum.Saída && movimentacaoDto.quantidade > produto.quantidade) { throw new Exception("Não tem quantidade disponível no estoque"); }
               
                Movimentacao movimentacao = new Movimentacao();
                movimentacao.produto = produto;
                movimentacao.quantidade = movimentacaoDto.quantidade;
                movimentacao.Tipo = movimentacaoDto.Tipo;
                movimentacao.data = movimentacaoDto.data;
            


                 await _contex.movimentacao.AddAsync(movimentacao);

                 await _contex.SaveChangesAsync();
                return movimentacao;
            }

            public async Task<List<Movimentacao>> listarTodas()
            {
                List<Movimentacao> movimentacaos = _contex.movimentacao.ToList();

                return movimentacaos;
            }

            public async Task<List<Movimentacao>> listarPorDia ()
            {

            var movimentacaos = await _contex.movimentacao.Where(x => x.data == DateOnly.FromDateTime(DateTime.Today)).ToListAsync();
            return movimentacaos;
            }

            public async Task<string> removerMovimentacao(int id)
            {
                Movimentacao movimentacao = await _contex.movimentacao.FirstOrDefaultAsync(x => x.Id == id);
                _contex.movimentacao.Remove(movimentacao);

                await _contex.SaveChangesAsync();

                return null;
            }
        }
    }

using Itau_invest.Data;
using Itau_invest.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itau_invest.Services
{
    public class PosicaoService
    {
        private readonly AppDbContext _context;

        public PosicaoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Posicao>> GetAllAsync()
        {
            return await _context.Posicao.ToListAsync();
        }

        public async Task<Posicao> GetByIdAsync(int id)
        {
            return await _context.Posicao.FindAsync(id);
        }

        public async Task<Posicao> CreateAsync(Posicao posicao)
        {
            _context.Posicao.Add(posicao);
            await _context.SaveChangesAsync();
            return posicao;
        }

        public async Task<bool> UpdateAsync(int id, Posicao posicao)
        {
            if (id != posicao.IdPosicao)
                return false;

            _context.Entry(posicao).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var posicao = await _context.Posicao.FindAsync(id);
            if (posicao == null)
                return false;

            _context.Posicao.Remove(posicao);
            await _context.SaveChangesAsync();
            return true;
        }

        // Calcula o preço médio ponderado
        public async Task<decimal> CalcularPrecoMedio(int idUsuario, int idAtivo)
        {
            var compras = await _context.Operacao
                .Where(o => o.IdUsuario == idUsuario && o.IdAtivo == idAtivo && o.TipoOperacao == "compra")
                .ToListAsync();

            var totalQuantidade = compras.Sum(o => o.Quantidade);
            if (totalQuantidade == 0) return 0;

            var totalValor = compras.Sum(o => o.Quantidade * o.PrecoUnitario + o.Corretagem);
            return totalValor / totalQuantidade;
        }

        // Retorna posição atual de um usuário por papel (quantidade total)
        public async Task<decimal> CalcularQuantidadeAtual(int idUsuario, int idAtivo)
        {
            var operacoes = await _context.Operacao
                .Where(o => o.IdUsuario == idUsuario && o.IdAtivo == idAtivo)
                .ToListAsync();

            decimal qtdCompra = operacoes
                .Where(o => o.TipoOperacao == "compra")
                .Sum(o => o.Quantidade);

            decimal qtdVenda = operacoes
                .Where(o => o.TipoOperacao == "venda")
                .Sum(o => o.Quantidade);

            return qtdCompra - qtdVenda;
        }

        // Calcula lucro/prejuízo com base na última cotação
        public async Task<decimal> CalcularPL(int idUsuario, int idAtivo)
        {
            var precoMedio = await CalcularPrecoMedio(idUsuario, idAtivo);
            var qtdAtual = await CalcularQuantidadeAtual(idUsuario, idAtivo);

            var ultimaCotacao = await _context.Cotacao
                .Where(c => c.IdAtivo == idAtivo)
                .OrderByDescending(c => c.DataHora)
                .FirstOrDefaultAsync();

            if (ultimaCotacao == null) return 0;

            return (ultimaCotacao.PrecoUnitario - precoMedio) * qtdAtual;
        }

        // Total de corretagem por cliente
        public async Task<decimal> CalcularCorretagemTotal(int idUsuario)
        {
            return await _context.Operacao
                .Where(o => o.IdUsuario == idUsuario)
                .SumAsync(o => o.Corretagem);
        }

        public async Task<decimal> CalcularPrecoMedioPonderado(int idUsuario, int idAtivo)
        {
            var operacoes = await _context.Operacao
                .Where(o => o.IdUsuario == idUsuario && o.IdAtivo == idAtivo && o.TipoOperacao == "compra")
                .ToListAsync();

            var totalQuantidade = operacoes.Sum(o => o.Quantidade);
            if (totalQuantidade == 0) return 0;

            var totalValor = operacoes.Sum(o => o.Quantidade * o.PrecoUnitario + o.Corretagem);
            return totalValor / totalQuantidade;
        }

        public async Task<decimal> CalcularTotalCorretagem(int idUsuario)
        {
            var operacoes = await _context.Operacao
                .Where(o => o.IdUsuario == idUsuario)
                .ToListAsync();

            return operacoes.Sum(o => o.Corretagem);
        }
    }
}

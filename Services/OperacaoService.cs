using Itau_invest.Data;
using Itau_invest.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itau_invest.Services
{
    public class OperacaoService
    {
        private readonly AppDbContext _context;

        public OperacaoService(AppDbContext context) 
        {
            _context = context; 
        }

        public async Task<List<Operacao>> GetAllAsync()
        {
            return await _context.Operacao.ToListAsync();
        }

        public async Task<Operacao> GetByIdAsync(int id)
        {
            return await _context.Operacao.FindAsync(id);
        }

        public async Task<Operacao> CreateAsync(Operacao operacao)
        {
            _context.Operacao.Add(operacao);
            await _context.SaveChangesAsync();
            return operacao;
        }

        public async Task<bool> UpdateAsync(int id, Operacao operacao)
        {
            var existente = await _context.Operacao.FindAsync(id);
            if (existente == null)
                return false;

            // Atualiza os campos
            existente.IdUsuario = operacao.IdUsuario;
            existente.IdAtivo = operacao.IdAtivo;
            existente.TipoOperacao = operacao.TipoOperacao;
            existente.Quantidade = operacao.Quantidade;
            existente.PrecoUnitario = operacao.PrecoUnitario;
            existente.Corretagem = operacao.Corretagem;
            existente.DataOperacao = operacao.DataOperacao;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var operacao = await _context.Operacao.FindAsync(id);
            if(operacao == null)
                return false;

            _context.Operacao.Remove(operacao);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

using Itau_invest.Data;
using Itau_invest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Itau_invest.Services
{
    public class CotacaoService
    {
        private readonly AppDbContext _context;

        public CotacaoService(AppDbContext context) 
        {
            _context = context; 
        }

        public async Task<List<Cotacao>> GetAllAsync()
        {
            return await _context.Cotacao.ToListAsync();
        }

        public async Task<Cotacao> GetByIdAsync(int id)
        {
            return await _context.Cotacao.FindAsync(id);
        }

        public async Task<Cotacao> CreateAsync(Cotacao cotacao)
        {
            _context.Cotacao.Add(cotacao);
            await _context.SaveChangesAsync();
            return cotacao;
        }

        public async Task<bool> UpdateAsync(int id, Cotacao cotacao)
        {
            if (id != cotacao.IdCotacao) 
                return false;

            _context.Entry(cotacao).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cotacao = await _context.Cotacao.FindAsync(id);
            if (cotacao == null)
                return false;

            _context.Cotacao.Remove(cotacao);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

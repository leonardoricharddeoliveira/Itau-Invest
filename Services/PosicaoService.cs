using Itau_invest.Data;
using Itau_invest.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

    }
}

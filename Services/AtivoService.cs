using Itau_invest.Data;
using Itau_invest.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Itau_invest.Services
{
    public class AtivoService
    {
        private readonly AppDbContext _context;

        public AtivoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Ativo>> GetAllAsync()
        {
            return await _context.Ativo.ToListAsync();
        }

        public async Task<Ativo> GetByIdAsync(int id)
        {
            return await _context.Ativo.FindAsync(id);
        }

        public async Task<Ativo> CreateAsync(Ativo ativo)
        {
            _context.Ativo.Add(ativo);
            await _context.SaveChangesAsync();
            return ativo;
        }

        public async Task<bool> UpdateAsync(int id, Ativo ativo)
        {
            if (id != ativo.IdAtivo)
                return false;

            _context.Entry(ativo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ativo = await _context.Ativo.FindAsync(id);
            if (ativo == null)
                return false;

            _context.Ativo.Remove(ativo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

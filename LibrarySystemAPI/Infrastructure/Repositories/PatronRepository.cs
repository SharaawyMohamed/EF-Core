using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PatronRepository : IPatronRepository
    {
        private readonly LibraryDbContext _context;

        public PatronRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patron>> GetAllAsync()
        {
            return await _context.Patrons.ToListAsync();
        }

        public async Task<Patron> GetByIdAsync(int id)
        {
            return await _context.Patrons.FindAsync(id);
        }

        public async Task AddAsync(Patron patron)
        {
            patron.Id = default;
            await _context.Patrons.AddAsync(patron);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Patron patron)
        {
            _context.Patrons.Update(patron);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var patron = await _context.Patrons.FindAsync(id);
            if (patron != null)
            {
                _context.Patrons.Remove(patron);
                await _context.SaveChangesAsync();
            }
        }
    }
}

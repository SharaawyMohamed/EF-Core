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
    public class BorrowingRecordRepository : IBorrowingRecordRepository
    {
        private readonly LibraryDbContext _context;

        public BorrowingRecordRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BorrowingRecord>> GetAllAsync()
        {
            return await _context.BorrowingRecords.Include(br => br.Book).Include(br => br.Patron).ToListAsync();
        }

        public async Task<BorrowingRecord> GetByIdAsync(int id)
        {
            return await _context.BorrowingRecords.Include(br => br.Book).Include(br => br.Patron).FirstOrDefaultAsync(br => br.Id == id);
        }

        public async Task AddAsync(BorrowingRecord record)
        {
            record.Id = default;
            await _context.BorrowingRecords.AddAsync(record);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BorrowingRecord record)
        {
            _context.BorrowingRecords.Update(record);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var record = await _context.BorrowingRecords.FindAsync(id);
            if (record != null)
            {
                _context.BorrowingRecords.Remove(record);
                await _context.SaveChangesAsync();
            }
        }
    }
}

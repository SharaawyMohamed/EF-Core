using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IBorrowingRecordRepository
    {
        Task<IEnumerable<BorrowingRecord>> GetAllAsync();
        Task<BorrowingRecord> GetByIdAsync(int id);
        Task AddAsync(BorrowingRecord record);
        Task UpdateAsync(BorrowingRecord record);
        Task DeleteAsync(int id);
    }
}

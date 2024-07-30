using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IPatronRepository
    {
        Task<IEnumerable<Patron>> GetAllAsync();
        Task<Patron> GetByIdAsync(int id);
        Task AddAsync(Patron patron);
        Task UpdateAsync(Patron patron);
        Task DeleteAsync(int id);
    }
}

using Core.Data;
using Core.Models;
using Core.Services;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly OrderManagementDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(OrderManagementDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<bool> AddAsync(T entity)
        {
            var state = await _dbSet.AddAsync(entity);
            if (state is null)
            {
                return false;
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }
            //
            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return (await _dbSet.FindAsync(id))!;
        }

        public async Task<Product> GetByName(string name)
        {
            return (_context.Products.FirstOrDefault(p => p.Name == name))!;
        }

        public async Task<bool> Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }
    }
}

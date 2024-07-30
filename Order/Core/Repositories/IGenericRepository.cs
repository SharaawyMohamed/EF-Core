using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
	public interface IGenericRepository<T> where T : class
	{
		Task<T> GetById(int id);
		Task<Product> GetByName(string name);
		Task<IEnumerable<T>> GetAllAsync();
		Task<bool> AddAsync(T entity);
		Task<bool> Update(T entity);
		Task<bool> Delete(int id);
	}
}

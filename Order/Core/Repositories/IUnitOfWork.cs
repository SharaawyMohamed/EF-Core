using Core.Models;
using Core.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IUnitOfWork : IDisposable
	{
		IGenericRepository<Customer> Customers { get; }
		IGenericRepository<Order> Orders { get; }
		IGenericRepository<Product> Products { get; }
		IGenericRepository<AppUser> Users { get; }
		IGenericRepository<Invoice> Invoices { get; }
		int Complete();
	}
}

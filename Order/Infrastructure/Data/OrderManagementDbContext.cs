using Core.Models;
using Core.Models.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public class OrderManagementDbContext : DbContext
	{
		public OrderManagementDbContext(DbContextOptions<OrderManagementDbContext> options)
			: base(options)
		{
		}

		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<AppUser> Users { get; set; }
		public DbSet<Invoice> Invoices { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Customer>(builder =>
			{
				builder.HasKey(builder => builder.Id);
				builder.HasMany(o => o.Orders).WithOne(c => c.Customer);
			});

            modelBuilder.Entity<Order>()
            .Property(c => c.Id)
            .ValueGeneratedNever();

            modelBuilder.Entity<Order>(order =>
			{
				order.HasOne(order => order.Customer).WithMany(cust => cust.Orders);
				order.HasMany(orderitem => orderitem.OrderItems).WithOne(order => order.Order);

			});
			// Configure entity relationships, constraints, etc.
		}
	}
}

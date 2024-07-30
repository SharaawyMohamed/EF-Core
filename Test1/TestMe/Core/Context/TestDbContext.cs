using Microsoft.EntityFrameworkCore;
using TestMe.Core.Models;

namespace TestMe.Core.Context
{
	public class TestDbContext:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server =.; Database =Test1; Trusted_Connection =True;TrustServerCertificate=True");
		}
		public DbSet<Unit> UnitDetails { get; set; }
		public DbSet<invoiceDetail> InvoiceDetails { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Unit>().HasKey(k => k.UnitNo);
			modelBuilder.Entity<Unit>().HasMany(u=>u.Invoices).WithOne();

			modelBuilder.Entity<invoiceDetail>().HasKey(k =>k.LineNo);

		}
	}
}

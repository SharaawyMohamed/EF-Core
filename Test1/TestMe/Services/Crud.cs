using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TestMe.Core.Context;
using TestMe.Core.Models;

namespace TestMe.Services
{
    public class Crud : ICrud
    {
        private readonly TestDbContext context;

        public Crud(TestDbContext _context)
        {
            context = _context;
        }
        public async Task CreateInvoice(invoiceDetail model)
        {
            context.InvoiceDetails.Add(model);
            context.SaveChanges();
        }

        public async Task DeleteInvoice(int Id)
        {
            context.Remove(Id);
            context.SaveChanges();
        }

        public async Task<IEnumerable<invoiceDetail>> GetAll()
        {
            return await context.InvoiceDetails.ToListAsync();
        }
    }
}

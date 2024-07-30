using TestMe.Core.Models;

namespace TestMe.Services
{
    public interface ICrud
    {
        public Task CreateInvoice(invoiceDetail model);
        public Task DeleteInvoice(int Id);
        public Task<IEnumerable<invoiceDetail>> GetAll();
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using TestMe.Core.Models;
using TestMe.Services;

namespace TestMe.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ICrud crud;
        public InvoiceController(ICrud _crud)
        {
            crud = _crud;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateInvoice(invoiceDetail model)
        {
            crud.CreateInvoice(model);
            return View();
        }
        [HttpPost]
        public IActionResult GetAllInvoices()
        {
            return View(crud.GetAll());
        }
        [HttpGet]
        public IActionResult DeleteInvoice(int Id)
        {
            crud.DeleteInvoice(Id);
            return View();
        }
    }
}
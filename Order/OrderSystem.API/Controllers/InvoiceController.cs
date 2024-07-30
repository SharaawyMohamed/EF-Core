using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.DTOs;

namespace OrderSystem.Settings.Controllers
{
    [Authorize(Roles = "Admin")]

    public class InvoiceController : ApiBaseController
	{
		private readonly IInvoiceService _invoiceRepository;

		public InvoiceController(IInvoiceService invoiceRepository)
		{
			_invoiceRepository = invoiceRepository;
		}

		[HttpGet("{invoiceId}")]
		public async Task<ActionResult<InvoiceDto>> GetInvoiceById(int invoiceId)
		{
			var invoice = await (_invoiceRepository.GetInvoiceById(invoiceId))!;
			if (invoice == null)
			{
				return NotFound();
			}
			return Ok(invoice);
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<InvoiceDto>>> GetAllInvoices()
		{
			var invoices =await (_invoiceRepository.GetAllInvoices())!;
			if(invoices == null)
			{
				return BadRequest();
			}
			return Ok(invoices);
		}
	}
}

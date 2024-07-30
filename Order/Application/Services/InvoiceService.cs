using Core.DTOs;
using Core.Services;
using Core.Services;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{

    public class InvoiceService : IInvoiceService
	{
		private readonly IGenericRepository<Invoice> _invoiceRepository;

		public InvoiceService(IGenericRepository<Invoice> invoiceRepository)
		{
			_invoiceRepository = invoiceRepository;
		}

		public async Task<InvoiceDto>? GetInvoiceById(int invoiceId)
		{
			var invoice =await  _invoiceRepository.GetById(invoiceId);
			if (invoice == null)
			{
				return null;
			}
			var invoiceDto = new InvoiceDto()
			{
				InvoiceId = invoice.Id,
				OrderId = invoice.OrderId,
				InvoiceDate = invoice.InvoiceDate,
				TotalAmount = invoice.TotalAmount
			};
			return invoiceDto;
		}

		public async Task<IEnumerable<InvoiceDto>>? GetAllInvoices()
		{
			var invoices = await _invoiceRepository.GetAllAsync();
			if (!invoices.Any())
			{
				return null;
			}
			var invoiceDtos = invoices.Select(i => new InvoiceDto()
			{
				InvoiceId = i.Id,
				OrderId = i.OrderId,
				InvoiceDate = i.InvoiceDate,
				TotalAmount = i.TotalAmount
			}).ToList();
			return invoiceDtos;
		}
	}
}

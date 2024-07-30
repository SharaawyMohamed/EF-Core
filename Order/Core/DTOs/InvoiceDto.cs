using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
	public class InvoiceDto
	{
		public int InvoiceId { get; set; }
		public int OrderId { get; set; }
		public DateTime InvoiceDate { get; set; }
		public decimal TotalAmount { get; set; }
		public string PaymentType { get; set; } = string.Empty;
	}
}

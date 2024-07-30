using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
	public class Invoice
	{
		public int Id { get; set; }
		public virtual Order Order { get; set; }
		[ForeignKey("Order")]
		public int OrderId { get; set; } 
		public DateTime InvoiceDate { get; set; } = DateTime.Now;
		[DataType("decimal(8,4")]
		public decimal TotalAmount { get; set; }
	}
}

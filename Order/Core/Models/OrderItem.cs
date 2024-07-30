using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
	public class OrderItem
	{
		public int Id { get; set; }
		public virtual Order Order { get; set; }
		[ForeignKey("Order")]
		public int OrderId { get; set; }
		public virtual Product Product { get; set; }
		[ForeignKey("Product")]
		public int ProductId { get; set; }
		public int Quantity { get; set; }
		[DataType("decimal(8,4)")]
		public decimal UnitPrice { get; set; }
		[DataType("decimal(8,4)")]
		public decimal Discount { get; set; }
	}
}

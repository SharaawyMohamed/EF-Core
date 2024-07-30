using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
	public class OrderDto
	{
		public int OrderId { get; set; }
		public int CustomerId { get; set; }
		public DateTime OrderDate { get; set; }
		public decimal TotalAmount { get; set; }
		public List<OrderItemDto> OrderItems { get; set; }
		public string PaymentMethod { get; set; } = string.Empty;
		public string Status { get; set; }= string.Empty;
	}
}

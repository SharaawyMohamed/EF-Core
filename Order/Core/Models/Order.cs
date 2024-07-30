using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
	public class Order
	{
		public int Id { get; set; }

		public virtual Customer Customer { get; set; }
		[ForeignKey("Customer")]
		public int CustomerId { get; set; }

		public DateTime OrderDate { get; set; }= DateTime.Now;
		[DataType("decimal(8,5)")]
		public decimal TotalAmount { get; set; }
		public virtual ICollection<OrderItem> OrderItems { get; set; }
		public string PaymentMethod { get; set; } = string.Empty;
		public string Status { get; set; } = string.Empty;
	}
}

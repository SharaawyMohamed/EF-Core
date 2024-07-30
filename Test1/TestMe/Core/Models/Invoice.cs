using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace TestMe.Core.Models
{
	public class invoiceDetail	
	{
		public int LineNo { get; set; }
		[MaxLength(100)]
		public string productName { get; set; } = string.Empty;

		public Unit Unit { get; set; }
		[ForeignKey("Unit")]
		public int UnitNo { get; set; }
		[DataType("decimal(8,4)")]
		public decimal Price { get; set; }
		public int Quantity { get; set; }
		public int Total { get; set; }
		public DateTime expiryDate { get; set; }
	}
}

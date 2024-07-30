using System.ComponentModel.DataAnnotations;

namespace TestMe.Core.Models
{
	public class Unit
	{
		public int UnitNo { get; set; }
		[MaxLength(100)]
		public string UnitName { get; set; } = string.Empty;
		public ICollection<invoiceDetail> Invoices { get; set; }

	}
}

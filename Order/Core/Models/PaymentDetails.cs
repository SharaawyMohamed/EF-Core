using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
	internal class PaymentDetails
	{
		public string CardNumber { get; set; } = string.Empty;
		public string CardHolderName { get; set; } = string.Empty;
		public DateTime ExpiryDate { get; set; } = DateTime.Now;
		public string Cvv { get; set; } = string.Empty;

		public decimal Amount { get; set; }
		public string Currency { get; set; } = string.Empty;
		public string PaymentMethod { get; set; } = string.Empty;
	}
}

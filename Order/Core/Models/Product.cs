using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
	public class Product
	{
		public int Id { get; set; }
		[MaxLength(50)]
		public string Name { get; set; } = string.Empty;
		[DataType("decimal(8,4)")]
		public decimal Price { get; set; }
		public int Stock { get; set; }
	}
}

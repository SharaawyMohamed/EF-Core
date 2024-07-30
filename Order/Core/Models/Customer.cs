using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
	public class Customer
	{
		public int Id { get; set; }
		[MaxLength(30)]
		public string Name { get; set; } = string.Empty;
		[DataType(dataType:DataType.EmailAddress)]
		public string Email { get; set; } = string.Empty;
		public virtual ICollection<Order> Orders { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
	public class UserDtoResponse
	{
		public string Username { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		[DataType(DataType.PhoneNumber)]
		public string PhoneNumber { get; set; } = string.Empty;
		public string Token { get; set; }=string.Empty;

	}
}

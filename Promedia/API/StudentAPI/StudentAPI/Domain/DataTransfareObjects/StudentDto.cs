namespace StudentAPI.Domain.DataTransfareObjects
{
	public class StudentDto
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string NationalId { get; set; }
		public DateOnly BirthDate { get; set; }
		public string Address { get; set; } 
		public string Gender { get; set; }
	}
}

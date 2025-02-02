namespace StudentAPI.Domain.DataTransfareObjects
{
	public class StudentToReturnDto
	{
		public int Id { get; set; }

		public string FirstName { get; set; } = string.Empty;

		public string LastName { get; set; } =string.Empty;

		public string NationalId { get; set; } = string.Empty;

		public DateOnly BirthOfDate { get; set; }

		public string Address { get; set; } = string.Empty;

		public string Gender { get; set; } =string.Empty;
	}
}

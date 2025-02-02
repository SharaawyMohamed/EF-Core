namespace StudentAPI.Domain.Entities;

public partial class Student
{
	public int Id { get; set; }

	public string FirstName { get; set; } = null!;

	public string LastName { get; set; } = null!;

	public string NationalId { get; set; } = null!;

	public DateOnly BirthOfDate { get; set; }

	public string Address { get; set; } = null!;

	public string Gender { get; set; } = null!;
}

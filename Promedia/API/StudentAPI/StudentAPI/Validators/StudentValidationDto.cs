using FluentValidation;
using StudentAPI.Domain.DataTransfareObjects;

namespace StudentAPI.Validators
{
	public class StudentValidationDto : AbstractValidator<StudentDto>
	{
		public StudentValidationDto()
		{
			RuleFor(x => x.FirstName).NotEmpty().MinimumLength(3).MaximumLength(20);
			RuleFor(x => x.LastName).NotEmpty().MinimumLength(3).MaximumLength(20);
			RuleFor(x => x.NationalId).NotEmpty().Length(14);
			RuleFor(x => x.BirthDate).NotEmpty().LessThan(DateOnly.FromDateTime(DateTime.Now));
			RuleFor(x => x.Address).NotEmpty().Matches(@"^[A-Za-z0-9\s,.-]+$");
			RuleFor(x => x.Gender).NotEmpty().Length(1).Matches(@"^[MF]$");
		}
	}
}

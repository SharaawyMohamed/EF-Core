using BlazorServer.Domain;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.Pages
{
	public partial class UpdateStudentData
	{
		[Parameter] public int StudentId { get; set; }
		private Student student = new Student();
		private bool studentNotFound = false;
		private string message;

		protected override async Task OnInitializedAsync()
		{
			student = (await studentService.GetStudentById(StudentId))!;

			if (student == null)
			{
				studentNotFound = true;
			}
		}
			
		private async Task UpdateStudent()
		{
			if (student.Gender != "F" && student.Gender != "M")
			{
				message = "Invalid Gender Please Enter F 'Female' or M 'Male'";
				return;
			}

			message = await studentService.UpdateStudent(StudentId,student);
		}
	}
}

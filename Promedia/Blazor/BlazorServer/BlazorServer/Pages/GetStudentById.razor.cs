using BlazorServer.Domain;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.Pages
{
	public partial class GetStudentById
	{
		[Parameter] public string StudentId { get; set; }
		private Student student;
		private bool studentNotFound = true;

		protected override async Task OnInitializedAsync()
		{
			if (int.TryParse(StudentId, out var id))
			{
				student = (await studentService.GetStudentById(id))!;
				studentNotFound = (student == null);
			}
			
		}
	}
}

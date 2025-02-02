using BlazorServer.Domain;
using Microsoft.AspNetCore.Components;
using StudentAPI.Interfaces;
using StudentAPI.Service;

namespace BlazorServer.Pages
{
	public partial class DeleteStudentById
	{
		[Parameter] public string StudentId { get; set; }
		private string message;

		protected override async Task OnInitializedAsync()
		{
			if (int.TryParse(StudentId, out var id))
			{
				message = (await _studentService.DeleteStudentById(id))!;
			}
			else
			{
				message = "StudentId Should be decimal value!";
			}

		}
	}
}

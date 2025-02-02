using BlazorServer.Domain;

namespace BlazorServer.Pages
{
	public partial class AddStudent
	{
		private Student student = new Student();
		private string message = string.Empty;
		private async Task AddNewStudent()
		{
			if(student.Gender!="F" && student.Gender != "M")
			{
				message = "Invalid Gender Please Enter F 'Female' or M 'Male'";
				return;
			}
			message = await StudentService.AddStudentAsync(student);
		}
	}
}

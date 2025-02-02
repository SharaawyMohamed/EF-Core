using BlazorServer.Domain;

namespace BlazorServer.Pages
{
	public partial class GetAllStudents
	{
		private IEnumerable<Student> students;
		protected override async Task OnInitializedAsync()
		{
			students = (await studentService.GetAllStudnts())!;
		}
	}
}

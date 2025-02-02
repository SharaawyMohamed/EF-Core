
using BlazorServer.Domain;

namespace StudentAPI.Interfaces
{
	public interface IStudentService
	{
		Task<Student?> GetStudentById(int Id);

		Task<IEnumerable<Student>?> GetAllStudnts();

		Task<string> AddStudentAsync(Student student);

		Task<string> DeleteStudentById(int Id);

		Task<string> UpdateStudent(int Id,Student student);
	}
}

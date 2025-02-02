
using BlazorServer.Domain;

namespace StudentAPI.Repository
{
	public interface IStudentRepository
	{
		Task<Student> GetStudentById(int Id);

		Task<IEnumerable<Student>> GetAllStudnts();

		Task<bool> AddStudentAsync(Student student);

		Task<bool> IsValidNatianlId(string nationalId);

		bool DeleteStudent(Student student);

		bool UpdateStudent(Student student);
	}
}

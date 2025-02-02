using StudentAPI.Domain.DataTransfareObjects;
using StudentAPI.Domain.Entities;

namespace StudentAPI.Interfaces
{
	public interface IStudentService
	{
		Task<Responses> GetStudentById(int Id);

		Task<Responses> GetAllStudnts();

		Task<Responses> AddStudentAsync(StudentDto student);

		Task<Responses> DeleteStudentById(int Id);

		Task<Responses> UpdateStudent(int Id,StudentDto student);
	}
}

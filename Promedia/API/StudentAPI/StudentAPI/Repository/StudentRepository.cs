using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Domain;
using StudentAPI.Domain.Entities;
using StudentAPI.Repository;
using System.Net;
using System.Reflection;

namespace StudentAPI.Services
{
	public class StudentRepository : IStudentRepository
	{
		// open connection with DpContext
		private readonly PromediaContext _dbContext;
		public StudentRepository(PromediaContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<Student?> GetStudentById(int Id)
		=>  (_dbContext.Students.FromSqlRaw("SP_GetStudentById @Id={0}", Id).AsEnumerable().FirstOrDefault())!;

		public async Task<IEnumerable<Student>?> GetAllStudnts()
			=> await _dbContext.Students.FromSqlRaw("SP_GetAllStudents").ToListAsync();

		public async Task<bool> IsValidNatianlId(string nationalId)
		{
			var result = await _dbContext.Database.ExecuteSqlRawAsync("SP_ValidNationalId @NationalId = {0}", nationalId);
			return result <=0 ;
		}
		public async Task<bool> AddStudentAsync(Student student)
		{
			try
			{

				await _dbContext.Database.ExecuteSqlRawAsync(
				"EXEC SP_AddStudent @FName = {0}, @LName = {1}, @NationalId = {2}, @BirthDate = {3}, @Address = {4}, @Gender = {5}",
				student.FirstName, student.LastName, student.NationalId, student.BirthOfDate, student.Address, student.Gender);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool DeleteStudent(Student student)
		{
			try
			{
				_dbContext.Database.ExecuteSqlRaw("EXEC SP_DeleteStudentById @Id = {0}", student.Id);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool UpdateStudent(Student student)
		{
			try
			{
				_dbContext.Database.ExecuteSqlRaw(
				 "EXEC SP_UpdateStudent @Id = {0}, @FName = {1}, @LName = {2}, @NationalId = {3}, @BirthDate = {4}, @Address = {5}, @Gender = {6}",
				  student.Id, student.FirstName, student.LastName, student.NationalId, student.BirthOfDate, student.Address, student.Gender);
				return true;
			}
			catch
			{
				return false;
			}

		}
	}
}
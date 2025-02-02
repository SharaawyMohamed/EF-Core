using BlazorServer.Domain;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Repository;

namespace StudentAPI.Services
{
	public class StudentRepository : IStudentRepository
	{
		// open connection with DpContext
		private readonly PromediaDbContext _dbContext;
		public StudentRepository(PromediaDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<Student> GetStudentById(int Id)
			=> (await _dbContext.Students.FindAsync(Id))!;

		public async Task<IEnumerable<Student>> GetAllStudnts()
			=> await _dbContext.Students.ToListAsync();

		public async Task<bool> IsValidNatianlId(string nationalId)
			=> !await _dbContext.Students.AnyAsync(stud => stud.NationalId == nationalId);

		public async Task<bool> AddStudentAsync(Student student)
		{
			_dbContext.Set<Student>().Add(student);
			return (await _dbContext.SaveChangesAsync()) > 0;
		}

		public bool DeleteStudent(Student student)
		{
			_dbContext.Students.Remove(student);
			return _dbContext.SaveChanges() > 0;
		}

		public bool UpdateStudent(Student student)
		{
			_dbContext.Update(student);
			return _dbContext.SaveChanges() > 0;
		}

	}
}

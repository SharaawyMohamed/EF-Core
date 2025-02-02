using BlazorServer.Domain;
using StudentAPI.Interfaces;
using StudentAPI.Repository;
using System.Net;

namespace StudentAPI.Service
{
	public class StudentService : IStudentService
	{
		private readonly IStudentRepository _studntRepository;
		public StudentService(IStudentRepository studntRepository)
		{
			_studntRepository = studntRepository;
		}

		public async Task<string> AddStudentAsync(Student entity)
		{
			if (!await _studntRepository.IsValidNatianlId(entity.NationalId))
			{
				return $"NationalId {entity.NationalId} is already exist!";
			}
			if (await _studntRepository.AddStudentAsync(entity))
			{
				return "Studend has been added successfully!";
			}
			else
			{
				return "Internal server error!";
			}
		}

		public async Task<string> DeleteStudentById(int Id)
		{
			var student = await _studntRepository.GetStudentById(Id);
			if (student == null)
			{
				return $"Invalid student Id {Id}";
			}

			if (_studntRepository.DeleteStudent(student))
			{
				return "Student has been deleted sucessfully!";
			}
			else
			{
				return "Intenral server error";
			}
		}

		public async Task<IEnumerable<Student>?> GetAllStudnts()
		{
			var students = await _studntRepository.GetAllStudnts();
			if (students.Any())
			{
				return students;
			}
			else
			{
				return null;
			}
		}

		public async Task<Student?> GetStudentById(int Id)
		{
			var student = await _studntRepository.GetStudentById(Id);
			if (student == null)
			{
				return null;
			}
			else
			{
				return student;
			}
		}

		public async Task<string> UpdateStudent(int Id, Student student)
		{
			var oldStudent = await _studntRepository.GetStudentById(Id);
			if (oldStudent == null)
			{
				return  $"Invalid student Id {Id}";
			}

			if (!await _studntRepository.IsValidNatianlId(student.NationalId))
			{
				return  $"Invalid student's National Id {student.NationalId} is already exist!";
			}

			oldStudent.FirstName = student.FirstName;
			oldStudent.LastName = student.LastName;
			oldStudent.BirthOfDate = student.BirthOfDate;
			oldStudent.Address = student.Address;
			oldStudent.Gender = student.Gender;

			if (_studntRepository.UpdateStudent(oldStudent))
			{
				return "Studnt has been updated successfully!";
			}
			else
			{
				return  $"Internal server error";
			}
		}

	}
}

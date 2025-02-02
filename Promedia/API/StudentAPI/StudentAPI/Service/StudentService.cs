using AutoMapper;
using StudentAPI.Domain.DataTransfareObjects;
using StudentAPI.Domain.Entities;
using StudentAPI.Interfaces;
using StudentAPI.Repository;
using System.Net;

namespace StudentAPI.Service
{
	public class StudentService : IStudentService
	{
		private readonly IStudentRepository _studntRepository;
		private readonly IMapper _mapper;
		public StudentService(IStudentRepository studntRepository, IMapper mapper)
		{
			_studntRepository = studntRepository;
			_mapper = mapper;
		}

		public async Task<Responses> AddStudentAsync(StudentDto entity)
		{
			if (!await _studntRepository.IsValidNatianlId(entity.NationalId))
			{
				return await Responses.FailurResponse(HttpStatusCode.BadRequest,$"NationalId {entity.NationalId} is already exist!");
			}
			var student = _mapper.Map<Student>(entity);
			if (await _studntRepository.AddStudentAsync(student))
			{
				return await Responses.SuccessResponse("Studend has been added successfully!");
			}
			else
			{
				return await Responses.FailurResponse(HttpStatusCode.InternalServerError, "Internal server error!");
			}
		}

		public async Task<Responses> DeleteStudentById(int Id)
		{
			var student = await _studntRepository.GetStudentById(Id);
			if (student == null)
			{
				return await Responses.FailurResponse(HttpStatusCode.NotFound, $"Invalid student Id {Id}");
			}

			if (_studntRepository.DeleteStudent(student))
			{
				return await Responses.SuccessResponse("Student has been deleted sucessfully!");
			}
			else
			{
				return await Responses.FailurResponse(HttpStatusCode.InternalServerError, "Intenral server error");
			}
		}

		public async Task<Responses> GetAllStudnts()
		{
			var students = await _studntRepository.GetAllStudnts();
			if (students.Any())
			{
				var mappedStudents = _mapper.Map<IEnumerable<StudentToReturnDto>>(students);
				return await Responses.SuccessResponse(data: mappedStudents);
			}
			else
			{
				return await Responses.FailurResponse(HttpStatusCode.OK, "There is not student in database yet!");
			}
		}

		public async Task<Responses> GetStudentById(int Id)
		{
			var student = await _studntRepository.GetStudentById(Id);
			if (student == null)
			{
				return await Responses.FailurResponse(HttpStatusCode.BadRequest, $"Invalid student Id {Id}");
			}
			else
			{
				var mappedStudent = _mapper.Map<StudentToReturnDto>(student);
				return await Responses.SuccessResponse(data: mappedStudent);
			}
		}

		public async Task<Responses> UpdateStudent(int Id, StudentDto student)
		{
			var oldStudent = await _studntRepository.GetStudentById(Id);
			if (oldStudent == null)
			{
				return await Responses.FailurResponse(HttpStatusCode.BadRequest, $"Invalid student Id {Id}");
			}

			if (!await _studntRepository.IsValidNatianlId(student.NationalId))
			{
				return await Responses.FailurResponse(HttpStatusCode.BadRequest, $"Invalid student's National Id {student.NationalId} is already exist!");
			}

			oldStudent.FirstName = student.FirstName;
			oldStudent.LastName = student.LastName;
			oldStudent.BirthOfDate = student.BirthDate;
			oldStudent.Address = student.Address;
			oldStudent.Gender = student.Gender;

			if (_studntRepository.UpdateStudent(oldStudent))
			{
				return await Responses.SuccessResponse("Studnt has been updated successfully!");
			}
			else
			{
				return await Responses.FailurResponse(HttpStatusCode.InternalServerError, $"Internal server error");
			}
		}

	}
}

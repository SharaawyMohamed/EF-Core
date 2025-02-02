using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Domain.DataTransfareObjects;
using StudentAPI.Interfaces;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Net;
using System.Threading;

namespace StudentAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private readonly IStudentService _studentService;
		private readonly IValidator<StudentDto> _validator;
		public StudentController(IStudentService studentService, IValidator<StudentDto> validator)
		{
			_studentService = studentService;
			_validator = validator;
		}

		[HttpPost]
		public async Task<ActionResult<Responses>> AddStudent(StudentDto student)
		{
			var validationResult = await _validator.ValidateAsync(student);
			if (!validationResult.IsValid)
			{
				return await Responses.FailurResponse(HttpStatusCode.BadRequest, null, validationResult.Errors.ToList());
			}

			return Ok(await _studentService.AddStudentAsync(student));
		}

		[HttpGet("GetAllStudents")]
		public async Task<ActionResult<Responses>> GetAllStudents()
		{
			return Ok(await _studentService.GetAllStudnts());
		}
		[HttpGet("GetStudentById/{Id}")]
		public async Task<ActionResult<Responses>> GetStudentById([FromRoute] int Id)
		{

			return Ok(await _studentService.GetStudentById(Id));
		}

		[HttpPut("{Id}")]
		public async Task<ActionResult<Responses>> UpdateStudent([FromRoute] int Id, [FromBody] StudentDto student)
		{
			var validationResult = await _validator.ValidateAsync(student);
			if (!validationResult.IsValid)
			{
				return await Responses.FailurResponse(HttpStatusCode.BadRequest, null, validationResult.Errors.ToList());
			}

			return Ok(await _studentService.UpdateStudent(Id, student));
		}

		[HttpDelete("{Id}")]
		public async Task<ActionResult> DeleteStudentById([FromRoute] int Id)
		{
			return Ok(await _studentService.DeleteStudentById(Id));
		}
	}
}

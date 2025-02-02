using FluentValidation;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Domain;
using StudentAPI.Domain.DataTransfareObjects;
using StudentAPI.Interfaces;
using StudentAPI.Repository;
using StudentAPI.Service;
using StudentAPI.Services;
using StudentAPI.Validators;

namespace StudentAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			#region Data base connection
			builder.Services.AddDbContext<PromediaContext>();
			#endregion
			builder.Services.AddScoped<IStudentRepository, StudentRepository>();
			builder.Services.AddScoped<IStudentService, StudentService>();
			builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			builder.Services.AddValidatorsFromAssemblyContaining<StudentDto>();
			builder.Services.AddControllers();

			var app = builder.Build();

			// Configure the HTTP request pipeline.

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}

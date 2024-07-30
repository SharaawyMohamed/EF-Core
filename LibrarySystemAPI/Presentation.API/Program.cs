
using Application.Mappers;
using Application.Services;
using Domain.Repositories;
using Domain.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Presentation.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<LibraryDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IPatronRepository, PatronRepository>();
            builder.Services.AddScoped<IBorrowingRecordRepository, BorrowingRecordRepository>();
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IPatronService, PatronService>();
            builder.Services.AddScoped<IBorrowingRecordService, BorrowingRecordService>();

            builder.Services.AddAutoMapper(typeof(LibraryProfile));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LibraryManagementSystem.API", Version = "v1" });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LibraryManagementSystem.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}

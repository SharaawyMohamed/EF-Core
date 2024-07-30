using Core.Services;
using Core.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Application.Services;
using OrderSystem.API.Settings;

namespace OrderSystem.Settings.API
{
    public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<OrderManagementDbContext>(options =>
				options.UseInMemoryDatabase("OrderManagementDb"));

			services.AddScoped(typeof(IGenericRepository<>), typeof(IGenericRepository<>));
			services.AddScoped<OrderService>();

			services.AddControllers();
			services.AddSwaggerGen();

			var key = Encoding.ASCII.GetBytes("your_secret_key");
			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(x =>
			{
				x.RequireHttpsMetadata = false;
				x.SaveToken = true;
				x.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false
				};
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order Management Settings V1");
			});
		}
	}
}

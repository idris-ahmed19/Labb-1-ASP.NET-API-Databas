
using Labb_1_ASP.NET_API___Databas.Data;
using Microsoft.EntityFrameworkCore;
using Labb_1_ASP.NET_API___Databas.Services;
using Labb_1_ASP.NET_API___Databas.Services.IServices;
using Labb_1_ASP.NET_API___Databas.Data.Repos.IRepos;
using Labb_1_ASP.NET_API___Databas.Data.Repos;

namespace Labb_1_ASP.NET_API___Databas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<RestaurantContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

			builder.Services.AddScoped<ICustomerService, CustomerService>();
			builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

			builder.Services.AddScoped<ITableService, TableService>();
			builder.Services.AddScoped<ITableRepository, TableRepository>();

            builder.Services.AddScoped<IBookingService, BookingService>();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();

            builder.Services.AddScoped<IMenuService, MenuService>();
			builder.Services.AddScoped<IMenuRepository, MenuRepository>();

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

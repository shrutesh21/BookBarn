using BookBarn_Api.Model.Data;
using BookBarn_Api.Model.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookBarn_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //1. Configure the EF core context
            string conStr = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<BooksDbContext>(options =>
            {
                options.UseSqlServer(conStr);
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();

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

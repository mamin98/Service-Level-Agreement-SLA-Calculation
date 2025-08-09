using Microsoft.EntityFrameworkCore;
using SLA.Application;
using SLA.Infrastructure;

namespace SLA.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // ➕ Register DbContext
        builder.Services.AddDbContext<SLADbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        );

        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        DbSeeder.Seed(app.Services);

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseCors();
        app.MapControllers();

        app.Run();
    }
}

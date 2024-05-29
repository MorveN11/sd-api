using Microsoft.EntityFrameworkCore;
using Project.Core.Handlers;
using Project.DataAccess.Context;
using Project.DataAccess.Initializer;
using Project.DataAccess.Repositories.Concretes;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.Api
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<ErrorHandler>();
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<PostgresContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("ContextDb"))
            );

            builder.Logging.AddLog4Net("Log4Net.config");

            builder.Services.AddScoped<IStudentRepository, StudentRepository>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<PostgresContext>();
                if (app.Environment.IsDevelopment())
                {
                    context.Database.EnsureDeleted();
                    context.Database.Migrate();
                    DbInitializer.Initialize(context);
                }
            }

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

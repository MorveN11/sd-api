using Microsoft.EntityFrameworkCore;
using Project.Core.Handlers;
using Project.DataAccess.Context;
using Project.DataAccess.Initializer;
using Project.DataAccess.Repositories.Concretes;
using Project.DataAccess.Repositories.Interfaces;
using Serilog;

namespace Project.Api
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(
                    "log.txt",
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Level:u3}: {Message:lj}{NewLine}{Exception}"
                )
                .CreateLogger();

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

            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped(typeof(LogHandler));

            builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));

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

using Microsoft.EntityFrameworkCore;
using Project.DataAccess.Context;

namespace Project.Api
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<PostgresContext>(options =>
                options.UseNpgsql(
                    builder.Configuration.GetConnectionString("ContextDb"),
                    builder => builder.MigrationsAssembly("Project.Api")
                )
            );
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<PostgresContext>();
                if (app.Environment.IsDevelopment())
                {
                    context.Database.Migrate();
                }
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapGet("/", () => "Hello World");
            app.Run();
        }
    }
}

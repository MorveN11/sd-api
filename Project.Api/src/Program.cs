using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Project.Api.Configurations;
using Project.Business;
using Project.Business.DTOs.Careers;
using Project.Business.DTOs.Students;
using Project.Business.Validators.Careers;
using Project.Business.Validators.Students;
using Project.Core.Handlers;
using Project.Core.Responses;
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

            builder
                .Services.AddControllers(options =>
                {
                    options.Filters.Add<ErrorHandler>();
                    options.Conventions.Add(new CustomRoutingConvetion());
                })
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft
                        .Json
                        .ReferenceLoopHandling
                        .Ignore
                )
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = context =>
                    {
                        var result = new ExceptionResponse
                        {
                            errors = context
                                .ModelState.Where(e => e.Value?.Errors.Count > 0)
                                .SelectMany(e =>
                                    e.Value?.Errors != null
                                        ? e.Value.Errors.Select(error => error.ErrorMessage)
                                        : new List<string> { }
                                )
                                .ToList(),
                            status = StatusCodes.Status400BadRequest
                        };

                        return new BadRequestObjectResult(result);
                    };
                });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Api with C#", Version = "v1" });
            });

            builder.Services.AddDbContext<PostgresContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("ContextDb"))
            );

            builder.Services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblies(typeof(ProjectProfile).Assembly)
            );
            builder.Services.AddAutoMapper(typeof(ProjectProfile).Assembly);

            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<ICareerRepository, CareerRepository>();
            builder.Services.AddScoped<IStudentCareerRepository, StudentCareerRepository>();
            builder.Services.AddScoped(typeof(LogHandler));

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();

            builder.Services.AddTransient<IValidator<StudentRequestDTO>, StudentValidator>();
            builder.Services.AddTransient<IValidator<CareerRequestDTO>, CareerValidator>();

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
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Api with C# V1");
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}

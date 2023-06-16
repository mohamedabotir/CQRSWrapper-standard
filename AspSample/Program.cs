
using AspSample.Commands;
using AspSample.Models;
using AspSample.Queries;
using CQRS.Pattern;
using CQRS.Providers;
using CQRSWrapper.Decorator;
using Microsoft.Extensions.DependencyInjection;
using Sample.Commands;

namespace AspSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services
             .AddTransient<ICommandHandler<UserCommand>, UserCommandHandler>();


            builder.Services
             .AddTransient<ICommandHandler<JobIdCommand>>
             (op=>new DatabaseRetriesDecorator<JobIdCommand>(new JobCommadHandler()));

            builder.Services
             .AddTransient<IQueryHandler<GetUserList, UserDTO>, GetUserListHandler>();
            builder.Services.AddSingleton<CQSScane>();

            builder.Services
              .AddSingleton<CQSScane>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
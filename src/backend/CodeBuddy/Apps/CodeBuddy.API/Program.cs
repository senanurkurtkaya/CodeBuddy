using CodeBuddy.Business;
using CodeBuddy.DataAccess;
using CodeBuddy.Infrastructure.Elastic;

using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace CodeBuddy.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddProblemDetails();
            builder.Services.AddCors(corsOptions =>
            {
                corsOptions.AddDefaultPolicy(corsPolicy =>
                {
                    corsPolicy.AllowAnyHeader();
                    corsPolicy.AllowAnyMethod();
                    corsPolicy.AllowAnyOrigin();
                });
            });

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = builder.Configuration["Authentication:Authority"];
                options.Audience = builder.Configuration["Authentication:Audience"];
            });

            builder.Services.AddHttpLogging(opt =>
            {
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddBusinessLayer(builder.Environment);
            builder.Services.AddDataAccess(builder.Environment, builder.Configuration.GetConnectionString("CodeBuddy"));
            builder.Services.AddElasticClient(builder.Configuration["ElasticClient:Url"], builder.Configuration["ElasticClient:ApiKey"]);

            var app = builder.Build();

            app.UseCors();

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

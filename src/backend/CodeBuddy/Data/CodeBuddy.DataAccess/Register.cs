using CodeBuddy.DataAccess.Context;
using CodeBuddy.DataAccess.Helpers;
using CodeBuddy.DataAccess.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CodeBuddy.DataAccess
{
    public static class Register
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IHostEnvironment environment, string connectionString)
        {
            services.AddPooledDbContextFactory<CodeBuddyDbContext>(options =>
            {
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 3);
                });

                if (environment.IsDevelopment())
                {
                    options.EnableSensitiveDataLogging();
                    options.EnableDetailedErrors();
                }
            });

            services.AddScoped<CodeBuddyDbContextFactory>();
            services.AddScoped(
                sp => sp.GetRequiredService<CodeBuddyDbContextFactory>().CreateDbContext());

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ITransactionManager, TransactionManager>();

            if (environment.IsDevelopment())
            {
                services.AddScoped<IDbContextHelper, DbContextHelper>();
            }

            return services;
        }
    }
}

using CodeBuddyBusiness.PipelineBehaviours;
using CodeBuddyBusiness.PipelineBehaviours.VoidBehaviors;

using FluentValidation;

using Mapster;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System.Reflection;

namespace CodeBuddy.Business
{
    public static class Register
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services, IHostEnvironment hostingEnvironment)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(Register).Assembly);
                config.AddOpenBehavior(typeof(LoggingBehavior<,>));
                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
                config.AddOpenBehavior(typeof(TransactionBehavior<,>));
                config.AddOpenBehavior(typeof(LoggingBehaviorForVoidRequests<,>));
                config.AddOpenBehavior(typeof(ValidationBehaviorForVoidRequests<,>));
                config.AddOpenBehavior(typeof(TransactionBehaviorForVoidRequest<,>));
            });

            services.AddValidatorsFromAssembly(typeof(Register).Assembly, includeInternalTypes: true);

            //services.AddSeedServices(hostingEnvironment.EnvironmentName);

            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
            TypeAdapterConfig.GlobalSettings.Default.IgnoreNullValues(true);

            return services;
        }
    }
}

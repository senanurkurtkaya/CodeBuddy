using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddy.DataAccess.Elastic
{
    public static class Register
    {
        public static IServiceCollection AddElasticDataAccess(this IServiceCollection services)
        {


            return services;
        }
    }
}

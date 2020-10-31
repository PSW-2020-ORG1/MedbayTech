using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace Database
{
    public static class MySQLServiceCollectionExtensions
    {
        
        public static IServiceCollection RegisterMySQLDataServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<MySQLContext>(options =>
                options.UseMySql(configuration.GetConnectionString("MySQLConnectionString")));

            return services;
        }
    }
}

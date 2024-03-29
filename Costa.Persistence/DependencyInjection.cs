﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Costa.Application.Interfaces;


namespace Costa.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<CostaDbContext>(options => {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<ICostaDbContext>(provider => provider.GetService<CostaDbContext>());            

            return services;
        }
    }
}

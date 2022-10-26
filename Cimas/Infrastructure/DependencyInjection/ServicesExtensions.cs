﻿using Cimas.Service.Company;
using Cimas.Storage.Uow;
using Microsoft.Extensions.DependencyInjection;

namespace Cimas.Infrastructure.DependencyInjection
{
    public static class ServicesExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddServices();
            services.AddRepositories();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICompanyService, CompanyService>();
            //...
        }

        public static void AddRepositories(this IServiceCollection repositories)
        {
            repositories.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}

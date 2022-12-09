using Cimas.Service.Authorization;
using Cimas.Service.Companies;
using Cimas.Service.Halls;
using Cimas.Service.Sessions;
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
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IHallService, HallService>();
            services.AddScoped<ISessionService, SessionService>();
        }

        public static void AddRepositories(this IServiceCollection repositories)
        {
            repositories.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}

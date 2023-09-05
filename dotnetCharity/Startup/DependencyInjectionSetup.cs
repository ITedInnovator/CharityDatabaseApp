using dotnet_charity_db.Services;

namespace dotnet_charity_db.Startup
{
    public static class DependencyInjectionSetup
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddScoped<IDbService, DbService>();
            services.AddScoped<ICharityService, CharityService>();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }
    }
}

using PowerApi.Application.Interfaces;
using PowerApi.Application.Interfaces.Repositories;
using PowerApi.Application.Interfaces.Services;
using PowerApi.Data.Repositories;
using PowerApi.Domain.Services;

namespace PowerApi.Configurations
{
    public static class ResolveServices
    {
        public static IServiceCollection ResolveService(this IServiceCollection services)
        {
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }

    }
}

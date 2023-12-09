
using Microsoft.EntityFrameworkCore;
using PowerApi.Data.Context;

namespace PowerApi.Configurations
{
    public static class ServiceApi
    {
        public static void RegisterService(this IServiceCollection services, IConfiguration configuration,
         IWebHostEnvironment env)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("policyCors", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            /*

            var autorizationPolicy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();

            JwtAuthService.RegisterLogin(services, configuration, null);
          

            services.AddAuthorizationCore(options => options.AddPolicy("Bearer", autorizationPolicy));
              */

            services.AddControllers( /*opt => opt.Filters.Add(new AuthorizeFilter(autorizationPolicy)) */)
                .AddJsonOptions(opt =>
                {
                    opt.JsonSerializerOptions.PropertyNamingPolicy = null;
                    opt.JsonSerializerOptions.ReferenceHandler = null;
                });

            services.AddHttpContextAccessor();

            if (env.EnvironmentName == "Migration")
            {
                services.AddDbContext<PowerApiContext>(op =>
                {
                    var connection = configuration.GetConnectionString("Migration");
                    op.UseMySql(connection, ServerVersion.AutoDetect(connection));
                });
            }
            else
            {
                services.AddDbContext<PowerApiContext>(op =>
                {
                    var connection = configuration.GetConnectionString("Production");
                    op.UseMySql(connection, ServerVersion.AutoDetect(connection));
                });
            }
        }
    }
}

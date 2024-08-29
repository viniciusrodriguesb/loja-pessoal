using Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.CrossCutting
{
    public static class ServiceInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContext>(options => options.UseNpgsql(configuration.GetConnectionString("SupabaseConnection")));

            services.AddScoped<UsuarioService>();
            services.AddScoped<TokenService>();
            services.AddScoped<EmpresaService>();

            return services;
        }
    }
}

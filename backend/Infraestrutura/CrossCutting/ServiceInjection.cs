using Application.Services;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.CrossCutting
{
    public static class ServiceInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContextBase>(options => options.UseNpgsql(configuration.GetConnectionString("SupabaseConnection")));

            services.AddHttpClient();

            services.AddScoped<UsuarioService>();
            services.AddScoped<TokenService>();
            services.AddScoped<EmpresaService>();
            services.AddScoped<LogService>();
            services.AddScoped<FornecedorService>();

            return services;
        }
    }
}

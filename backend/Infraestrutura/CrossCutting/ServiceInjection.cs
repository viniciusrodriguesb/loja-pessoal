using Application.Services;
using Domain;
using Domain.Repositories;
using Domain.Repositories.Interfaces;
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

            ConfigurarClientHttp(services);   
            ConfigurarServicos(services);
            ConfigurarRepositorios(services);

            return services;
        }

        private static void ConfigurarClientHttp(IServiceCollection services)
        {
            services.AddHttpClient();
        }
        private static void ConfigurarServicos(IServiceCollection services)
        {
            services.AddScoped<UsuarioService>();
            services.AddScoped<TokenService>();
            services.AddScoped<EmpresaService>();
            services.AddScoped<FornecedorService>();
        }
        private static void ConfigurarRepositorios(IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ILogUsuarioRepository, LogUsuarioRepository>();
            services.AddScoped<ILogEmpresaRepository, LogEmpresaRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
        }
    }
}

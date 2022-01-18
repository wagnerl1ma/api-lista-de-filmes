using ListaDeFilmes.Api.Extensions;
using ListaDeFilmes.Business.Interfaces;
using ListaDeFilmes.Business.Notificacoes;
using ListaDeFilmes.Business.Services;
using ListaDeFilmes.Data.Context;
using ListaDeFilmes.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ListaDeFilmes.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ListaDeFilmesContext>();

            services.AddScoped<IFilmeRepository, FilmeRepository>();
            services.AddScoped<IGeneroRepository, GeneroRepository>();

            services.AddScoped<INotificador, Notificador>();

            services.AddScoped<IFilmeService, FilmeService>();
            services.AddScoped<IGeneroService, GeneroService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}

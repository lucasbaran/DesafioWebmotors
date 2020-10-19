using DesafioWebmotors.Application.Interfaces;
using DesafioWebmotors.Application.Services;
using DesafioWebmotors.Domain.Repositories;
using DesafioWebmotors.Infra.Data;
using DesafioWebmotors.Infra.Data.Repositories;
using DesafioWebmotors.Infra.ExternalServices;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioWebmotors.Infra.IoC
{
    public static class InjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<IAnuncioWebmotorsService, AnuncioWebmotorsService>();

            //services.AddTransient<IValidator<NewSchedule>, NewScheduleValidator>();

            // Infra - Data
            services.AddScoped<IAnuncioWebmotorsRepository, AnuncioWebmotorsRepository>();
            services.AddScoped<DefaultDbContext>();

            // Infra - External Services

            services.AddHttpClient<IExternalService, ExternalService>();
            services.AddScoped<IExternalService, ExternalService>();
        }
    }
}

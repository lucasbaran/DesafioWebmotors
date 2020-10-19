using Microsoft.Extensions.DependencyInjection;

namespace DesafioWebmotors.Infra.IoC
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            InjectorBootStrapper.RegisterServices(services);
        }
    }
}

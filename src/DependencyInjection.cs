using MudBlazor.Services;
using SupportHelper.Blazor.Configuration.EnvironmentVariables;
using SupportHelper.Blazor.Interfaces;
using SupportHelper.Blazor.Services;
using System.Net.Http.Headers;

namespace SupportHelper.Blazor
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            Services(services);
            HttpClientServices(services);
            ServicesMudBlazor(services);
            OptionsPattern(services);
            return services;
        }

        private static void Services(IServiceCollection services)
        {
            services.AddScoped<IMachineServices, MachineServices>();
        }

        private static void HttpClientServices(IServiceCollection services)
        {
            services.AddHttpClient("Default", opts =>
            {
                opts.BaseAddress = new Uri("http://localhost:5001");
                opts.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
            });
        }

        private static void ServicesMudBlazor(IServiceCollection services)
        {
            services.AddMudServices(config =>
            {
                
            });
        }

        private static void OptionsPattern(IServiceCollection services)
        {
            services.AddOptions<HttpClientOptions>()
                .BindConfiguration(nameof(HttpClientOptions));
        }
    }
}

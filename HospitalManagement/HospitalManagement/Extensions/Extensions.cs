using System;
using System.Linq;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestEase;

namespace HospitalManagement.Extensions
{
    public static class Extensions
    {
        public static void RegisterServiceForwarder<T>(this IServiceCollection services, string serviceName)
        where T : class
        {
            var clientName = typeof(T).ToString();
            var options = ConfigureOptions(services);
            ConfigureDefaultClient(services, clientName, serviceName, options);
            ConfigureForwarder<T>(services, clientName);
        }
        private static RestEaseOptions ConfigureOptions(IServiceCollection services)
        {
            IConfiguration configuration;
            using (var serviceProvider = services.BuildServiceProvider())
            {
                configuration = serviceProvider.GetService<IConfiguration>();
            }
            services.Configure<RestEaseOptions>(configuration.GetSection("restEase"));
            return configuration.GetSection("restEase").Get<RestEaseOptions>();
        }
        private static void ConfigureDefaultClient(IServiceCollection services, string clientName,
            string serviceName, RestEaseOptions options)
        {
            services.AddHttpClient(clientName, client =>
            {
                var service = options.Services.SingleOrDefault(s => s.Name.Equals(serviceName,
                   StringComparison.InvariantCultureIgnoreCase));
                if (service == null)
                {
                    throw new Exception($"RestEase service: '{serviceName}' was not found.");
                }
                client.BaseAddress = new UriBuilder
                {
                    Scheme = service.Scheme,
                    Host = service.Host,
                    Port = service.Port
                }.Uri;
            });
        }
        private static void ConfigureForwarder<T>(IServiceCollection services, string clientName) where T : class
        {
            services.AddTransient<T>(c => new RestClient(c.GetService<IHttpClientFactory>().CreateClient(clientName))
            {
                RequestQueryParamSerializer = new QueryParamSerializer()
            }.For<T>());
        }
    }
}
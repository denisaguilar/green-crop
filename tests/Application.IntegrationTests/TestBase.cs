using GreenCrop.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using WebUI;

namespace Application.IntegrationTests {
    public class TestBase : IDisposable {
        public static IServiceScopeFactory ScopeFactory;
        private static IConfigurationRoot _configuration;

        public TestBase() {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables()
                .Build();

            var startup = new Startup(_configuration);
            var services = new ServiceCollection();
            startup.ConfigureServices(services);

            var rootContainer = services.BuildServiceProvider();
            ScopeFactory = rootContainer.GetService<IServiceScopeFactory>();

            SeedData();
        }

        private async void SeedData() {
            using var scope = ScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
            await ApplicationDbContextSeed.SeedData(context);
        }

        public void Dispose() {}
    }
}
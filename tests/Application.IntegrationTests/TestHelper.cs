using GreenCrop.Domain.Entities;
using GreenCrop.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using WebUI;

namespace Application.IntegrationTests {
    public class TestHelper : IDisposable {
        private static IServiceScopeFactory _scopeFactory;
        private static IConfigurationRoot _configuration;

        public TestHelper() {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables()
                .Build();

            var services = new ServiceCollection();

            var startup = new Startup(_configuration);
            startup.ConfigureServices(services);

            var rootContainer = services.BuildServiceProvider();
            _scopeFactory = rootContainer.GetService<IServiceScopeFactory>();

            SeedData();
        }

        public async void SeedData() {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
            await ApplicationDbContextSeed.SeedData(context);
        }

        public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request) {
            using var scope = _scopeFactory.CreateScope();
            var mediator = scope.ServiceProvider.GetService<ISender>();
            return await mediator.Send(request);
        }

        public async Task<Account> FindAccountAsync(string id) {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
            return await context.Accounts.Include(a => a.Transactions).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<int> CountAsync<TEntity>() where TEntity : class {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
            return await context.Set<TEntity>().CountAsync();
        }

        public void Dispose() {            
        }
    }
}
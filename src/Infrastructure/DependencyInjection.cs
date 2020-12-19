using GreenCrop.Application.Common.Interfaces;
using GreenCrop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenCrop.Infrastructure {
    public static class DependencyInjection {
        private const string DatabaseName = "GreenCropDb";

        public static IServiceCollection AddInfrastructure(this IServiceCollection services) {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase(DatabaseName));
            services.AddScoped<IApplicationDbContext>(provider =>
                provider.GetService<ApplicationDbContext>());
            return services;
        }
    }
}

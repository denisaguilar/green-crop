using AutoMapper;
using FluentValidation;
using GreenCrop.Application.Common.Behaviours;
using GreenCrop.Application.Common.Interfaces;
using GreenCrop.Application.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GreenCrop.Application {
    public static class DependencyInjection {

        public static IServiceCollection AddApplication(this IServiceCollection services) {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<IAccountCreationService, AccountCreationService>();
            services.AddScoped<ITransactionCreationService, TransactionCreationService>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            return services;
        }
    }
}

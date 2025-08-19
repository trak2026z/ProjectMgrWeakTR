using AutoMapper;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop;
using CarWorkshop.Application.Mappings;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CarWorkshop.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserContext , UserContext>();

            services.AddMediatR(typeof(CreateCarWorkshopCommand));

            services.AddScoped(provider =>
            {
                var userContext = provider.GetRequiredService<IUserContext>();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new MappingProfile(userContext));
                });
                return config.CreateMapper();
            });

            services.AddValidatorsFromAssemblyContaining<CarWorkshopCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}

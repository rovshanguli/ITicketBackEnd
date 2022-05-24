using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;

namespace ServiceLayer
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {

            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<IHallService, HallService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<ISeansService, SeansService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IEmailService, EmailService>();


            return services;
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            return services;
        }
    }
}

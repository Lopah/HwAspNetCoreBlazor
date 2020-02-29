using HwAspNetCoreBlazor.Middleware;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HwAspNetCoreBlazor.Extensions
{
    public static class StartupConfigurationExtensions
    {
        public static void ConfigureHeaderValidation(this IServiceCollection services)
        {
            services.AddTransient<ValidateHeaderHandler>();
        }
        public static void ConfigureReservationService(this IServiceCollection services)
        {
            services.AddHttpClient("reservationService", c =>
            {
               c.BaseAddress = new Uri("https://localhost");
            })
            .AddHttpMessageHandler<ValidateHeaderHandler>();
        }

        public static void ConfigureRoomService( this IServiceCollection services)
        {
            services.AddHttpClient("roomService", c =>
            {
                c.BaseAddress = new Uri("https://localhost");
            })
            .AddHttpMessageHandler<ValidateHeaderHandler>();
        }
    }
}

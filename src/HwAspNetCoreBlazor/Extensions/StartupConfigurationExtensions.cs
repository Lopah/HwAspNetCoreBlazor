using AutoMapper;
using HwAspNetCoreBlazor.Core.Interfaces.Repositories;
using HwAspNetCoreBlazor.Data.Mappings;
using HwAspNetCoreBlazor.Data.Repositories;
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
            });
            //.AddHttpMessageHandler<ValidateHeaderHandler>()
            //.SetHandlerLifetime(TimeSpan.FromMinutes(5));
        }

        public static void ConfigureRoomService( this IServiceCollection services)
        {
            services.AddHttpClient("roomService", c =>
            {
                c.BaseAddress = new Uri("https://localhost");
            });
            //.AddHttpMessageHandler<ValidateHeaderHandler>();
        }

        public static void ConfigureModelServicesAndMapper( this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<IRoomRepository, RoomRepository>();

            services.AddScoped<IReservationRepository, ReservationRepository>();
        }
    }
}

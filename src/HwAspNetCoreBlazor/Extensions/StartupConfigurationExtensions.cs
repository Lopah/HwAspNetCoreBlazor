using HwAspNetCoreBlazor.Core.Interfaces.Repositories;
using HwAspNetCoreBlazor.Data.Repositories;
using HwAspNetCoreBlazor.Services;
using HwAspNetCoreBlazor.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HwAspNetCoreBlazor.Extensions
{
    public static class StartupConfigurationExtensions
    {
        public static void ConfigureDataServices(this IServiceCollection services)
        {
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IReservationService, ReservationService>();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
        }
    }
}

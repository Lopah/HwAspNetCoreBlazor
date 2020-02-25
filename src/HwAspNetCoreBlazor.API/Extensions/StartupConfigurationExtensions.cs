using AutoMapper;
using HwAspNetCoreBlazor.Core.Interfaces.Repositories;
using HwAspNetCoreBlazor.Data.Mappings;
using HwAspNetCoreBlazor.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HwAspNetCoreBlazor.API.Extensions
{
    public static class StartupConfigurationExtensions
    {
        public static void RegisterRepositories( this IServiceCollection services )
        {
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
        }

        public static void ConfigureMappingProfiles( this IServiceCollection services )
        {
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}

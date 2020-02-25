using AutoMapper;
using HwAspNetCoreBlazor.Core.Models;
using HwAspNetCoreBlazor.Data.Entities;

namespace HwAspNetCoreBlazor.Data.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RoomModel, Room>();

            CreateMap<ReservationModel, Reservation>();

            CreateMap<Reservation, ReservationModel>();

            CreateMap<Room, RoomModel>();
        }
    }
}

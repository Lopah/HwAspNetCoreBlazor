using HwAspNetCoreBlazor.Core.Models;
using System;
using System.Threading.Tasks;

namespace HwAspNetCoreBlazor.Services.Interfaces
{
    public interface IReservationService
    {
        Task<ReservationModel> SaveReservation(string roomName, ReservationModel reservation);
    }
}

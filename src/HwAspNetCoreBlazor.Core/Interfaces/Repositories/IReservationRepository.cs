using HwAspNetCoreBlazor.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HwAspNetCoreBlazor.Core.Interfaces.Repositories
{
    public interface IReservationRepository : IGenericRepository<ReservationModel>
    {
        Task<IList<ReservationModel>> GetByDateAsync(DateTime time);

        Task<ReservationModel> GetByRoomNameAndDateAsync(DateTime time, string roomName);

        Task<ReservationModel> SaveReservationAsync(ReservationModel reservation, string roomName);
    }
}

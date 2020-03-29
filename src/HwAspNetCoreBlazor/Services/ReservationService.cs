using HwAspNetCoreBlazor.Core.Interfaces.Repositories;
using HwAspNetCoreBlazor.Core.Models;
using HwAspNetCoreBlazor.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HwAspNetCoreBlazor.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _repository;
        private readonly ILogger<ReservationService> _logger;

        public ReservationService(IReservationRepository repository, ILogger<ReservationService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ReservationModel> SaveReservation(string roomName,ReservationModel reservation)
        {
            var existingReservation = await _repository.GetByRoomNameAndDateAsync(reservation.ReservationDateTime, roomName);

            if (existingReservation == null)
            {
                return await _repository.SaveReservationAsync(reservation, roomName);
            }
            else return null;
        }
    }
}

using AutoMapper;
using HwAspNetCoreBlazor.Core.Interfaces.Repositories;
using HwAspNetCoreBlazor.Core.Models;
using HwAspNetCoreBlazor.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HwAspNetCoreBlazor.Data.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly IMapper _mapper;
        private readonly HwAspNetCoreBlazorDbContext _context;
        public ReservationRepository(HwAspNetCoreBlazorDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IList<ReservationModel>> GetAllAsync()
        {
            var selected = await _context.Reservations.ToListAsync();

            return selected.Select(x => _mapper.Map<ReservationModel>(x)).ToList();
        }

        //FIXME: Removed unused
        public async Task<IList<ReservationModel>> GetByDateAsync(DateTime time)
        {
            var selected = await _context.Reservations
                .Where(e => e.ReservationDateTime == time)
                .ToListAsync();

            return selected.Select(x => _mapper.Map<ReservationModel>(x)).ToList();
        }

        public async Task<ReservationModel> GetByIdAsync(int id)
        {
            var selected = await _context.Reservations
                .Where(e => e.Id == id)
                .ToListAsync();

            return selected.Select(x => _mapper.Map<ReservationModel>(x)).FirstOrDefault();
        }

        public async Task<ReservationModel> GetByRoomNameAndDateAsync(DateTime time, string roomName)
        {
            var selected = await _context.Reservations
                .Include(e => e.Room)
                .Where(e => e.Room.Name == roomName &&
                    e.ReservationDateTime == time)
                .ToListAsync();

            return selected.Select(x => _mapper.Map<ReservationModel>(x)).FirstOrDefault();
        }

        public async Task<ReservationModel> SaveReservationAsync(ReservationModel reservation, string roomName)
        {
            var mappedEntity = _mapper.Map<Reservation>(reservation);

            // FIXME: VERY hacky solution, will need to re-do.
            var parentRoom = _context.Rooms
                .Where(e => e.Name == roomName).FirstOrDefault();
            mappedEntity.Room = parentRoom;
            //

            if (mappedEntity == null)
            {
                throw new NotImplementedException();
            }
            var addedEntity =  (await _context.AddAsync(mappedEntity)).Entity; // this is an ugly workaround but whatever
            // this can still be an error. Will see. Might need to add additional database error checking.
            await _context.SaveChangesAsync();
            return _mapper.Map<ReservationModel>(addedEntity);
        }
    }
}

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
        /// <summary>
        /// Returns all reservations for a given day in the current <see cref="DateTime.Date"/>
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public async Task<IList<ReservationModel>> GetByDateAsync(DateTime time)
        {
            var selected = await _context.Reservations
                .Where(e => e.ReservationDateTime.Date == time.Date)
                .ToListAsync();

            return selected.Select(x => _mapper.Map<ReservationModel>(x)).ToList();
        }

        /// <summary>
        /// Returns a reservation for a given hour of the day.
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public async Task<ReservationModel> GetByHourAsync(DateTime time)
        {
            var selected = await _context.Reservations
                .Where(e => e.ReservationDateTime.TimeOfDay == time.TimeOfDay
                    && e.ReservationDateTime.Date == time.Date)
                .ToListAsync();

            var mappedResults = selected.Select(x => _mapper.Map<ReservationModel>(x));
            return mappedResults.Count() == 1 ? mappedResults.First() : null;
        }

        public async Task<ReservationModel> GetByIdAsync(int id)
        {
            var selected = await _context.Reservations
                .Where(e => e.Id == id)
                .ToListAsync();

            return selected.Select(x => _mapper.Map<ReservationModel>(x)).FirstOrDefault();
        }

        public async Task<ReservationModel> AddAsync(ReservationModel entity)
        {
            var mappedReservation = _mapper.Map<Reservation>(entity);
            if (_context.Reservations.Find(mappedReservation) != null)
                return null;
            else
            {
                await _context.Reservations.AddAsync(mappedReservation);
                await _context.SaveChangesAsync();
            }
            return entity;
        }
    }
}

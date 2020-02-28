using AutoMapper;
using HwAspNetCoreBlazor.Core.Interfaces.Repositories;
using HwAspNetCoreBlazor.Core.Models;
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
    }
}

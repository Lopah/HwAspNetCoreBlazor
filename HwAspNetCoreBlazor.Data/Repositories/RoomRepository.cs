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
    public class RoomRepository : IRoomRepository
    {
        private readonly IMapper _mapper;
        private readonly HwAspNetCoreBlazorDbContext _context;

        public RoomRepository(HwAspNetCoreBlazorDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<RoomModel>> GetAllAsync()
        {
            var selected = await _context.Rooms.ToListAsync();

            return selected.Select(x => _mapper.Map<RoomModel>(x)).ToList();
        }

        // TODO: If I ever want to set id, implement this.
        public Task<RoomModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<RoomModel> GetByNameAsync(string name)
        {
            var selected = await _context.Rooms
                .Where(e => e.Name == name)
                .ToListAsync();

            return selected.Select(x => _mapper.Map<RoomModel>(x)).FirstOrDefault();

            // TODO: Decide if I want to throws errors for not found objects here or in controller.
        }

        public async Task<IList<RoomModel>> GetByTimeFromAsync(int timeFrom)
        {
            var selected = await _context.Rooms
                .Where(e => e.OpeningTimeFrom == timeFrom)
                .ToListAsync();

            return selected.Select(x => _mapper.Map<RoomModel>(x)).ToList();
        }

        public async Task<IList<RoomModel>> GetByTimeFromUntilAsync(int timeFrom, int timeTo)
        {
            var selected = await _context.Rooms
                .Where(e => e.OpeningTimeFrom == timeFrom
                && e.OpeningTimeTo == timeTo)
                .ToListAsync();

            return selected.Select(x => _mapper.Map<RoomModel>(x)).ToList();
        }

        public async Task<IList<RoomModel>> GetByTimeToAsync(int timeTo)
        {
            var selected = await _context.Rooms
                .Where(e => e.OpeningTimeTo == timeTo)
                .ToListAsync();

            return selected.Select(x => _mapper.Map<RoomModel>(x)).ToList();
        }
    }
}

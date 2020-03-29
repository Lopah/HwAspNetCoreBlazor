using HwAspNetCoreBlazor.Core.Interfaces.Repositories;
using HwAspNetCoreBlazor.Core.Models;
using HwAspNetCoreBlazor.Services.Interfaces;
using HwAspNetCoreBlazor.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HwAspNetCoreBlazor.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;

        public RoomService(IRoomRepository repository)
        {
            _repository = repository;
        }

        public Task<Dictionary<string, string>> GetAllValidHours(RoomModel room)
        {
            var timeslots = new Dictionary<string, string>();

            for (int i = room.OpeningTimeFrom; i < room.OpeningTimeTo; i++)
            {
                timeslots.Add($"{i}:00", $"{i + 1}:00");
            }
            return Task.FromResult(timeslots);
        }

        public async Task<PaginatedItemsViewModel<RoomModel>> GetPaginatedItemsAsync(int size, int index)
        {
            var totalRooms = await _repository.GetTotalRoomsCount();

            var paginatedRooms = await _repository.GetRoomsPaginated(size, index);

            return new PaginatedItemsViewModel<RoomModel>(
                index, size, totalRooms, paginatedRooms);
        }

        public async Task<RoomModel> GetRoomByNameAsync(string name)
        {
            return await _repository.GetByNameAsync(name);
        }
    }
}

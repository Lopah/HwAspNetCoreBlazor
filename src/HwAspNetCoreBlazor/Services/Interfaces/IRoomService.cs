using HwAspNetCoreBlazor.Core.Models;
using HwAspNetCoreBlazor.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HwAspNetCoreBlazor.Services.Interfaces
{
    public interface IRoomService
    {
        Task<PaginatedItemsViewModel<RoomModel>> GetPaginatedItemsAsync(int size, int index);

        Task<RoomModel> GetRoomByNameAsync(string name);

        Task<Dictionary<string, string>> GetAllValidHours(RoomModel room);
    }
}

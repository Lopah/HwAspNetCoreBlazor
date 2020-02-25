using HwAspNetCoreBlazor.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HwAspNetCoreBlazor.Core.Interfaces.Repositories
{
    public interface IRoomRepository: IGenericRepository<RoomModel>
    {
        Task<IList<RoomModel>> GetByTimeFromAsync(int timeFrom);

        Task<IList<RoomModel>> GetByTimeToAsync(int timeTo);

        Task<IList<RoomModel>> GetByTimeFromUntilAsync(int timeFrom, int timeTo);

        Task<RoomModel> GetByNameAsync(string name);
    }
}

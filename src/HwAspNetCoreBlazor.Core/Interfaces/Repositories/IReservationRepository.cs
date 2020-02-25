using HwAspNetCoreBlazor.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwAspNetCoreBlazor.Core.Interfaces.Repositories
{
    public interface IReservationRepository : IGenericRepository<ReservationModel>
    {
        Task<IList<ReservationModel>> GetByDateAsync(DateTime time);
    }
}

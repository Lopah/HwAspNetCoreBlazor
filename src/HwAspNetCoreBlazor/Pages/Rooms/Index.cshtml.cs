using HwAspNetCoreBlazor.Core.Interfaces.Repositories;
using HwAspNetCoreBlazor.Core.Models;
using HwAspNetCoreBlazor.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwAspNetCoreBlazor.Pages.Rooms
{
    public class IndexModel : PageModel
    {
        private readonly IRoomRepository _roomRepository;

        public IndexModel(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public IList<RoomModel> Rooms { get; set; }

        public async Task OnGetAsync()
        {
            Rooms = await _roomRepository.GetAllAsync();
        }
    }
}

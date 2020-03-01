using HwAspNetCoreBlazor.Core.Interfaces.Repositories;
using HwAspNetCoreBlazor.Core.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HwAspNetCoreBlazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IRoomRepository _roomRepository;

        public IList<RoomModel> Rooms { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IRoomRepository roomRepository)
        {
            _logger = logger;
            _roomRepository = roomRepository;
        }

        public async Task OnGetAsync()
        {
            Rooms = await _roomRepository.GetAllAsync();
        }
    }
}

using HwAspNetCoreBlazor.Core.Models;
using HwAspNetCoreBlazor.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HwAspNetCoreBlazor.Models
{
    public class RoomPageModel : PageModel
    {
        private readonly RoomService _roomService;

        public IEnumerable<RoomModel> RoomModels { get; private set; }

        public bool GetRoomsError { get; set; }

        public bool HasRooms => RoomModels.Any();

        public RoomPageModel(RoomService roomService)
        {
            _roomService = roomService;
        }

        public async Task OnGet()
        {
            try
            {
                RoomModels = await _roomService.GetRoomsFromApi();
            }
            catch (HttpRequestException)
            {
                GetRoomsError = true;
                RoomModels = Array.Empty<RoomModel>();
            }
        }
    }
}

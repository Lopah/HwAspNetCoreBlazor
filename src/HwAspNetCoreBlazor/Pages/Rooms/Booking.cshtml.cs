using HwAspNetCoreBlazor.Core.Interfaces.Repositories;
using HwAspNetCoreBlazor.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwAspNetCoreBlazor.Pages.Rooms
{
    public class Booking : PageModel
    {
        private readonly ILogger<Booking> _logger;
        private readonly IRoomRepository _roomRepository;
        private DateTime _selectedDay;

        public Booking(ILogger<Booking> logger, IRoomRepository roomRepository)
        {
            _logger = logger;
            _roomRepository = roomRepository;
        }

        public RoomModel Room { get; set; }
        
        [BindProperty]
        public DateTime SelectedDay
        {
            get => _selectedDay;
            set
            {
                if (value.Date < DateTimeOffset.UtcNow.Date)
                    _selectedDay = DateTimeOffset.UtcNow.Date;
                else
                    _selectedDay = value;
            }
        }

        public IDictionary<string, ReservationModel> TimesOfTheDay { get; set; }

        public async Task<IActionResult> OnGetAsync(string name)
        {
            SelectedDay = DateTime.Now.Date;

            if (string.IsNullOrEmpty(name)) return NotFound();

            Room = await _roomRepository.GetByNameAsync(name);

            if (Room is null) return NotFound();
            TimesOfTheDay = GetAllTimesInGivenDay();
            return Page();
        }

        private Dictionary<string, ReservationModel> GetAllTimesInGivenDay()
        {
            // This only works in 24h format for obvious reasons.
            var numHours = Room.OpeningTimeTo - Room.OpeningTimeFrom;
            var listOfValidTimeSlots = new Dictionary<string, ReservationModel>();

            for (int i = 0; i < numHours; i++)
            {
                var reservation = Room.Reservations.Where(x => x.ReservationDateTime.TimeOfDay.Hours == Room.OpeningTimeFrom + i && x.ReservationDateTime.Date == SelectedDay.Date).FirstOrDefault();
                var innerValidTimeSlot = $"{Room.OpeningTimeFrom + i}:00 - {Room.OpeningTimeFrom + i + 1}:00";
                listOfValidTimeSlots.Add(innerValidTimeSlot, reservation);
            }
            return listOfValidTimeSlots;
        }

        public async Task<IActionResult> SetTimeBlock()
        {
            return Page();
        }
    }
}

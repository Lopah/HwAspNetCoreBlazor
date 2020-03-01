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
    public class CustomerDetails : PageModel
    {
        private readonly ILogger<CustomerDetails> _logger;
        private readonly IReservationRepository _reservationRepository;
        private readonly IRoomRepository _roomRepository;

        public CustomerDetails(ILogger<CustomerDetails> logger, IReservationRepository reservationRepository, IRoomRepository roomRepository)
        {
            _logger = logger;
            _reservationRepository = reservationRepository;
            _roomRepository = roomRepository;
        }

        public RoomModel Room { get; set; }
        public string TimeSlot { get; set; }
        public ReservationModel Reservation { get; set; }

        public async Task<IActionResult> OnGetAsync(string room, DateTime Timeslot)
        {
            if (string.IsNullOrEmpty(room) || Timeslot == null) return NotFound();

            Room = await _roomRepository.GetByNameAsync(room);

            if (Room is null) return NotFound();

            TimeSlot = $"{Timeslot.ToString("dd-MM-yyyy")} {Timeslot.TimeOfDay} - {Timeslot.TimeOfDay.Add(TimeSpan.FromHours(1))}";

            Reservation = new ReservationModel
            {
                ReservationDateTime = Timeslot
            };

            return Page();
        }

        public async Task<IActionResult> OnPostNewReservationAsync()
        {
            var resultedReservation = await _reservationRepository.AddAsync(Reservation);
            if (resultedReservation != null) return RedirectToPage("../Index");
            else return RedirectToPage("./Booking", Room.Name);
        }
    }
}

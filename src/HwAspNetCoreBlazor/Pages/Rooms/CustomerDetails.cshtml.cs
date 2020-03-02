using HwAspNetCoreBlazor.Core.Interfaces.Repositories;
using HwAspNetCoreBlazor.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
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

        public async Task<IActionResult> OnGetAsync(string room, DateTime timeslot)
        {
            if (string.IsNullOrEmpty(room) || timeslot == null) return NotFound();

            Room = await _roomRepository.GetByNameAsync(room);

            if (Room is null) return NotFound();

            if ((timeslot.TimeOfDay.Hours < Room.OpeningTimeFrom || timeslot.TimeOfDay.Hours > Room.OpeningTimeTo))
                return BadRequest();

            TimeSlot = $"{timeslot.ToString("dd-MM-yyyy")} {timeslot.TimeOfDay}" +
                $" - {timeslot.TimeOfDay.Add(TimeSpan.FromHours(1))}";

            Reservation = new ReservationModel
            {
                ReservationDateTime = timeslot
            };

            // This can be wrong logic - I want to check if the given date isn't already occupied
            var checkTimeConflictReservation = await _reservationRepository.GetByHourAsync(Reservation.ReservationDateTime);
            if (checkTimeConflictReservation != null) return BadRequest();

            return Page();
        }

        // FIXME: Need to check somewhere if this date isn't occupied (forged GET request can fool this PageModel.
        public async Task<IActionResult> OnPostNewReservationAsync()
        {
            var resultedReservation = await _reservationRepository.AddAsync(Reservation);
            if (resultedReservation != null) return RedirectToPage("../Index");
            else return RedirectToPage("./Booking", Room.Name);
        }
    }
}

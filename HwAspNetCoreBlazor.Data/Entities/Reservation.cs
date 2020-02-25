using System;

namespace HwAspNetCoreBlazor.Data.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        public DateTime ReservationDateTime { get; set; }

        public string ClientName { get; set; }

        public string ClientSurname { get; set; }

        public string ClientEmail { get; set; }

        public string ClientPhone { get; set; }

        public string Notes { get; set; }

        public Room Room { get; set; }
    }
}

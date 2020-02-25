using System.Collections.Generic;

namespace HwAspNetCoreBlazor.Data.Entities
{
    public class Room
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int OpeningTimeFrom { get; set; }

        public int OpeningTimeTo { get; set; }

        public IList<Reservation> Reservations { get; set; }
    }
}

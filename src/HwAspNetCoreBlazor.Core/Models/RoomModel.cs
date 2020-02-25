using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HwAspNetCoreBlazor.Core.Models
{
    public class RoomModel
    {
        /// <summary>
        /// Represents the name of the room
        /// </summary>
        [Required, StringLength(maximumLength: 50, ErrorMessage = "The {0} needs to be at least {1} and less than {2} characters long.", MinimumLength = 1)]
        public string Name { get; set; }


        /// <summary>
        /// Description of the room that will be rendered.
        /// </summary>
        [Required, StringLength(maximumLength: 500, ErrorMessage = "The {0} needs to be at least {1} and less than {2} characters long.", MinimumLength = 50)]
        public string Description { get; set; }

        /// <summary>
        /// Represents the hour in the day when the room opens.
        /// </summary>
        [Required]
        public int OpeningTimeFrom { get; set; }


        /// <summary>
        /// Represents the hour in the day this room is available until.
        /// </summary>
        [Required]
        public int OpeningTimeTo { get; set; }

        public IList<ReservationModel> Reservations { get; set; }
    }
}

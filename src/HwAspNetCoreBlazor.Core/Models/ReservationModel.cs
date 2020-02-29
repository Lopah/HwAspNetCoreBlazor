using System;
using System.ComponentModel.DataAnnotations;

namespace HwAspNetCoreBlazor.Core.Models
{
    public class ReservationModel
    {
        [Required, DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}"), DataType(DataType.Date)]
        public DateTime ReservationDateTime { get; set; }

        [Required, StringLength(maximumLength:50, ErrorMessage = "The {0} needs to be at least {1} and under {2} characters long.", MinimumLength = 1)]
        public string ClientName { get; set; }
        [Required, StringLength(maximumLength:50, ErrorMessage = "The {0} needs to be at least {1} and under {2} characters long.", MinimumLength = 1)]
        public string ClientSurname { get; set; }

        [Required,DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address.")]
        public string ClientEmail { get; set; }

        [Required,DataType(DataType.PhoneNumber, ErrorMessage = "Please enter a correct phone number.")]
        public string ClientPhone { get; set; }

        [StringLength(maximumLength:500, ErrorMessage = "Your notes are too long.")]
        public string Notes { get; set; }
    }
}

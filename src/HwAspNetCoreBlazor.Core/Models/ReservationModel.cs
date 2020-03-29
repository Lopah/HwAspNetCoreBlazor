using System;
using System.ComponentModel.DataAnnotations;

namespace HwAspNetCoreBlazor.Core.Models
{
    public class ReservationModel
    {
        [Required, DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}"), DataType(DataType.Date)]
        public DateTime ReservationDateTime { get; set; }

        [Required, Display(Name = "First name"), StringLength(maximumLength:50, ErrorMessage = "The {0} needs to be at least {2} and under {1} characters long.", MinimumLength = 1)]
        public string ClientName { get; set; }
        [Required, Display(Name ="Last name"), StringLength(maximumLength:50, ErrorMessage = "The {0} needs to be at least {2} and under {1} characters long.", MinimumLength = 1)]
        public string ClientSurname { get; set; }

        [Required, Display(Name = "Email"), DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address.")]
        public string ClientEmail { get; set; }

        [Required, Display(Name = "Telephone"), DataType(DataType.PhoneNumber, ErrorMessage = "Please enter a correct phone number.")]
        [RegularExpression(@"^\+[0-9]{3}\s[0-9]{3}\s[0-9]{3}\s[0-9]{3}$", ErrorMessage = "Your {0} number needs to be in +XXX XXX XXX XXX format!")]
        public string ClientPhone { get; set; }

        [StringLength(maximumLength:500, ErrorMessage = "Your notes are too long.")]
        public string Notes { get; set; }
    }
}

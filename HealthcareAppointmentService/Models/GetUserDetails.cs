using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointmentServices.Models
{
    public class UserDetails
    {
        public UserDetails() { }

        //[Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public required string Name { get; set; }

        //[Required(ErrorMessage = "Email is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public required string Email { get; set; }

    }

    public class UserDetailsWithId : UserDetails
    {
        public long UserId { get; set; }
    }
}

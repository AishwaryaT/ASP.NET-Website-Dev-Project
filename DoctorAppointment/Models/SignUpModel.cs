using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorAppointment.Models
{
    public class SignUpModel
    {
        public string MessageString{get;set;}
        [Display (Name = "SSN")]
        public string ssn { get; set; }
        [Required]
        public string PatientFirstName { get; set; }
        [Required]
        public string PatientLastName { get; set; }
        [Required]
        [Key]
        public string UserName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string primaryinsurance { get; set; }
        public string phoneNo { get; set; }        
        public string Command { get; set; }
    }
}
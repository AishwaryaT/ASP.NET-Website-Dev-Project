using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace DoctorAppointment.Models
{
    public class LoginModel
    {
       
       
        [Display(Name = "User Name")]
        public string UserName { get; set; }
       
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string LoginMessage { get; set; }
        public string Command { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flent_Validation.Models
{
    public class Employee
    {
        public string? Name { get; set; }
        public DateTime DOB { get; set; }
        public string? Mail_ID { get; set; }

        public string? Password { get; set; }
        public string? Confirm_Passord
        {
            get; set;
        }
    }
}

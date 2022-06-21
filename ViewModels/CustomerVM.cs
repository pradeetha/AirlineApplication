using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineApplication.ViewModels
{
    public class CustomerVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public CustomerVM(string firstName, string lastName, string phone, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
        }
    }
}
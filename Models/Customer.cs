using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineApp.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public ICollection<Booking> Bookings { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineApp.Models
{
    public class FlightClass
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public string Description{ get; set; }
        public Flight Flight { get; set; }
        public Guid FlightId { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
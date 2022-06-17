using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineApp.Models
{
    public class FlightSchedule
    {
        public Guid Id { get; set; }
        public DateTime DepartureAt { get; set; }
        public DateTime ArriveAt { get; set; }
        public Airport ArrivalAirport { get; set; }
        public Guid ArrivalAirportId { get; set; }
        public Airport DepartureAirport { get; set; }
        public Guid DepartureAirportId { get; set; }
        public Flight Flight { get; set; }
        public Guid FlightId { get; set; }


        public ICollection<Booking> Bookings { get; set; }

    }
}
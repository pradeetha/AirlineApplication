using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineApp.Models
{
    public class Airport
    {
        public Guid Id { get; set; }       
        public string Name { get; set; } 
        public string Country { get; set; }

        public ICollection<FlightSchedule> ArrivalAirport { get; set; }
        public ICollection<FlightSchedule> DepartureAirport { get; set; }

    }
}
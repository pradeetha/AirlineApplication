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

        FlightClass()
        {
            Id = Guid.NewGuid();
        }

        public FlightClass (Guid id, string name, decimal price, string description, Guid flightId)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;          
            FlightId = flightId;           
        }   
    }
}
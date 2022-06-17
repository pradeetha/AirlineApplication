using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineApp.Models
{
     public enum Status { 
     Active,
     Storage,
     UnderRepair
    }
    public class Flight
    {
        public Guid Id { get; set; } 
        public string TailId { get; set; }
        public string Model { get; set; }  
        public Status?  Status { get; set; }

        public ICollection<FlightClass> FlightClass { get; set; }
        public ICollection<FlightSchedule> FlightSchedule { get; set; }


    }
}
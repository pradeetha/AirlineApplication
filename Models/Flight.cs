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
    public partial class Flight
    {
        public Guid Id { get; set; } 
        public string TailId { get; set; }
        public string Model { get; set; }  
        public Status  Status { get; set; }

        public ICollection<FlightClass> FlightClass { get; set; }
        public ICollection<FlightSchedule> FlightSchedule { get; set; }

        public Flight()
        {
            Id = Guid.NewGuid();
        }

        public Flight(Guid id, string tailId, string model, Status status)
        {
            Id = id;
            TailId = tailId;
            Model = model;
            Status = status;
        }
    }
}
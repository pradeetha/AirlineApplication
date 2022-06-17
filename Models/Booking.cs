﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineApp.Models
{
    public class Booking
    {
        public Guid Id { get; set; }

        public Guid FlightClassId { get; set; }
        public FlightClass FlightClass { get; set; }

        public Guid FlightScheduleId { get; set; }
        public FlightSchedule FlightSchedule { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
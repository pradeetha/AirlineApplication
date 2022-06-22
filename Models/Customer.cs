using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AirlineApp.Models
{
    public class Customer
    {
        
        public Guid Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [Phone]
        public string Phone { get; set; }

        [Required(ErrorMessage ="Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        public Customer()
        {
            Id = Guid.NewGuid();
        }

        public Customer(Guid id, string firstName, string lastName, string phone, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
        }

       

    }
}
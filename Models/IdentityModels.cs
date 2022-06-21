using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using AirlineApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AirlineApplication.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Airport> Airport { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<FlightClass> FlightClass { get; set; }
        public DbSet<FlightSchedule> FlightSchedule { get; set; }



        public ApplicationDbContext()
            : base("AirlineConnectionString", throwIfV1Schema: false)
        {
            Database.SetInitializer<ApplicationDbContext>(null);
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Customer Entity relationships
            modelBuilder.Entity<Customer>().HasKey(x => x.Id);

            modelBuilder.Entity<Customer>()
                .HasMany(x => x.Bookings)
                .WithRequired(x => x.Customer)
                .HasForeignKey(x => x.CustomerId)
                .WillCascadeOnDelete(true);
            ;
            //Airport Entity realtionships
            modelBuilder.Entity<Airport>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Airport>()
                .HasMany(e => e.ArrivalAirport)
                .WithRequired(e => e.ArrivalAirport)
                .HasForeignKey(e => e.ArrivalAirportId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Airport>()
                .HasMany(e => e.DepartureAirport)
                .WithRequired(e => e.DepartureAirport)
                .HasForeignKey(e => e.DepartureAirportId)
                .WillCascadeOnDelete(false);

            //Booking Entity relationships
            modelBuilder.Entity<Booking>().HasKey(x => x.Id);

            //FlightSchedule Entity relationships
            modelBuilder.Entity<FlightSchedule>().HasKey(x => x.Id);

            modelBuilder.Entity<FlightSchedule>()
                 .HasMany(e => e.Bookings)
                 .WithRequired(x => x.FlightSchedule)
                 .HasForeignKey(e => e.FlightScheduleId)
                 .WillCascadeOnDelete(false);

            //FlightClass Entity relationships
            modelBuilder.Entity<FlightClass>().HasKey(x => x.Id);

            modelBuilder.Entity<FlightClass>()
                 .HasMany(e => e.Bookings)
                 .WithRequired(x => x.FlightClass)
                 .HasForeignKey(e => e.FlightClassId);

            //Flight Entity relationships
            modelBuilder.Entity<Flight>().HasKey(x => x.Id);

            modelBuilder.Entity<Flight>()
                .HasMany(e => e.FlightClass)
                .WithRequired(e => e.Flight)
                .HasForeignKey(e => e.FlightId);

            modelBuilder.Entity<Flight>()
                .HasMany(e => e.FlightSchedule)
                .WithRequired(e => e.Flight)
                .HasForeignKey(e => e.FlightId)
                .WillCascadeOnDelete(false);

            //storage precedure
            modelBuilder.Entity<Customer>()
                .MapToStoredProcedures();
            modelBuilder.Entity<Airport>()
              .MapToStoredProcedures();
            modelBuilder.Entity<Flight>()
                .MapToStoredProcedures();
            modelBuilder.Entity<FlightSchedule>()
                .MapToStoredProcedures();
            modelBuilder.Entity<FlightClass>()
              .MapToStoredProcedures();
            modelBuilder.Entity<Booking>()
            .MapToStoredProcedures();

        }
    }
}
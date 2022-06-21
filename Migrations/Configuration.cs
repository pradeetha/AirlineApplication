namespace AirlineApplication.Migrations
{
    using AirlineApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Globalization;

    internal sealed class Configuration : DbMigrationsConfiguration<AirlineApplication.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AirlineApplication.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
           
            //seeding Data to Airport table
            
            context.Airport.AddOrUpdate(
                new Airport ( Guid.Parse("E2ED2632-8F70-44FD-A04A-16FB6794B023"), "CMB", "SL" ),
                new Airport(Guid.Parse("16970552-4DD4-4657-8506-52E1190BA71A"), "AUH", "UAE"),
                new Airport(Guid.Parse("9DA8DCAC-4C8D-443E-B388-56E16CFCCF55"), "LAX", "USA"),
                new Airport(Guid.Parse("3A95CB05-1030-4295-8395-7F50A909F6ED"), "RUH", "KSA"),
                new Airport(Guid.Parse("9445DC71-7BAB-4622-A42C-CB9CC870BE9B"), "JFK", "USA")
                );

            //Seeding Data to Customer Table
            context.Customer.AddOrUpdate(
                new Customer( Guid.Parse("CF76CC11-216A-4043-9615-1470D7CD4273"), "Irushi", "Dhamasiri", "(+91) 521 495 901", "irushi@gmail.com"),
                new Customer(Guid.Parse("B7E4D47C-DD0E-4DB7-9E03-23A5E3AE4BE8"), "Pradeetha", "Waragoda", "(+94) 713 915 978", "pradeetha@gmail.com"),
                new Customer(Guid.Parse("EA9CFD9B-7D03-4DD9-AE1D-4E0B1B523F6D"), "Rakitha", "Nonis", "(+94) 715 445 858", "rakitha@gmail.com"),
                new Customer(Guid.Parse("D4BBC68D-CCEF-41D4-9672-9872F380C9BC"), "Jiffrey", "Shelby", "(+97) 515 716 886", "Shelby@gmail.com"),
                new Customer(Guid.Parse("6FE35CF9-F8F6-4270-A995-BC37675C6D86"), "Anjalika", "De Sliva", "(+96) 525 225 886", "anjalika@gmail.com"),
                new Customer(Guid.Parse("7A678E2D-F13D-4F9B-BA41-CFBCBCB15F10"), "Wishva", "Peiris", "(+94) 765 565 076", "wishva@gmail.com"),
                new Customer(Guid.Parse("6E66335A-2D39-4B11-A60C-E01CE0D79AB4"), "Ravindu", "Fernando", "(+94) 764 115 771", "ravindu@gmail.com")
                );

            //Seeding Data to Flight
            context.Flight.AddOrUpdate(
                new Flight( Guid.Parse("F07A5416-DAFF-4348-ABF6-000FD88868DE"), "FA1152", "Airbus a300", Status.Storage),
                new Flight(Guid.Parse("C0402A0C-B2CA-45CF-BB75-02CEF0A0BEE1"), "FA1154", "Airbus a303", Status.Active),
                new Flight(Guid.Parse("181A61F6-E5DF-4C8B-BBF7-03AE32B85265"), "FA1278", "Boeing 747", Status.Active),
                new Flight(Guid.Parse("855B3475-BDA2-4617-93C7-3329DDC45030"), "FD3159", "Airbus a400", Status.Storage),
                new Flight(Guid.Parse("7E54168F-8EE2-423F-B642-515CD4F875A6"), "FA5152", "Boeing 747", Status.UnderRepair),
                new Flight(Guid.Parse("3FA0E68D-D413-4FAC-8B7B-98A307C045A3"), "FS0954", "Airbus a300", Status.Active),
                new Flight(Guid.Parse("E938FCE2-A230-403D-AED7-F64713B7F6DD"), "FC4566", "Airbus 505", Status.Active),
                new Flight(Guid.Parse("9CC5648B-EAFB-45EC-A376-F833F7E323A1"), "FA3122", "Boeing 747", Status.Storage)
                );


            const string dateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            CultureInfo provider = CultureInfo.InvariantCulture;
            //seeding Data to FlightSchedule
            context.FlightSchedule.AddOrUpdate(
                new FlightSchedule(Guid.Parse("66CC37D2-296B-4617-8BF1-0496EABC1695"), 
                DateTime.ParseExact("2022-06-17 11:00:00",dateTimeFormat, provider),
                DateTime.ParseExact("2022-06-17 22:30:00", dateTimeFormat, provider),
                Guid.Parse("E2ED2632-8F70-44FD-A04A-16FB6794B023"),
                Guid.Parse("16970552-4DD4-4657-8506-52E1190BA71A"),
                Guid.Parse("C0402A0C-B2CA-45CF-BB75-02CEF0A0BEE1")),

                new FlightSchedule(Guid.Parse("642CEF1A-FCED-4D22-9010-130EDF07318E"),
                DateTime.ParseExact("2022-06-17 01:30:00", dateTimeFormat, provider),
                DateTime.ParseExact("2022-06-17 02:30:00", dateTimeFormat, provider),
                Guid.Parse("9DA8DCAC-4C8D-443E-B388-56E16CFCCF55"),
                Guid.Parse("3A95CB05-1030-4295-8395-7F50A909F6ED"),
                Guid.Parse("C0402A0C-B2CA-45CF-BB75-02CEF0A0BEE1")),

                new FlightSchedule(Guid.Parse("79A6C59B-8521-415E-B8C0-16445615A422"),
                DateTime.ParseExact("2022-06-17 01:30:00", dateTimeFormat, provider),
                DateTime.ParseExact("2022-06-17 02:30:00", dateTimeFormat, provider),
                Guid.Parse("16970552-4DD4-4657-8506-52E1190BA71A"),
                Guid.Parse("3A95CB05-1030-4295-8395-7F50A909F6ED"),
                Guid.Parse("E938FCE2-A230-403D-AED7-F64713B7F6DD")),

                new FlightSchedule(Guid.Parse("F46185E0-78EC-4F6F-A230-78BD7A037212"),
                DateTime.ParseExact("2022-06-16 11:30:00", dateTimeFormat, provider),
                DateTime.ParseExact("2022-06-16 23:30:00", dateTimeFormat, provider),
                Guid.Parse("3A95CB05-1030-4295-8395-7F50A909F6ED"),
                Guid.Parse("E2ED2632-8F70-44FD-A04A-16FB6794B023"),
                Guid.Parse("EE938FCE2-A230-403D-AED7-F64713B7F6DD")),

                new FlightSchedule(Guid.Parse("8E0D1C8F-9113-4ECD-823C-BE669B501F4E"),
                DateTime.ParseExact("2022-06-17 01:30:00", dateTimeFormat, provider),
                DateTime.ParseExact("2022-06-17 12:30:00", dateTimeFormat, provider),
                Guid.Parse("3A95CB05-1030-4295-8395-7F50A909F6ED"),
                Guid.Parse("9DA8DCAC-4C8D-443E-B388-56E16CFCCF55"),
                Guid.Parse("181A61F6-E5DF-4C8B-BBF7-03AE32B85265")),

                new FlightSchedule(Guid.Parse("1E53DC12-1C84-4499-B8E8-C15CE5979DE0"),
               DateTime.ParseExact("2022-06-17 05:30:00", dateTimeFormat, provider),
               DateTime.ParseExact("2022-06-17 10:30:00", dateTimeFormat, provider),
               Guid.Parse("16970552-4DD4-4657-8506-52E1190BA71A"),
               Guid.Parse("9DA8DCAC-4C8D-443E-B388-56E16CFCCF55"),
               Guid.Parse("C0402A0C-B2CA-45CF-BB75-02CEF0A0BEE1")),

                new FlightSchedule(Guid.Parse("3DF53407-2DA3-4F04-968F-CE5CEDA1A789"),
              DateTime.ParseExact("2022-06-16 11:30:00", dateTimeFormat, provider),
              DateTime.ParseExact("2022-06-16 23:30:00", dateTimeFormat, provider),
              Guid.Parse("9DA8DCAC-4C8D-443E-B388-56E16CFCCF55"),
              Guid.Parse("E2ED2632-8F70-44FD-A04A-16FB6794B023"),
              Guid.Parse("181A61F6-E5DF-4C8B-BBF7-03AE32B85265")),

                new FlightSchedule(Guid.Parse("BA4CA4CE-466D-4AAA-A02C-EC570F1E8C49"),
              DateTime.ParseExact("2022-06-17 01:00:00", dateTimeFormat, provider),
              DateTime.ParseExact("2022-06-17 02:30:00", dateTimeFormat, provider),
              Guid.Parse("16970552-4DD4-4657-8506-52E1190BA71A"),
              Guid.Parse("3A95CB05-1030-4295-8395-7F50A909F6ED"),
              Guid.Parse("181A61F6-E5DF-4C8B-BBF7-03AE32B85265"))
                );


            //Seeding FlightClass Data to Table
            context.FlightClass.AddOrUpdate(
                new FlightClass(Guid.Parse("66181FD8-A8E3-421B-A25B-02BA01D06C50"), "Economy Class", 167, null, Guid.Parse("E938FCE2-A230-403D-AED7-F64713B7F6DD")),

                new FlightClass(Guid.Parse("17CF2A89-8178-42C0-95DD-0A3BCF8856A8"), "Business Class", 246, null, Guid.Parse("E938FCE2-A230-403D-AED7-F64713B7F6DD")),

                new FlightClass(Guid.Parse("B4B84717-5A69-471F-91B1-14574E6DF298"), "Economy Class", 197, null, Guid.Parse("181A61F6-E5DF-4C8B-BBF7-03AE32B85265")),

                new FlightClass(Guid.Parse("A313492A-F897-4A8F-B858-1F51957DAC7E"), "Economy Class", 97, null, Guid.Parse("C0402A0C-B2CA-45CF-BB75-02CEF0A0BEE1")),

                new FlightClass(Guid.Parse("75CF00AA-0AA9-4A96-AAF9-5454EAF780DD"), "First Class", 151, null, Guid.Parse("C0402A0C-B2CA-45CF-BB75-02CEF0A0BEE1")),

                new FlightClass(Guid.Parse("251DCBC1-3D1E-45BF-842A-636511450F45"), "Business Class", 125, null, Guid.Parse("C0402A0C-B2CA-45CF-BB75-02CEF0A0BEE1")),

                new FlightClass(Guid.Parse("4117C4A0-077C-4726-9771-A57B92F96104"), "First Class", 351, null, Guid.Parse("181A61F6-E5DF-4C8B-BBF7-03AE32B85265")),

                new FlightClass(Guid.Parse("973A6768-A8AE-495E-A308-CB0C8ADDB3AC"), "First Class", 251, null, Guid.Parse("E938FCE2-A230-403D-AED7-F64713B7F6DD")),

                new FlightClass(Guid.Parse("0213ECF0-A7B3-469B-BBA4-E61B0BB0E5CB"), "Business Class", 325, null, Guid.Parse("181A61F6-E5DF-4C8B-BBF7-03AE32B85265"))
                );
            



            //Seeding Booking Data to Table 
            context.Booking.AddOrUpdate(
                new Booking(Guid.Parse("F386C66E-7E3B-4F0E-8BDA-136690FF03A3"), Guid.Parse("66181FD8-A8E3-421B-A25B-02BA01D06C50"), Guid.Parse("79A6C59B-8521-415E-B8C0-16445615A422"), Guid.Parse("EA9CFD9B-7D03-4DD9-AE1D-4E0B1B523F6D"), DateTime.ParseExact("2022-06-13 01:30:00", dateTimeFormat, provider)),

                new Booking(Guid.Parse("F4026A86-4A56-4A7F-A132-AF73045D807A"), Guid.Parse("66181FD8-A8E3-421B-A25B-02BA01D06C50"), Guid.Parse("79A6C59B-8521-415E-B8C0-16445615A422"), Guid.Parse("6E66335A-2D39-4B11-A60C-E01CE0D79AB4"), DateTime.ParseExact("2022-06-12 01:30:00", dateTimeFormat, provider)),

                new Booking(Guid.Parse("955C046B-529F-4104-88D4-ABA30E2F46A9"), Guid.Parse("66181FD8-A8E3-421B-A25B-02BA01D06C50"), Guid.Parse("79A6C59B-8521-415E-B8C0-16445615A422"), Guid.Parse("D4BBC68D-CCEF-41D4-9672-9872F380C9BC"), DateTime.ParseExact("2022-06-12 01:30:00", dateTimeFormat, provider)),

                new Booking(Guid.Parse("7F2B75D8-4AC7-45C0-A0D6-D9A0F9FBDD63"), Guid.Parse("66181FD8-A8E3-421B-A25B-02BA01D06C50"), Guid.Parse("79A6C59B-8521-415E-B8C0-16445615A422"), Guid.Parse("B7E4D47C-DD0E-4DB7-9E03-23A5E3AE4BE8"), DateTime.ParseExact("2022-06-14 01:30:00", dateTimeFormat, provider)),

                new Booking(Guid.Parse("5AFEC888-8CCF-432C-BEFF-F0038FB4212D"), Guid.Parse("66181FD8-A8E3-421B-A25B-02BA01D06C50"), Guid.Parse("79A6C59B-8521-415E-B8C0-16445615A422"), Guid.Parse("7A678E2D-F13D-4F9B-BA41-CFBCBCB15F10"), DateTime.ParseExact("2022-06-11 01:30:00", dateTimeFormat, provider)),

                new Booking(Guid.Parse("097C0699-C3E7-4D4D-AC73-F9E72BFFF8D8"), Guid.Parse("66181FD8-A8E3-421B-A25B-02BA01D06C50"), Guid.Parse("79A6C59B-8521-415E-B8C0-16445615A422"), Guid.Parse("52E19AAE-4598-417B-8010-EFFC1C3FE222"), DateTime.ParseExact("2022-06-14 01:30:00", dateTimeFormat, provider))
                );
            context.SaveChanges();

        }
    }
}

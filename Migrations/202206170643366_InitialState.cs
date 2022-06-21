namespace AirlineApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialState : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Airports",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FlightSchedules",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DepartureAt = c.DateTime(nullable: false),
                        ArriveAt = c.DateTime(nullable: false),
                        ArrivalAirportId = c.Guid(nullable: false),
                        DepartureAirportId = c.Guid(nullable: false),
                        FlightId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flights", t => t.FlightId)
                .ForeignKey("dbo.Airports", t => t.ArrivalAirportId)
                .ForeignKey("dbo.Airports", t => t.DepartureAirportId)
                .Index(t => t.ArrivalAirportId)
                .Index(t => t.DepartureAirportId)
                .Index(t => t.FlightId);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FlightClassId = c.Guid(nullable: false),
                        FlightScheduleId = c.Guid(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.FlightClasses", t => t.FlightClassId, cascadeDelete: true)
                .ForeignKey("dbo.FlightSchedules", t => t.FlightScheduleId)
                .Index(t => t.FlightClassId)
                .Index(t => t.FlightScheduleId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FlightClasses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        FlightId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flights", t => t.FlightId, cascadeDelete: true)
                .Index(t => t.FlightId);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TailId = c.String(),
                        Model = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateStoredProcedure(
                "dbo.Airport_Insert",
                p => new
                    {
                        Id = p.Guid(),
                        Name = p.String(),
                        Country = p.String(),
                    },
                body:
                    @"INSERT [dbo].[Airports]([Id], [Name], [Country])
                      VALUES (@Id, @Name, @Country)"
            );
            
            CreateStoredProcedure(
                "dbo.Airport_Update",
                p => new
                    {
                        Id = p.Guid(),
                        Name = p.String(),
                        Country = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[Airports]
                      SET [Name] = @Name, [Country] = @Country
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Airport_Delete",
                p => new
                    {
                        Id = p.Guid(),
                    },
                body:
                    @"DELETE [dbo].[Airports]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.FlightSchedule_Insert",
                p => new
                    {
                        Id = p.Guid(),
                        DepartureAt = p.DateTime(),
                        ArriveAt = p.DateTime(),
                        ArrivalAirportId = p.Guid(),
                        DepartureAirportId = p.Guid(),
                        FlightId = p.Guid(),
                    },
                body:
                    @"INSERT [dbo].[FlightSchedules]([Id], [DepartureAt], [ArriveAt], [ArrivalAirportId], [DepartureAirportId], [FlightId])
                      VALUES (@Id, @DepartureAt, @ArriveAt, @ArrivalAirportId, @DepartureAirportId, @FlightId)"
            );
            
            CreateStoredProcedure(
                "dbo.FlightSchedule_Update",
                p => new
                    {
                        Id = p.Guid(),
                        DepartureAt = p.DateTime(),
                        ArriveAt = p.DateTime(),
                        ArrivalAirportId = p.Guid(),
                        DepartureAirportId = p.Guid(),
                        FlightId = p.Guid(),
                    },
                body:
                    @"UPDATE [dbo].[FlightSchedules]
                      SET [DepartureAt] = @DepartureAt, [ArriveAt] = @ArriveAt, [ArrivalAirportId] = @ArrivalAirportId, [DepartureAirportId] = @DepartureAirportId, [FlightId] = @FlightId
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.FlightSchedule_Delete",
                p => new
                    {
                        Id = p.Guid(),
                    },
                body:
                    @"DELETE [dbo].[FlightSchedules]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Booking_Insert",
                p => new
                    {
                        Id = p.Guid(),
                        FlightClassId = p.Guid(),
                        FlightScheduleId = p.Guid(),
                        CustomerId = p.Guid(),
                        CreatedAt = p.DateTime(),
                    },
                body:
                    @"INSERT [dbo].[Bookings]([Id], [FlightClassId], [FlightScheduleId], [CustomerId], [CreatedAt])
                      VALUES (@Id, @FlightClassId, @FlightScheduleId, @CustomerId, @CreatedAt)"
            );
            
            CreateStoredProcedure(
                "dbo.Booking_Update",
                p => new
                    {
                        Id = p.Guid(),
                        FlightClassId = p.Guid(),
                        FlightScheduleId = p.Guid(),
                        CustomerId = p.Guid(),
                        CreatedAt = p.DateTime(),
                    },
                body:
                    @"UPDATE [dbo].[Bookings]
                      SET [FlightClassId] = @FlightClassId, [FlightScheduleId] = @FlightScheduleId, [CustomerId] = @CustomerId, [CreatedAt] = @CreatedAt
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Booking_Delete",
                p => new
                    {
                        Id = p.Guid(),
                    },
                body:
                    @"DELETE [dbo].[Bookings]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Customer_Insert",
                p => new
                    {
                        Id = p.Guid(),
                        FirstName = p.String(),
                        LastName = p.String(),
                        Phone = p.String(),
                        Email = p.String(),
                    },
                body:
                    @"INSERT [dbo].[Customers]([Id], [FirstName], [LastName], [Phone], [Email])
                      VALUES (@Id, @FirstName, @LastName, @Phone, @Email)"
            );
            
            CreateStoredProcedure(
                "dbo.Customer_Update",
                p => new
                    {
                        Id = p.Guid(),
                        FirstName = p.String(),
                        LastName = p.String(),
                        Phone = p.String(),
                        Email = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[Customers]
                      SET [FirstName] = @FirstName, [LastName] = @LastName, [Phone] = @Phone, [Email] = @Email
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Customer_Delete",
                p => new
                    {
                        Id = p.Guid(),
                    },
                body:
                    @"DELETE [dbo].[Customers]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.FlightClass_Insert",
                p => new
                    {
                        Id = p.Guid(),
                        Name = p.String(),
                        Price = p.Decimal(precision: 18, scale: 2),
                        Description = p.String(),
                        FlightId = p.Guid(),
                    },
                body:
                    @"INSERT [dbo].[FlightClasses]([Id], [Name], [Price], [Description], [FlightId])
                      VALUES (@Id, @Name, @Price, @Description, @FlightId)"
            );
            
            CreateStoredProcedure(
                "dbo.FlightClass_Update",
                p => new
                    {
                        Id = p.Guid(),
                        Name = p.String(),
                        Price = p.Decimal(precision: 18, scale: 2),
                        Description = p.String(),
                        FlightId = p.Guid(),
                    },
                body:
                    @"UPDATE [dbo].[FlightClasses]
                      SET [Name] = @Name, [Price] = @Price, [Description] = @Description, [FlightId] = @FlightId
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.FlightClass_Delete",
                p => new
                    {
                        Id = p.Guid(),
                    },
                body:
                    @"DELETE [dbo].[FlightClasses]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Flight_Insert",
                p => new
                    {
                        Id = p.Guid(),
                        TailId = p.String(),
                        Model = p.String(),
                        Status = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Flights]([Id], [TailId], [Model], [Status])
                      VALUES (@Id, @TailId, @Model, @Status)"
            );
            
            CreateStoredProcedure(
                "dbo.Flight_Update",
                p => new
                    {
                        Id = p.Guid(),
                        TailId = p.String(),
                        Model = p.String(),
                        Status = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Flights]
                      SET [TailId] = @TailId, [Model] = @Model, [Status] = @Status
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Flight_Delete",
                p => new
                    {
                        Id = p.Guid(),
                    },
                body:
                    @"DELETE [dbo].[Flights]
                      WHERE ([Id] = @Id)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Flight_Delete");
            DropStoredProcedure("dbo.Flight_Update");
            DropStoredProcedure("dbo.Flight_Insert");
            DropStoredProcedure("dbo.FlightClass_Delete");
            DropStoredProcedure("dbo.FlightClass_Update");
            DropStoredProcedure("dbo.FlightClass_Insert");
            DropStoredProcedure("dbo.Customer_Delete");
            DropStoredProcedure("dbo.Customer_Update");
            DropStoredProcedure("dbo.Customer_Insert");
            DropStoredProcedure("dbo.Booking_Delete");
            DropStoredProcedure("dbo.Booking_Update");
            DropStoredProcedure("dbo.Booking_Insert");
            DropStoredProcedure("dbo.FlightSchedule_Delete");
            DropStoredProcedure("dbo.FlightSchedule_Update");
            DropStoredProcedure("dbo.FlightSchedule_Insert");
            DropStoredProcedure("dbo.Airport_Delete");
            DropStoredProcedure("dbo.Airport_Update");
            DropStoredProcedure("dbo.Airport_Insert");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.FlightSchedules", "DepartureAirportId", "dbo.Airports");
            DropForeignKey("dbo.FlightSchedules", "ArrivalAirportId", "dbo.Airports");
            DropForeignKey("dbo.Bookings", "FlightScheduleId", "dbo.FlightSchedules");
            DropForeignKey("dbo.FlightSchedules", "FlightId", "dbo.Flights");
            DropForeignKey("dbo.FlightClasses", "FlightId", "dbo.Flights");
            DropForeignKey("dbo.Bookings", "FlightClassId", "dbo.FlightClasses");
            DropForeignKey("dbo.Bookings", "CustomerId", "dbo.Customers");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.FlightClasses", new[] { "FlightId" });
            DropIndex("dbo.Bookings", new[] { "CustomerId" });
            DropIndex("dbo.Bookings", new[] { "FlightScheduleId" });
            DropIndex("dbo.Bookings", new[] { "FlightClassId" });
            DropIndex("dbo.FlightSchedules", new[] { "FlightId" });
            DropIndex("dbo.FlightSchedules", new[] { "DepartureAirportId" });
            DropIndex("dbo.FlightSchedules", new[] { "ArrivalAirportId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Flights");
            DropTable("dbo.FlightClasses");
            DropTable("dbo.Customers");
            DropTable("dbo.Bookings");
            DropTable("dbo.FlightSchedules");
            DropTable("dbo.Airports");
        }
    }
}

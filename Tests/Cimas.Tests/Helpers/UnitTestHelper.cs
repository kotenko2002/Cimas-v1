using Cimas.Entities.Cinemas;
using Cimas.Entities.Companies;
using Cimas.Entities.Films;
using Cimas.Entities.Halls;
using Cimas.Entities.Products;
using Cimas.Entities.Reports;
using Cimas.Entities.Sessions;
using Cimas.Entities.Users;
using Cimas.Entities.WorkDays;
using Cimas.Storage.Configuration;
using Cimas.Сommon.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Cimas.Tests.Helpers
{
    public class UnitTestHelper
    {
        public static DbContextOptions<CimasDbContext> GetCimasDbOptions()
        {
            var options = new DbContextOptionsBuilder<CimasDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;

            using (var context = new CimasDbContext(options))
            {
                SeedData(context);
            }

            return options;
        }

        public static void SeedData(CimasDbContext context)
        {
            context.Company.AddRange(Companies);
            context.Cinema.AddRange(Cinemas);
            context.Film.AddRange(Films);
            context.Hall.AddRange(Halls);
            context.HallSeat.AddRange(HallSeats);
            context.Session.AddRange(Sessions);
            context.SessionSeat.AddRange(SessionSeats);
            context.User.AddRange(Users);
            context.WorkDay.AddRange(WorkDays);
            context.Product.AddRange(Products);
            context.Report.AddRange(Reports);

            context.SaveChanges();
        }

        #region Data
        public static List<Company> Companies = new()
        {
            new Company() { Id = 1, Name = "World of Films" }
        };

        public static List<Cinema> Cinemas = new()
        {
            new Cinema() { Id = 1, CompanyId = 1, Name = "Central cinema", Adress="Romny city, Shevchenko street" }
        };

        public static List<Film> Films = new()
        {
            new Film() { Id = 1, CompanyId = 1, Name = "Avatar", Duration = 210 },
            new Film() { Id = 4, CompanyId = 1, Name = "Avatar 2", Duration = 225 }
        };

        public static List<Hall> Halls = new()
        {
            new Hall() { Id = 1, CinemaId = 1, Name = "Big hall" },
            new Hall() { Id = 2, CinemaId = 1, Name = "Small hall" }
        };

        public static List<HallSeat> HallSeats = new()
        {
            new HallSeat() { Id = 1, HallId = 1, Row = 0, Column = 0 },
            new HallSeat() { Id = 2, HallId = 1, Row = 0, Column = 1 },
            new HallSeat() { Id = 3, HallId = 1, Row = 0, Column = 2 },
            new HallSeat() { Id = 4, HallId = 1, Row = 1, Column = 0 },
            new HallSeat() { Id = 5, HallId = 1, Row = 1, Column = 1 },
            new HallSeat() { Id = 6, HallId = 1, Row = 1, Column = 2 },
            new HallSeat() { Id = 7, HallId = 2, Row = 0, Column = 0 },
            new HallSeat() { Id = 8, HallId = 2, Row = 0, Column = 1 },
            new HallSeat() { Id = 9, HallId = 2, Row = 0, Column = 2 }
        };

        public static List<Session> Sessions = new()
        {
             new Session() { Id = 1, HallId = 1, FilmId = 1, TicketPrice = 100,
                StartDateTime = DateTime.Now, EndDateTime = DateTime.Now.AddMinutes(210) },
             new Session() { Id = 2, HallId = 2, FilmId = 2, TicketPrice = 110,
                StartDateTime = DateTime.Now.AddMinutes(210), EndDateTime = DateTime.Now.AddMinutes(210 + 225) },
             new Session() { Id = 3, HallId = 2, FilmId = 1, TicketPrice = 120,
                StartDateTime = DateTime.Now.AddMinutes(210 + 225), EndDateTime = DateTime.Now.AddMinutes(210 + 225 + 210) }
        };

        public static List<SessionSeat> SessionSeats = new()
        {
            new SessionSeat() { Id = 1, Status = SeatStatus.Free, Row = 0, Column = 0, DateTime = null },
            new SessionSeat() { Id = 2, Status = SeatStatus.Free, Row = 0, Column = 1, DateTime = null },
            new SessionSeat() { Id = 3, Status = SeatStatus.Free, Row = 0, Column = 2, DateTime = null },
            new SessionSeat() { Id = 4, Status = SeatStatus.Occupied, Row = 1, Column = 0, DateTime = DateTime.Now.AddDays(-5).AddHours(2) },
            new SessionSeat() { Id = 5, Status = SeatStatus.Free, Row = 1, Column = 1, DateTime = null },
            new SessionSeat() { Id = 6, Status = SeatStatus.Occupied, Row = 1, Column = 2, DateTime = DateTime.Now.AddDays(-5).AddHours(2) },

            new SessionSeat() { Id = 7, Status = SeatStatus.Occupied, Row = 0, Column = 0, DateTime = DateTime.Now.AddDays(-5).AddHours(1) },
            new SessionSeat() { Id = 8, Status = SeatStatus.Occupied, Row = 0, Column = 1, DateTime = DateTime.Now.AddDays(-5).AddHours(1) },
            new SessionSeat() { Id = 9, Status = SeatStatus.Free, Row = 0, Column = 2, DateTime = null },
            new SessionSeat() { Id = 10, Status = SeatStatus.Free, Row = 1, Column = 0, DateTime = null },
            new SessionSeat() { Id = 11, Status = SeatStatus.Free, Row = 1, Column = 1, DateTime = null },
            new SessionSeat() { Id = 12, Status = SeatStatus.Occupied, Row = 1, Column = 2, DateTime = DateTime.Now.AddHours(1) },

            new SessionSeat() { Id = 13, Status = SeatStatus.Occupied, Row = 0, Column = 0, DateTime = DateTime.Now.AddHours(2) },
            new SessionSeat() { Id = 14, Status = SeatStatus.Occupied, Row = 0, Column = 1, DateTime = DateTime.Now.AddHours(2) },
            new SessionSeat() { Id = 15, Status = SeatStatus.Free, Row = 0, Column = 2, DateTime = null }
        };

        public static List<User> Users = new()
        {
            new User() { Id = 1, CompanyId = 1, Name = "Maria", Role = Role.CompanyAdmin, Login = "testlogin3",
                PasswordHash = "lf8AS8WAJNJlNpKx2EBS4IbmH7cWbyT7qE/RBhaA3x1i7kfMl2NqiFLLV/0kdYDSObXVOGtwyLhfgWWF568meA==",
                PasswordSalt = "Luae2nSXo5aE8/0ZRLl6DQ1gVkY0CTSKkIh6gG29CrWNlPA8CTeiOKKyLCaqarTVgE//LwDbRJ/NHa9OKvQC05bXzBuptbobuHfLmo0wHbUALjk06VyURv3c+lyWQgZXSHR4/GtHPkYDIG9C6A8hZ0QPKSvTNoov7HmJCW7bFyQ=",
                IsFired = false
            },
            new User() { Id = 2, CompanyId = 1, Name = "Max", Role = Role.Reviewer, Login = "testlogin2",
                PasswordHash = "icYIavNKMY8sU7BIesT2mesSR9HpMEpD5jRjtlxBEKRlmIxOgCiCbFomdvas4Vxar72WBjWkGCpY2pfKhBJzBg==",
                PasswordSalt = "ng+V4Ait9Wc66gG6ePPkwmxRKAfvCIYexXNL1CskPkixpVpmw1TG4U89Hs9iRWag5+5KZztfy4aPSpsBWNMwfCsuXIIYbTEnyTbSaXZpKT0QVHz2aRtA+QEvFm00niGDOiJe96QNsCPz9opd1wr+Ff6wK9zXtvMYKckbmzjWfRI=",
                IsFired = false
            },
            new User() { Id = 3, CompanyId = 1, Name = "Vika", Role = Role.Worker, Login = "testlogin1",
                PasswordHash = "ZoGEMvIHf2nK5UZQOPeBmhhtTIMYl73C2dIyoRIe1+n/2ZBb7iSd9ZdO5Bk5aBCeSyG7k57Kadyz3GZLOLV+wA==",
                PasswordSalt = "hhCvqc7b/0OwAxRV0dvU36La5w9zcjbilLOTpDd4Sq2olV+njLxnZXL21aMmVkuiN8G6/rbAd250mLjcJGkOFfmKss0F6XqOo4jAIor73GY86VgOyA1LJ0c4ezQ6sf9YMN4jGSnIvC4QajxTqMKprmwgf3Qnoxq/KjvENwMEEZ0=",
                IsFired = false
            }
        };

        public static List<WorkDay> WorkDays = new()
        {
             new WorkDay() { Id = 1, UserId = 3, CinemaId = 1, StartDateTime = DateTime.Now.AddDays(-5), EndDateTime = DateTime.Now.AddDays(-5).AddHours(8)},
             new WorkDay() { Id = 2, UserId = 3, CinemaId = 1, StartDateTime = DateTime.Now, EndDateTime = DateTime.Now.AddHours(8)}
        };

        public static List<Product> Products = new()
        {
             new Product() { Id = 1, WorkDayId = 1, Name = "Coke", Price = 15, Amount = 0, Incoming = 5, SoldAmount = 2 },
             new Product() { Id = 2, WorkDayId = 1, Name = "Chips", Price = 30, Amount = 0, Incoming = 15, SoldAmount = 5 },
             new Product() { Id = 3, WorkDayId = 2, Name = "Coke", Price = 15, Amount = 3, Incoming = 0, SoldAmount = 1 },
             new Product() { Id = 4, WorkDayId = 2, Name = "Chips", Price = 30, Amount = 10, Incoming = 0, SoldAmount = 1 }
        };

        public static List<Report> Reports = new()
        {
            new Report() { Id = 1, WorkDayId = 1, Status = RepostStatus.NotReviewed },
            new Report() { Id = 2, WorkDayId = 2, Status = RepostStatus.NotReviewed }
        };
        #endregion
    }
}

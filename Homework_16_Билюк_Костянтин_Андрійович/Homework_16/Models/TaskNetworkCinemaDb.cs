using Homework_16.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_16.Models
{
    public class TasksNetworkCinemaDb
    {
        public List<Showtime> AllShowtimesCurrentWeak()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Showtimes.ToList().Join(db.Movies, s => s.MovieId, m => m.Id, (s, m) => new Showtime { Id = s.Id, Movie = m, MovieId = m.Id, WhenShowtime = s.WhenShowtime })
                    .Where(p => p.WhenShowtime >= DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek) + 1) &&
                    p.WhenShowtime < DateTime.Today.AddDays(1 * (int)(DateTime.Today.DayOfWeek) + 2)).ToList();
            }
        }

        public List<HallPosition> NonBookedSeats()
        {
            using (var db = new ApplicationDbContext())
            {
                var list = db.HallPositions.Select(p =>
                    new HallPosition { Id = p.Id, Hall = p.Hall, HallId = p.HallId, PlaceNumber = p.PlaceNumber });
                var realList2 = db.Bookings.Select(p =>
                    new HallPosition { Id = p.HallPositionId, Hall = p.HallPosition.Hall, HallId = p.HallPosition.HallId, PlaceNumber = p.HallPosition.PlaceNumber });
                return list.Except(realList2).ToList();
            }
        }

        public IEnumerable<dynamic> AllMoneyEarnedByEachMovie()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Bookings
                    .GroupBy(f => f.Showtime.Movie.Name)
                    .Select(x => new { AllPrice = x.Sum(b => b.Price), MovieName = x.Key })
                    .OrderByDescending(p => p.AllPrice)
                    .ToList<dynamic>();
            }
        }

        public IEnumerable<dynamic> Top3UsersWhoSpentMostMoneyInTheSpecifiedDates(DateTime first, DateTime last)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Bookings
                    .Where(p => p.Showtime.WhenShowtime >= first && last >= p.Showtime.WhenShowtime)
                    .GroupBy(p => p.User)
                    .Select(p => new { Money = p.Sum(x => x.Price), User = $"{p.Key.FirstName} {p.Key.LastName}" })
                    .OrderByDescending(p => p.Money).Take(3)
                    .ToList<dynamic>();
            }
        }

        public List<Cinema> NoActiveLastWeekCinemas()
        {
            using (var db = new ApplicationDbContext())
            {
                var lastWeek = db.Bookings
                    .Where(p => p.Showtime.WhenShowtime > DateTime.Now.AddDays(-7) && p.Showtime.WhenShowtime < DateTime.Now.AddDays(0))
                    .GroupBy(p => p.HallPosition.Hall.Cinema.Name)
                    .Select(p => new { Count = p.Count(), CinemaName = p.Key }).ToList();

                var penultimateWeek = db.Bookings
                    .Where(p => p.Showtime.WhenShowtime > DateTime.Now.AddDays(-14) && p.Showtime.WhenShowtime < DateTime.Now.AddDays(-7))
                    .GroupBy(p => p.HallPosition.Hall.Cinema.Name)
                    .Select(p => new { Count = p.Count(), CinemaName = p.Key }).ToList();

                var almostResult = (from l in lastWeek
                                    from p in penultimateWeek
                                    where l.Count < p.Count
                                    select l).ToList();

                if (almostResult.Count == 0)
                    return new List<Cinema>();

                return (from d in db.Cinemas
                        from r in almostResult
                        where d.Name == r.CinemaName
                        select d).ToList();
            }
        }
    }
}

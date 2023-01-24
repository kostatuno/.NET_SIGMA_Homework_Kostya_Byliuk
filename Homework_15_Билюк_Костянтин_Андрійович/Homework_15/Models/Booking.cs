using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_15.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int PlaceNumber { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public int ShowtimeId { get; set; }
        public Showtime? Showtime { get; set; }
    }
}

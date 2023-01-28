using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_16.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public decimal Price { get; set; }

        public int HallPositionId { get; set; }
        public HallPosition? HallPosition { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public int ShowtimeId { get; set; }
        public Showtime? Showtime { get; set; }

        public Booking()
        {
        }

        public Booking(decimal price, int hallPositionId, int userId, int showtimeId)
        {
            Price = price;
            HallPositionId = hallPositionId;
            UserId = userId;
            ShowtimeId = showtimeId;
        }
    }
}

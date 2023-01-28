using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_16.Models
{
    public class Showtime
    {
        public int Id { get; set; }
        public DateTime WhenShowtime { get; set; }

        public int MovieId { get; set; }
        public Movie? Movie { get; set; }

        public Showtime()
        {
        }

        public Showtime(DateTime whenShowtime, int movieId)
        {
            WhenShowtime = whenShowtime;
            MovieId = movieId;
        }


    }
}

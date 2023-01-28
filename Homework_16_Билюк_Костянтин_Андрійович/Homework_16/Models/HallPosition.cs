using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_16.Models
{
    public class HallPosition
    {
        public int Id { get; set; }
        public int PlaceNumber { get; set; }

        public int HallId { get; set; }
        public Hall? Hall { get; set; }

        public HallPosition()
        {
        }

        public HallPosition(int placeNumber, int hallId)
        {
            PlaceNumber = placeNumber;
            HallId = hallId;
        }
    }
}

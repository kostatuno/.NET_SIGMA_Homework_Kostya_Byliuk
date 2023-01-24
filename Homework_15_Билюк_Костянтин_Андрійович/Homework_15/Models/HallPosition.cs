using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_15.Models
{
    public class HallPosition
    {
        [Key]
        public int Id { get; set; }
        public int? PlaceNumber { get; set; }

        public int HallId { get; set; }
        public Hall? Hall { get; set; }
    }
}

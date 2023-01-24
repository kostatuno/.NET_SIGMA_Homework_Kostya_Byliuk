using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_15.Models
{
    public class Hall
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CinemaId { get; set; }
        public Cinema? Cinema { get; set; }

        public Hall()
        {
        }

        public Hall(string name, int cinemaId)
        {
            Name = name;
            CinemaId = cinemaId;
        }
    }
}

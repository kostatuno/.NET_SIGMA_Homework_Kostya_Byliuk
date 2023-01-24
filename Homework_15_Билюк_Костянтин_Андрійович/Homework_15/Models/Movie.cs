using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_15.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public Movie(int id, string? name)
        {
            Id = id;
            Name = name;
        }
    }
}

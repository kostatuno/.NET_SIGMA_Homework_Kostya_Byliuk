using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_15.Models
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string? FirstName { get; set; }
        [MaxLength(20)]
        public string? LastName { get; set; }
        [MaxLength(20)] 
        public string? PhoneNumber { get; set; }

        public User()
        {
        }

        public User(int id, string? firstName, string? lastName, string? phoneNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }
    }
}

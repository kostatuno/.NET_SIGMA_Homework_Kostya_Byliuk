using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_14
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string? PhoneNumber { get; set; }

        public User(int userId, string userName, string phoneNumber)
        {
            UserId = userId;
            UserName = userName;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"UserId = {UserId}, UserName = {UserName}, PhoneNumber = {PhoneNumber}";
        }

        public User()
        {
        }
    }
}

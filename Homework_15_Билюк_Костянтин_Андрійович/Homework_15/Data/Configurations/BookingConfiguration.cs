using Homework_15.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Homework_15.Data.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasData(new Booking(1, 6.65M, 12, 1, 2),
                new Booking(2, 6.99M, 19, 2, 2),
                new Booking(3, 4.99M, 10, 3, 3),
                new Booking(4, 8.99M, 18, 4, 4),
                new Booking(5, 7.99M, 17, 5, 2),
                new Booking(6, 3.99M, 11, 6, 2),
                new Booking(7, 2.99M, 9, 7, 5));   
        }
    }
}

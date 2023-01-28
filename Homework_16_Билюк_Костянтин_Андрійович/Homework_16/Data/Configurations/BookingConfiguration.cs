using Homework_16.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Homework_16.Data.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasData(new Booking(6.65M, 2, 7, 2) { Id = 1 },
                new Booking(6.99M, 1, 2, 2) { Id = 2 },
                new Booking(4.99M, 3, 3, 3) { Id = 3 },
                new Booking(8.99M, 9, 4, 4) { Id = 4 },
                new Booking(7.99M, 5, 5, 2) { Id = 5 },
                new Booking(3.99M, 7, 6, 2) { Id = 6 },
                new Booking(2.99M, 6, 7, 5) { Id = 7 });
        }
    }
}

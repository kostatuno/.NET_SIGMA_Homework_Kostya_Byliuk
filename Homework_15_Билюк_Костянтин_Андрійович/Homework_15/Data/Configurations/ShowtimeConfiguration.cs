using Homework_15.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_15.Data.Configurations
{
    public class ShowtimeConfiguration : IEntityTypeConfiguration<Showtime>
    {
        public void Configure(EntityTypeBuilder<Showtime> builder)
        {
            builder.HasData(new Showtime(1, new DateTime(2023, 01, 26, 14, 30, 0), 1),
                new Showtime(2, new DateTime(2023, 01, 26, 18, 30, 0), 3),
                new Showtime(3, new DateTime(2023, 01, 28, 12, 30, 0), 3),
                new Showtime(4, new DateTime(2023, 01, 29, 14, 30, 0), 2),
                new Showtime(5, new DateTime(2023, 01, 29, 16, 30, 0), 1),
                new Showtime(6, new DateTime(2023, 01, 30, 13, 30, 0), 4));
        }
    }
}

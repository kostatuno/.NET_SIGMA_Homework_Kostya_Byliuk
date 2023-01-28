using Homework_16.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_16.Data.Configurations
{
    public class ShowtimeConfiguration : IEntityTypeConfiguration<Showtime>
    {
        public void Configure(EntityTypeBuilder<Showtime> builder)
        {
            builder.HasData(new Showtime(new DateTime(2023, 01, 26, 14, 30, 0), 1) { Id = 1 },
                new Showtime(new DateTime(2023, 01, 26, 18, 30, 0), 3) { Id = 2 },
                new Showtime(new DateTime(2023, 01, 28, 12, 30, 0), 3) { Id = 3 },
                new Showtime(new DateTime(2023, 01, 29, 14, 30, 0), 2) { Id = 4 },
                new Showtime(new DateTime(2023, 01, 29, 16, 30, 0), 1) { Id = 5 },
                new Showtime(new DateTime(2023, 01, 30, 13, 30, 0), 4) { Id = 6 });
            builder.HasAlternateKey(p => new { p.WhenShowtime, p.MovieId });
        }
    }
}

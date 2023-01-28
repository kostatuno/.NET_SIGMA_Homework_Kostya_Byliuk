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
    public class HallPositionConfiguration : IEntityTypeConfiguration<HallPosition>
    {
        public void Configure(EntityTypeBuilder<HallPosition> builder)
        {
            builder.HasData(new HallPosition(12, 2) { Id = 1 },
                new HallPosition(9, 2) { Id = 2 },
                new HallPosition(8, 2) { Id = 3 },
                new HallPosition(10, 3) { Id = 4 },
                new HallPosition(11, 3) { Id = 5 },
                new HallPosition(12, 3) { Id = 6 },
                new HallPosition(13, 3) { Id = 7 },
                new HallPosition(13, 1) { Id = 8 },
                new HallPosition(14, 1) { Id = 9 },
                new HallPosition(15, 1) { Id = 10 });
        }
    }
}

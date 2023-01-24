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
    public class HallPositionConfiguration : IEntityTypeConfiguration<HallPosition>
    {
        public void Configure(EntityTypeBuilder<HallPosition> builder)
        {
            builder.HasData(new HallPosition(1, 12, 1),
                new HallPosition(2, 15, 1),
                new HallPosition(3, 8, 2),
                new HallPosition(4, 10, 3),
                new HallPosition(5, 19, 3),
                new HallPosition(6, 9, 1),
                new HallPosition(7, 7, 3));
        }
    }
}

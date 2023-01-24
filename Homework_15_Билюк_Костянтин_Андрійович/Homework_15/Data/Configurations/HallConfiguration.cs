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
    public class HallConfiguration : IEntityTypeConfiguration<Hall>
    {
        public void Configure(EntityTypeBuilder<Hall> builder)
        {
            builder.HasData(new Hall(1, "12G", 1),
                new Hall(2, "12G", 3),
                new Hall(3, "9F", 2),
                new Hall(4, "12G", 3),
                new Hall(5, "2J", 4),
                new Hall(6, "13D", 4),
                new Hall(7, "9F", 1));
        }
    }
}

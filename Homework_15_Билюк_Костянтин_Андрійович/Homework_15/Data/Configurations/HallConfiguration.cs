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
            builder.HasData(new Hall("12G", 1) { Id = 1 },
                new Hall("12T", 3) { Id = 2 },
                new Hall("9F", 2) { Id = 3 },
                new Hall("13T", 3) { Id = 4 },
                new Hall("2F", 2) { Id = 5 },
                new Hall("13G", 1) { Id = 6 },
                new Hall("9G", 1) { Id = 7 });
        }
    }
}

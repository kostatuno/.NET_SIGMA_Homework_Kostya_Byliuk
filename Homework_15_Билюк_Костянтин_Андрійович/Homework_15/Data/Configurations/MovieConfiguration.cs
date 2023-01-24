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
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasData(new Movie(1, "War and Peace"),
                new Movie(2, "Green book"),
                new Movie(3, "Bullet Train"),
                new Movie(4, "Black Adam"));
        }
    }
}

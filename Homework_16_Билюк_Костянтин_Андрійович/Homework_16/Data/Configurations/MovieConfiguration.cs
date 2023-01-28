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
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasData(new Movie("War and Peace") { Id = 1 },
                new Movie("Green book") { Id = 2 },
                new Movie("Bullet Train") { Id = 3 },
                new Movie("Black Adam") { Id = 4 });
            builder.HasAlternateKey(m => m.Name);
        }
    }
}

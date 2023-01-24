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
    public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.HasData(new Cinema("GoodGood", "Луганськ, вул. Пирогова 12") { Id = 1 },
                new Cinema("ValueHappy", "Київ, просп. Фізкультури, 40") { Id = 2 },
                new Cinema("ViewOfKyiv", "Запоріжжя, пл. Фізкультур 55") { Id = 3 },
                new Cinema("DeepView", "Житомир, вул. Пропаща 54") { Id = 4 },
                new Cinema("Barabash", "Одеса, пл. Володимирська 12") { Id = 5 });
            builder.HasAlternateKey(b => b.Address);
        }
    }
}

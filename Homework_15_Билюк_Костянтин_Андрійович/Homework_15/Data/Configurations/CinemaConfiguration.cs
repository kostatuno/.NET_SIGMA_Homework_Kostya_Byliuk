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
            builder.HasData(new Cinema(1, "GoodGood", "Луганськ, вул. Пирогова 12"),
                new Cinema(2, "ValueHappy", "Київ, просп. Фізкультури, 40"),
                new Cinema(3, "ViewOfKyiv", "Запоріжжя, пл. Фізкультур 55"),
                new Cinema(4, "DeepView", "Запоріжжя, пл. Фізкультур 51"),
                new Cinema(5, "Barabash", "Одеса, пл. Володимирська 12"));
        }
    }
}

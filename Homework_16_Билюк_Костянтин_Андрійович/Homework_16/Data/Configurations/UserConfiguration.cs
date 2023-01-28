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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User("Antom", "Pavlenko", "0978189212") { Id = 1 },
                new User("Tom", "Bazylui", "0918989412") { Id = 2 },
                new User("Yordan", "Volyy", "0671284712") { Id = 3 },
                new User("Oleksiy", "Novych", "0728912112") { Id = 4 },
                new User("Grugoriy", "Pavlenko", "0681182592") { Id = 5 },
                new User("Ostap", "Sovok", "0978123456") { Id = 6 },
                new User("Dmytro", "Vinyk", "0959981232") { Id = 7 });
            builder.Property(p => p.FirstName).HasMaxLength(20);
            builder.Property(p => p.LastName).HasMaxLength(20);
            builder.Property(p => p.PhoneNumber).HasMaxLength(20);
            builder.HasAlternateKey(u => u.PhoneNumber);
            builder.Ignore(p => p.FullName);
            builder.HasCheckConstraint("PhoneNumber", "PhoneNumber LIKE '0[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'");
        }
    }
}

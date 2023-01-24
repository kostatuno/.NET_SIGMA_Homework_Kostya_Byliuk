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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User(1, "Antom", "Pavlenko", "0978189212"),
                new User(2, "Tom", "Bazylui", "0918989412"),
                new User(3, "Yordan", "Volyy", "0671284712"),
                new User(4, "Oleksiy", "Novych", "0728912112"),
                new User(5, "Grugoriy", "Pavlenko", "0681182592"),
                new User(6, "Ostap", "Sovok", "0978123456"),
                new User(7, "Dmytro", "Vinyk", "0959981232"));
        }
    }
}

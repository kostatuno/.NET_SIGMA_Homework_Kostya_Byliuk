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
            throw new NotImplementedException();
        }
    }
}

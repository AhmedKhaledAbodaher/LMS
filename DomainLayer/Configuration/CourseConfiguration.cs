using DomainLayer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {

            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Courses).WithOne(x => x.Level).HasForeignKey(x => x.LevelId);


        }
    }
}

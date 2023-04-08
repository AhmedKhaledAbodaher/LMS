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
    public class CourseFileConfiguration : IEntityTypeConfiguration<CourseFiles>
    {
        public void Configure(EntityTypeBuilder<CourseFiles> builder)
        {

            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.Course).WithMany(x=>x.CourseFiles).HasForeignKey(x=>x.CourseId);

        }
    }
}

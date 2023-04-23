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
    public class CourseFileTypeConfiguration : IEntityTypeConfiguration<CourseFileType>
    {
        public void Configure(EntityTypeBuilder<CourseFileType> builder)
        {

            builder.HasKey(x => x.Id);
           builder.HasMany(x=>x.CourseFiles).WithOne(x=>x.CourseFileType).HasForeignKey(x=>x.CourseFileTypeId);
            builder.HasData(
                new CourseFileType() { Id=1,CourseType="pr"},
                new CourseFileType() { Id=2,CourseType="th"}
                );

        }
    }
}

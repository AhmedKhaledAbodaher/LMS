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
    public class LevelConfiguration : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {

            builder.HasKey(x => x.Id);
            builder.HasData(
                new Level { Id=1,LevelName="First Level"},
                new Level { Id = 2, LevelName="Second Level"},
                new Level { Id = 3, LevelName="Third Level"}
                );


        }
    }
}

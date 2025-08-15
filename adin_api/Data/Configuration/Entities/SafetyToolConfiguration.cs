using adin_api.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace adin_api.Data.Configuration.Entities
{
    public class SafetyToolConfiguration : IEntityTypeConfiguration<SafetyTool>
    {
        public void Configure(EntityTypeBuilder<SafetyTool> builder)
        {
            builder.HasData(
                new SafetyTool
                {
                    Id = 1,
                    Name = "Safety tool 1"
                },
                new SafetyTool
                {
                    Id = 2,
                    Name = "Safety tool 2"
                },
                new SafetyTool
                {
                    Id = 3,
                    Name = "Safety tool 3"
                }
                );
        }
    }
}

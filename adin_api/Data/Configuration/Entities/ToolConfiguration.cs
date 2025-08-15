using adin_api.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace adin_api.Data.Configuration.Entities
{
    public class ToolConfiguration : IEntityTypeConfiguration<Tool>
    {
        public void Configure(EntityTypeBuilder<Tool> builder)
        {
            builder.HasData(
                new Tool
                {
                    Id = 1,
                    Name = "Tool 1"
                },
                new Tool
                {
                    Id = 2,
                    Name = "Tool 2"
                },
                new Tool
                {
                    Id = 3,
                    Name = "Tool 3"
                },
                new Tool
                {
                    Id = 4,
                    Name = "Tool 4"
                },
                new Tool
                {
                    Id = 5,
                    Name = "Tool 5"
                }
                );
        }
    }
}

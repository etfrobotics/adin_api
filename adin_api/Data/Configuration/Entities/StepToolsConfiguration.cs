using adin_api.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace adin_api.Data.Configuration.Entities
{
    public class StepToolsConfiguration : IEntityTypeConfiguration<StepTool>
    {
        public void Configure(EntityTypeBuilder<StepTool> builder)
        {
            builder.HasData(
                new StepTool
                {
                    Id = 1,
                    StepId = 1,
                    ToolId = 1
                },
                new StepTool
                {
                    Id = 2,
                    StepId = 2,
                    ToolId = 2
                },
                new StepTool
                {
                    Id = 3,
                    StepId = 3,
                    ToolId = 3
                },
                new StepTool
                {
                    Id = 4,
                    StepId = 4,
                    ToolId = 2
                },
                new StepTool
                {
                    Id = 5,
                    StepId = 5,
                    ToolId = 3
                },
                new StepTool
                {
                    Id = 6,
                    StepId = 6,
                    ToolId = 4
                }
                );
        }
    }
}

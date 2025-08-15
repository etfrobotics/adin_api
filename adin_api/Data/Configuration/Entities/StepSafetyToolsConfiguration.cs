using adin_api.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace adin_api.Data.Configuration.Entities
{
    public class StepSafetyToolsConfiguration : IEntityTypeConfiguration<StepSafetyTool>
    {
        public void Configure(EntityTypeBuilder<StepSafetyTool> builder)
        {
            builder.HasData(
                new StepSafetyTool
                {
                    Id = 1,
                    StepId = 2,
                    SafetyToolId = 3                
                },
                new StepSafetyTool
                {
                    Id = 2,
                    StepId = 3,
                    SafetyToolId = 2
                },
                new StepSafetyTool
                {
                    Id = 3,
                    StepId = 6,
                    SafetyToolId = 1
                }
                );
        }
    }
}

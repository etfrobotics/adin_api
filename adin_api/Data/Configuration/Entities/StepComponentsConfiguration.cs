using adin_api.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace adin_api.Data.Configuration.Entities
{
    public class StepComponentsConfiguration : IEntityTypeConfiguration<StepComponent>
    {
        public void Configure(EntityTypeBuilder<StepComponent> builder)
        {
            builder.HasData(
                new StepComponent
                {
                    Id = 1,
                    StepId = 1,
                    ComponentId = 1
                },
                new StepComponent
                {
                    Id = 2,
                    StepId = 1,
                    ComponentId = 2
                },
                new StepComponent
                {
                    Id = 3,
                    StepId = 2,
                    ComponentId = 3
                },
                new StepComponent
                {
                    Id = 4,
                    StepId = 3,
                    ComponentId = 4
                },
                new StepComponent
                {
                    Id = 5,
                    StepId = 4,
                    ComponentId = 5
                },
                new StepComponent
                {
                    Id = 6,
                    StepId = 5,
                    ComponentId = 2
                },
                new StepComponent
                {
                    Id = 7,
                    StepId = 5,
                    ComponentId = 3
                },
                new StepComponent
                {
                    Id = 8,
                    StepId = 6,
                    ComponentId = 5
                }
                );
        }
    }
}

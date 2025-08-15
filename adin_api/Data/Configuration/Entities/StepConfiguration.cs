using adin_api.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace adin_api.Data.Configuration.Entities
{
    public class StepConfiguration : IEntityTypeConfiguration<Step>
    {
        public void Configure(EntityTypeBuilder<Step> builder)
        {
            builder.HasData(
                new Step
                {
                    Id = 1,
                    Instructions = "Step 1 of task 1",
                    StepNumber = 1,
                    TaskId = 1
                },
                new Step
                {
                    Id = 2,
                    Instructions = "Step 2 of task 1",
                    StepNumber = 2,
                    TaskId = 1
                },
                new Step
                {
                    Id = 3,
                    Instructions = "Step 3 of task 1",
                    StepNumber = 3,
                    TaskId = 1
                },
                new Step
                {
                    Id = 4,
                    Instructions = "Step 1 of task 2",
                    StepNumber = 1,
                    TaskId = 2
                },
                new Step
                {
                    Id = 5,
                    Instructions = "Step 1 of task 3",
                    StepNumber = 1,
                    TaskId = 3
                },
                new Step
                {
                    Id = 6,
                    Instructions = "Step 2 of task 3",
                    StepNumber = 2,
                    TaskId = 3
                }
                );
        }
    }
}

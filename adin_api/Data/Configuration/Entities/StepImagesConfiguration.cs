using adin_api.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adin_api.Data.Configuration.Entities
{

    public class StepImagesConfiguration : IEntityTypeConfiguration<StepImage>
    {
        public void Configure(EntityTypeBuilder<StepImage> builder)
        {
            builder.HasData(
                new StepImage
                {
                    Id = 1,
                    StepId = 1,
                    ImageId = 1
                },
                new StepImage
                {
                    Id = 2,
                    StepId = 1,
                    ImageId = 2
                },
                new StepImage
                {
                    Id = 3,
                    StepId = 2,
                    ImageId = 3
                }
                );
        }
    }
}

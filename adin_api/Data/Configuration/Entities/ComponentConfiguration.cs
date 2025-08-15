using adin_api.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace adin_api.Data.Configuration.Entities
{
    public class ComponentConfiguration : IEntityTypeConfiguration<Component>
    {
        public void Configure(EntityTypeBuilder<Component> builder)
        {
            builder.HasData(
                new Component
                {
                    Id = 1,
                    Name = "Component 1"
                },
                new Component
                {
                    Id = 2,
                    Name = "Component 2"
                },
                new Component
                {
                    Id = 3,
                    Name = "Component 3"
                },
                new Component
                {
                    Id = 4,
                    Name = "Component 4"
                },
                new Component
                {
                    Id = 5,
                    Name = "Component 5"
                }
                );
        }
    }
}

using adin_api.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace adin_api.Data.Configuration.Entities
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasData(
                new Task
                {
                    Id = 1,
                    TaskDescription = "Task 1"
                },
                new Task
                {
                    Id = 2,
                    TaskDescription = "Task 2"
                }, 
                new Task
                {
                    Id = 3,
                    TaskDescription = "Task 3"
                }, 
                new Task
                {
                    Id = 4,
                    TaskDescription = "Task 4"
                }, 
                new Task
                {
                    Id = 5,
                    TaskDescription = "Task 5"
                }, 
                new Task
                {
                    Id = 6,
                    TaskDescription = "Task 6"
                }
                );
        }
    }
}

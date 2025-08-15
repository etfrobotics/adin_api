using adin_api.Data.Configuration.Entities;
using adin_api.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace adin_api.Data
{
    public class DatabaseContext : IdentityDbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<AdminDevice>().HasKey(sc => new { sc.UserId, sc.DeviceId });
            //builder.Entity<AdminCategory>().HasKey(sc => new { sc.UserId, sc.CategoryId });
            //builder.Entity<CategoryDevice>().HasKey(sc => new { sc.CategoryId, sc.DeviceId });
            //builder.Entity<UserCategory>().HasKey(sc => new { sc.UserId, sc.CategoryId });

            builder.ApplyConfiguration(new TaskConfiguration());
            builder.ApplyConfiguration(new StepConfiguration());
            builder.ApplyConfiguration(new ComponentConfiguration());
            builder.ApplyConfiguration(new ToolConfiguration());
            builder.ApplyConfiguration(new ImageConfiguration());
            builder.ApplyConfiguration(new SafetyToolConfiguration());
            builder.ApplyConfiguration(new StepComponentsConfiguration());
            builder.ApplyConfiguration(new StepToolsConfiguration());
            builder.ApplyConfiguration(new StepSafetyToolsConfiguration());
            builder.ApplyConfiguration(new StepImagesConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            
        }

            public DbSet<Task> Tasks { get; set; }
            public DbSet<Step> Steps { get; set; }
            public DbSet<Component> Components { get; set; }
            public DbSet<Tool> Tools { get; set; }
            public DbSet<Image> Images { get; set; }
            public DbSet<SafetyTool> SafetyTools { get; set; }
            public DbSet<StepComponent> StepComponents { get; set; }
            public DbSet<StepTool> StepTools { get; set; }
            public DbSet<StepSafetyTool> StepSafetyTools { get; set; }
            public DbSet<StepImage> StepImages { get; set; }
            
            
    
        

    }
}

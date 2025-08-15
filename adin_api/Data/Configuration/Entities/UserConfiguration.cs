using adin_api.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adin_api.Data.Configuration.Entities
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        private const string petarId = "862fbcc9-5a69-4703-b466-ef175817bf96";
        private const string dzoniId = "862fbcc9-5a69-4703-b466-ef1758171234";

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                //new User
                //{
                //    Id = petarId,
                //    PasswordHash = "AQAAAAEAACcQAAAAEMbNCPil1FBdcC6vgKp1vZigv037kaNWi12dyn0Ls46ohpaDNomvAp9pt4n7IxJwAA==",
                //    Email = "user@example.com",
                //    NormalizedEmail = "USER@EXAMPLE.COM",
                //    UserName = "user@example.com",
                //    NormalizedUserName = "USER@EXAMPLE.COM",
                //    FirstName = "Petar",
                //    LastName = "Jandrić"
                //},
                new User
                {
                    Id = dzoniId,
                    PasswordHash = "AQAAAAEAACcQAAAAELLbUJfcY2AhemC+IeRr8wCXLCAZnfz4AOyavyLGsin2sx3Nc4eimdzlvKdciKS3PQ==", //AdinApp2022!
                    Email = "knezevic@etf.rs",
                    NormalizedEmail = "KNEZEVIC@ETF.RS",
                    UserName = "knezevic@etf.rs",
                    NormalizedUserName = "KNEZEVIC@ETF.RS",
                    FirstName = "Nikola",
                    LastName = "Knežević"
                });
        }
    }
}

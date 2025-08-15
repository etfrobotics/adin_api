using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adin_api.Data.Configuration.Entities
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        private const string petarId = "862fbcc9-5a69-4703-b466-ef175817bf96";
        private const string dzoniId = "862fbcc9-5a69-4703-b466-ef1758171234";

        private const string userId = "8d5f4c90-f0fc-46ad-9413-afe0d3701531";
        private const string adminId = "8872b296-a5d8-4113-b3c0-6f58a3da25b2";

        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                //new IdentityUserRole<string>
                //{
                //    UserId = petarId,
                //    RoleId = adminId
                //},

                new IdentityUserRole<string>
                {
                    UserId = dzoniId,
                    RoleId = adminId
                }
            );
        }
    }
}

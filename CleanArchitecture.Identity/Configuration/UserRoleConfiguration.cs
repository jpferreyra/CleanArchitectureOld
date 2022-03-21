using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "6f20ae7f-35b6-4edc-bf9a-75bda20b7275",
                    RoleId = "4e2348fe-e07d-4828-8077-2a183fa813d5"
                },
                new IdentityUserRole<string>
                {
                    UserId = "fda981a9-fb29-45c5-aeaf-1317e7c5d9a5",
                    RoleId = "d067718e-1483-4890-8272-afb2f9f7f8cf"
                });
        }
    }
}

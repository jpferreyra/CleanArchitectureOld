using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
            new ApplicationUser
            {
                Id = "6f20ae7f-35b6-4edc-bf9a-75bda20b7275",
                Email = "admin@localhost.com",
                NormalizedEmail = "admin@localhost.com",
                Name = "Jhon",
                LastName = "Connor",
                UserName = "admin@localhost.com",
                PasswordHash = hasher.HashPassword(null, "JhonConnor2025$"),
                EmailConfirmed = true,
            },
            new ApplicationUser
            {
                Id = "fda981a9-fb29-45c5-aeaf-1317e7c5d9a5",
                Email = "user@localhost.com",
                NormalizedEmail = "user@localhost.com",
                Name = "JhonUser",
                LastName = "ConnorUser",
                UserName = "user@localhost.com",
                PasswordHash = hasher.HashPassword(null, "JhonConnor2025$"),
                EmailConfirmed = true,
            });
        }
    }
}
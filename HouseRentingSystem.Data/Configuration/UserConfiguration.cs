using HouseRentingSystem.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRentingSystem.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {


        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
  
            builder.HasData(SeedUsers());
        }
        private ICollection<ApplicationUser> SeedUsers()
        {          
            var hasher = new PasswordHasher<ApplicationUser>();
           ApplicationUser agentUser = new ApplicationUser()
            {
                Id = Guid.Parse("dea12856-c198-4129-b3f3-b893d8395082"),
                UserName = "agent@mail.com",
                NormalizedUserName = "agent@mail.com",
                Email = "agent@mail.com",
                NormalizedEmail = "agent@mail.com"
            };

            agentUser.PasswordHash = hasher.HashPassword(agentUser, "agent123");

           ApplicationUser guestUser = new ApplicationUser()
            {
                Id = Guid.Parse("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com"
            };
            guestUser.PasswordHash = hasher.HashPassword(guestUser, "guest123");

            ICollection<ApplicationUser> users = new HashSet<ApplicationUser>();

            users.Add(agentUser);
            users.Add(guestUser);
            return users;
        }
    }
}

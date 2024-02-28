using HouseRentingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRentingSystem.Data.Configuration
{
    public class AgentConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.HasData(SeedAgent());
        }

        private Agent SeedAgent()
        {
          Agent agent = new Agent()
            {
                Id = Guid.Parse("9ef6f4e8-891e-49d3-8bad-69ff127c9951"),
                PhoneNumber = "+359888888888",
                UserId = Guid.Parse("dea12856-c198-4129-b3f3-b893d8395082"),
            };
            return agent;

        }


    }
}

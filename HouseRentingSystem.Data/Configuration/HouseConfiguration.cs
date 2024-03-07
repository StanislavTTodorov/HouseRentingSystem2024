using HouseRentingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRentingSystem.Data.Configuration
{
    public class HouseConfiguration : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {

            builder.Property(h => h.CreateOn)
                .HasDefaultValueSql("GETDATE()");

            builder
                .HasOne(c => c.Category)
                .WithMany(h => h.Houses)
                .HasForeignKey(h => h.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Agent)
                .WithMany(h => h.OwnedHouses)
                .HasForeignKey(h => h.AgentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(SeedHouses());
        }
        private ICollection<House> SeedHouses()
        {

            House firstHouse = new House()
            {
                Id = Guid.NewGuid(),
                Title = "Big House Marina",
                Address = "North London, UK (near the border)",
                Description = "A big house for your whole family. Don't miss to buy a house with three bedrooms.",
                ImageUrl = "https://www.bhg.com/thmb/H9VV9JNnKl-H1faFXnPlQfNprYw=/1799x0/filters:no_upscale():strip_icc()/white-modern-house-curved-patio-archway-c0a4a3b3-aa51b24d14d0464ea15d36e05aa85ac9.jpg",
                PricePerMonth = 2100.00M,
                CategoryId = 3,
                AgentId = Guid.Parse("9ef6f4e8-891e-49d3-8bad-69ff127c9951"),
                RenterId = Guid.Parse("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e")
            };

            House secondHouse = new House()
            {
                Id = Guid.NewGuid(),
                Title = "Family House Comfort",
                Address = "Near the Sea Garden in Burgas, Bulgaria",
                Description = "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.",
                ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1",
                PricePerMonth = 1200.00M,
                CategoryId = 3,
                AgentId = Guid.Parse("9ef6f4e8-891e-49d3-8bad-69ff127c9951"),
                RenterId = null

            };

            House thirdHouse = new House()
            {
                Id = Guid.NewGuid(),
                Title = "Grand House",
                Address = "Boyana Neighbourhood, Sofia, Bulgaria",
                Description = "This luxurious house is everything you will need. It is just excellent.",
                ImageUrl = "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg",
                PricePerMonth = 2000.00M,
                CategoryId = 2,
                AgentId = Guid.Parse("9ef6f4e8-891e-49d3-8bad-69ff127c9951"),
                RenterId= null
            };

            ICollection<House> houses = new HashSet<House>();

            houses.Add(firstHouse);
            houses.Add(secondHouse);
            houses.Add(thirdHouse);

            return houses;
        }


    }
}

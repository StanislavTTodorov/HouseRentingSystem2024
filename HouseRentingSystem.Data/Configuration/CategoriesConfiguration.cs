using HouseRentingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Xml.Linq;

namespace HouseRentingSystem.Data.Configuration
{
    public class CategoriesConfiguration : IEntityTypeConfiguration<Category>
    {

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(SeedCategories());
        }
        private ICollection<Category> SeedCategories()
        {

            Category cottageCategory = new Category()
            {
                Id = 1,
                Name = "Cottage"
            };

            Category singleCategory = new Category()
            {
                Id = 2,
                Name = "Single-Family"
            };

            Category duplexCategory = new Category()
            {
                Id = 3,
                Name = "Duplex"
            };

            ICollection<Category> categories = new HashSet<Category>();

            categories.Add(cottageCategory);
            categories.Add(singleCategory);
            categories.Add(duplexCategory);

            return categories;
        }
    }

}

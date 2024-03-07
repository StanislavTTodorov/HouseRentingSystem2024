using HouseRentingSystem.Data;
using HouseRentingSystem.Services.Data.Interfaces;
using HouseRentingSystem.Web.ViewModels.Category;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Services.Data
{
    public class CategoryService : ICategoryService
    {
        private readonly HouseRentingDbContext dbContext;

        public CategoryService(HouseRentingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<HouseSelectCategoryFormModel>> AllCategoriesAsync()
        {
            IEnumerable<HouseSelectCategoryFormModel> allCategory = 
                await this.dbContext
                          .Categories
                          .AsNoTracking()
                          .Select(c => new HouseSelectCategoryFormModel
                          {
                            Id = c.Id,
                            Name = c.Name
                          })
                          .ToArrayAsync();
            return allCategory;
        }

        public async Task<IEnumerable<string>> AllCategoryNameAsync()
        {
            IEnumerable<string> categoryName = await this.dbContext
                                                         .Categories
                                                         .Select(c => c.Name)
                                                         .ToArrayAsync();
            return categoryName;
        }

        public async Task<bool> ExistsIdAsync(int id)
        {
            bool result = await this.dbContext
                                    .Categories
                                    .AnyAsync(c => c.Id == id);
            return result;
        }
    }
}

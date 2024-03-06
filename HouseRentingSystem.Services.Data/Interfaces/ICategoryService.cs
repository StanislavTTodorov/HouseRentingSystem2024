using HouseRentingSystem.Web.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<HouseSelectCategoryFormModel>> AllCategoriesAsync();

        Task<bool> ExistsIdAsync(int id);
    }
}

﻿using HouseRentingSystem.Data;
using HouseRentingSystem.Data.Models;
using HouseRentingSystem.Services.Data.Interfaces;
using HouseRentingSystem.Web.ViewModels.Home;
using HouseRentingSystem.Web.ViewModels.House;
using HouseRentingSystem.Web.ViewModels.House.Enums;
using HousesRentingSystem.Services.Data.Models.House;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;

namespace HouseRentingSystem.Services.Data
{
    public class HouseService : IHouseService
    {
        private readonly HouseRentingDbContext dbContext;
        public HouseService(HouseRentingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<AllHousesFilteredAndPagedServiceModel> AllHousesAsync(AllHousesQueryModel queryModel)
        {
            IQueryable<House> housesQuery = this.dbContext
                                                .Houses
                                                .Include(h => h.Category)
                                                .AsQueryable();

            if (string.IsNullOrEmpty(queryModel.Category) == false)
            {
                housesQuery = housesQuery.Where(h => h.Category.Name == queryModel.Category);
            }

            if (string.IsNullOrEmpty(queryModel.SearchString) == false)
            {
                string wildcard = $"%{queryModel.SearchString.ToLower()}%";
                housesQuery = housesQuery.Where(h => EF.Functions.Like(h.Title, wildcard) ||
                                                   EF.Functions.Like(h.Address, wildcard) ||
                                                   EF.Functions.Like(h.Description, wildcard));
            }

            housesQuery = queryModel.HouseSorting switch
            {
                HouseSorting.Newest => housesQuery.OrderByDescending(h => h.CreateOn),
                HouseSorting.Oldest => housesQuery.OrderBy(h => h.CreateOn),
                HouseSorting.PriceDescending => housesQuery.OrderByDescending(h => h.PricePerMonth),
                HouseSorting.PriceAscending => housesQuery.OrderBy(h => h.PricePerMonth),
                _ => housesQuery.OrderBy(h => h.RenterId != null)
                                .OrderByDescending(h => h.CreateOn)
            };

            IEnumerable<HouseAllViewModel> allHouses = await housesQuery.Skip((queryModel.CurrentPage - 1) * queryModel.HousesPerPage)
                                                                  .Take(queryModel.HousesPerPage)
                                                                  .Select(h => new HouseAllViewModel()
                                                                  {
                                                                      Id = h.Id.ToString(),
                                                                      Title = h.Title,
                                                                      Address = h.Address,
                                                                      ImageUrl = h.ImageUrl,
                                                                      PricePerMonth = h.PricePerMonth,
                                                                      IsRented = h.RenterId.HasValue
                                                                  })
                                                                  .ToArrayAsync();

            int totalHouses = housesQuery.Count();


            return new AllHousesFilteredAndPagedServiceModel()
            {
                TotalHousesCount = totalHouses,
                Houses = allHouses
            };
        }

        public async Task CreateHouseAsync(HouseFormModel formModel, string agentId)
        {
            House newHouse = new House()
            {
                Title = formModel.Title,
                Address = formModel.Address,
                Description = formModel.Description,
                ImageUrl = formModel.ImageUrl,
                PricePerMonth = formModel.PricePerMonth,
                CategoryId = formModel.CategoryId,
                AgentId = Guid.Parse(agentId)
            };

            await dbContext.Houses.AddAsync(newHouse);
            await dbContext.SaveChangesAsync();        
        }

        public async Task<IEnumerable<IndexViewModel>> LastThreeHousesAsync()
        {
           IEnumerable<IndexViewModel> lastThreeHouses =  await dbContext.Houses
                                  .OrderByDescending(h => h.CreateOn)
                                  .Take(3)
                                  .AsNoTracking()
                                  .Select(h => new IndexViewModel()
                                  {
                                      Id = h.Id.ToString(),
                                      Title = h.Title,
                                      ImageUrl = h.ImageUrl,
                                  }).ToListAsync();

            return lastThreeHouses;
                                
        }
    }
}

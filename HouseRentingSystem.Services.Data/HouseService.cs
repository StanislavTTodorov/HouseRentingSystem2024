﻿using HouseRentingSystem.Data;
using HouseRentingSystem.Data.Models;
using HouseRentingSystem.Services.Data.Interfaces;
using HouseRentingSystem.Web.ViewModels.Agent;
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

        public async Task<IEnumerable<HouseAllViewModel>> AllByAgentIdAsync(string agentId)
        {
            IEnumerable<HouseAllViewModel> allAgentHouses =
                await this.dbContext
                          .Houses
                          .Where(h => h.IsActive &&
                                      h.AgentId.ToString() == agentId)
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

            return allAgentHouses;
        }

        public async Task<IEnumerable<HouseAllViewModel>> AllByUserIdAsync(string userId)
        {
            IEnumerable<HouseAllViewModel> allUserHouses = 
                await this.dbContext
                          .Houses
                          .Where(h => h.IsActive &&
                                      h.RenterId.HasValue &&
                                      h.RenterId.ToString() == userId)
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
            return allUserHouses;
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

            if (string.IsNullOrEmpty(queryModel.SearchString) == false))
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
                                .ThenByDescending(h => h.CreateOn)
            };

            IEnumerable<HouseAllViewModel> allHouses = await housesQuery
                                                                  .Where(h => h.IsActive == true)
                                                                  .Skip((queryModel.CurrentPage - 1) * queryModel.HousesPerPage)
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

        public async Task<HouseDetailsViewModel?> GetHouseDetailsByIdAsync(string houseId)
        {
            House? house = await this.dbContext
                .Houses
                .Include(h=>h.Category)
                .Include(h=>h.Agent)
                .ThenInclude(a=>a.User)
                .Where(h => h.IsActive)
                .FirstOrDefaultAsync();

            if (house == null)
            {
                return null;
            }

            return new HouseDetailsViewModel
            {
                Id = house.Id.ToString(),
                Title = house.Title,
                Address = house.Address,
                Description = house.Description,
                ImageUrl = house.ImageUrl,
                PricePerMonth = house.PricePerMonth,
                Category = house.Category.Name,
                IsRented = house.RenterId.HasValue,
                Agent = new AgentInfoHouseViewModel()
                {
                    Email = house.Agent.User.Email.ToString(),
                    PhoneNumber = house.Agent.PhoneNumber
                }
            };


        }

        public async Task<IEnumerable<IndexViewModel>> LastThreeHousesAsync()
        {
            IEnumerable<IndexViewModel> lastThreeHouses = await dbContext.Houses
                                   .Where(h => h.IsActive == true)
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

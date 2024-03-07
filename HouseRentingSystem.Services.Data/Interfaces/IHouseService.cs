﻿using HouseRentingSystem.Web.ViewModels.Home;
using HouseRentingSystem.Web.ViewModels.House;
using HousesRentingSystem.Services.Data.Models.House;

namespace HouseRentingSystem.Services.Data.Interfaces
{
    public interface IHouseService
    {
        Task<IEnumerable<IndexViewModel>> LastThreeHousesAsync();

        Task CreateHouseAsync(HouseFormModel formModel,string agentId);

        Task<AllHousesFilteredAndPagedServiceModel> AllHousesAsync(AllHousesQueryModel queryModel);

        Task<IEnumerable<HouseAllViewModel>> AllByAgentIdAsync(string agentId);

        Task<IEnumerable<HouseAllViewModel>> AllByUserIdAsync(string userId);

        Task<HouseDetailsViewModel?> GetHouseDetailsByIdAsync(string houseId);


    }
}

using HouseRentingSystem.Services.Data.Interfaces;
using HouseRentingSystem.Web.Infrastructure.Extensions;
using HouseRentingSystem.Web.ViewModels.House;
using HousesRentingSystem.Services.Data.Models.House;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static HouseRentingSystem.Common.NotificationMessagesConstants;

namespace HouseRentingSystem.Web.Controllers
{
    [Authorize]
    public class HouseController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IHouseService houseService;
        private readonly IAgentService agentService;

        public HouseController(ICategoryService categoryService,
                               IHouseService houseService,
                               IAgentService agentService)
        {
            this.categoryService = categoryService;
            this.houseService = houseService;
            this.agentService = agentService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllHousesQueryModel queryModel)
        {
            AllHousesFilteredAndPagedServiceModel serviceModel = await this.houseService
                                                                           .AllHousesAsync(queryModel);

            queryModel.Houses = serviceModel.Houses;
            queryModel.TotalHouses = serviceModel.TotalHousesCount;
            queryModel.Categories = await this.categoryService.AllCategoryNameAsync();

            return this.View(queryModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            string userId = this.User.GetId();
            bool isAgent = await this.agentService.AgentExistsByUserIdAsync(userId);
            if (isAgent == false)
            {
                this.TempData[ErrorMessage] = "You must become an agent in order to add new houses!";
                return RedirectToAction("Become", "Agent");
            }

            HouseFormModel model = new HouseFormModel()
            {
                Categories = await this.categoryService.AllCategoriesAsync()
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(HouseFormModel model)
        {
            string userId = this.User.GetId();
            bool isAgent = await this.agentService
                                     .AgentExistsByUserIdAsync(userId);
            if (isAgent == false)
            {
                this.TempData[ErrorMessage] = "You must become an agent in order to add new houses!";
                return this.RedirectToAction("Become", "Agent");
            }

            bool categoryExists = await this.categoryService
                                            .ExistsIdAsync(model.CategoryId);
            if (categoryExists == false)
            {
                this.ModelState.AddModelError(nameof(model.CategoryId), "Selected category does not exist!");
            }

            if (!this.ModelState.IsValid)
            {
                model.Categories = await this.categoryService
                                             .AllCategoriesAsync();
                return this.View(model);
            }

            try
            {
                string? agentId = await this.agentService.GetAgentIdByUserIdAsync(userId!);
                await this.houseService.CreateHouseAsync(model,agentId!);
            }
            catch (Exception)
            {
                model.Categories = await this.categoryService.AllCategoriesAsync();
                this.ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add you new houses!! Please try agenin later or contact administrator.");
                return this.View(model);
            }
            return this.RedirectToAction("All", "House");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult>Details(string id)
        {
            bool houseExist = await this.houseService.ExistsByIdAsync(id);
            if (!houseExist)
            {
                this.TempData[ErrorMessage] = "House with the provided id does not exist!";
                return this.RedirectToAction("All", "House");
            }
          
            try
            {
                HouseDetailsViewModel viewModel = await this.houseService.GetHouseDetailsByIdAsync(id);

                return View(viewModel);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred! Please try agenin later or contact administrator.";
                return this.RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult>Edit(string id)
        {
            bool isExist = await this.houseService.ExistsByIdAsync(id);
            if (isExist == false)
            {
                this.TempData[ErrorMessage] = "House with the provided houseId does not exist!";
                return this.RedirectToAction("All", "House");

            }

            string userId = this.User.GetId();
            bool isAgent = await this.agentService.AgentExistsByUserIdAsync(userId);
            if (isAgent == false)
            {
                this.TempData[ErrorMessage] = "You must become an agent in order to edit house info!";
                return RedirectToAction("Become", "Agent");
            }

            string? agentId = await this.agentService.GetAgentIdByUserIdAsync(userId);
            bool isOwner = await this.houseService.IsAgentWithIdOwnerOfHouseWithIdAsync(id, agentId!);
            if (isOwner == false)
            {
                this.TempData[ErrorMessage] = "You must be the agent owner of the house you want to edit!";
                return RedirectToAction("Mine", "House");
            }
            try
            {
                HouseFormModel model = await this.houseService.GetHouseEdidByIdAsync(id);
                model.Categories = await this.categoryService.AllCategoriesAsync();
                return this.View(model);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred! Please try agenin later or contact administrator.";
                return this.RedirectToAction("Index", "Home");
            }
            
           
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string id,HouseFormModel model)
        {
            if (ModelState.IsValid)
            {
                model.Categories = await this.categoryService.AllCategoriesAsync();
                return this.View(model);
            }

            bool isExist = await this.houseService.ExistsByIdAsync(id);
            if (isExist == false)
            {
                this.TempData[ErrorMessage] = "House with the provided houseId does not exist!";
                return this.RedirectToAction("All", "House");

            }

            string userId = this.User.GetId();
            bool isAgent = await this.agentService.AgentExistsByUserIdAsync(userId);
            if (isAgent == false)
            {
                this.TempData[ErrorMessage] = "You must become an agent in order to edit house info!";
                return RedirectToAction("Become", "Agent");
            }

            string? agentId = await this.agentService.GetAgentIdByUserIdAsync(userId);
            bool isOwner = await this.houseService.IsAgentWithIdOwnerOfHouseWithIdAsync(id, agentId!);
            if (isOwner == false)
            {
                this.TempData[ErrorMessage] = "You must be the agent owner of the house you want to edit!";
                return RedirectToAction("Mine", "House");
            }

            try
            {
                await this.houseService.EditHouseByIdAndFormModel(id, model);
            }
            catch (Exception)
            {
                model.Categories = await this.categoryService.AllCategoriesAsync();
                this.ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to update house!! Please try agenin later or contact administrator.");
                return this.View(model);
            }

            return this.RedirectToAction("Details", "House",new { id});
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            List<HouseAllViewModel> models = new List<HouseAllViewModel>();

             string userId = this.User.GetId()!;
            bool isAgent = await this.agentService.AgentExistsByUserIdAsync(userId);
            if (isAgent)
            {
                string? agentId = await this.agentService.GetAgentIdByUserIdAsync(userId);
                models.AddRange(await this.houseService.AllByAgentIdAsync(agentId!));
                 
            }
            else
            {
                models.AddRange(await this.houseService.AllByUserIdAsync(userId!));
            }

            return this.View(models);
        }
    }
}

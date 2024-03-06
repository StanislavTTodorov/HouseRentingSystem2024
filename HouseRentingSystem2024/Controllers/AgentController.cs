using HouseRentingSystem.Services.Data.Interfaces;
using HouseRentingSystem.Web.Infrastructure.Extensions;
using HouseRentingSystem.Web.ViewModels.Agent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using static HouseRentingSystem.Common.NotificationMessagesConstants;

namespace HouseRentingSystem.Web.Controllers
{
    [Authorize]
    public class AgentController : Controller
    {
        private readonly IAgentService agentService;

        public AgentController(IAgentService agentService)
        {
            this.agentService = agentService;
        }

        [HttpGet]
        public async Task<IActionResult>Become()
        {
            string userId = this.User.GetId();

            bool isAgent = await this.agentService.AgentExistsByUserIdAsync(userId);

            if (isAgent)
            {
                TempData[ErrorMessage] = "You are already an agent!";
                return this.RedirectToAction("Index","Home");
            }
            return this.View();
        }
        [HttpPost]
        public async Task<IActionResult> Become(BecomeAgentFormModel model)
        {
            string userId = this.User.GetId();

            bool isAgent = await this.agentService.AgentExistsByUserIdAsync(userId);

            if (isAgent)
            {
                TempData[ErrorMessage] = "You are already an agent!";
                return this.RedirectToAction("Index", "Home");
            }

            bool isPhoneNumberTaken = await this.agentService.AgentExistsByPhoneNumberAsync(model.PhoneNumber);
            if (isPhoneNumberTaken)
            {
                ModelState.AddModelError(nameof(model.PhoneNumber),"Agent with the provided phone number already exists!");
            }
            if(!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            bool userHasActiveRents = await this.agentService.UserHasRentsByUserIdAsync(userId);
            if (userHasActiveRents)
            {
                this.TempData[ErrorMessage] = "You must not have any active rents in order to become an agent!";
                return this.RedirectToAction("Mine", "House");
            }
            try
            {
                await this.agentService.CreateAsync(userId, model);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred while registering you as agent! Please try agenin or later or contact administrator.";
                return this.RedirectToAction("Index", "Home");
            }

            return this.RedirectToAction("All", "House");
        }
    }
}

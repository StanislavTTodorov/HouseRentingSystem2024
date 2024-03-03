using HouseRentingSystem.Services.Data.Interfaces;
using HouseRentingSystem.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            bool isAgent = await this.agentService.AgentExistsByUserId(userId);
            if (isAgent)
            {
               return this.BadRequest();
            }
            return this.View();
        }
    }
}

using HouseRentingSystem.Data;
using HouseRentingSystem.Data.Models;
using HouseRentingSystem.Services.Data.Interfaces;
using HouseRentingSystem.Web.ViewModels.Agent;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Services.Data
{
    public class AgentService : IAgentService
    {
        private readonly HouseRentingDbContext  dbContext;
        public AgentService(HouseRentingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AgentExistsByPhoneNumberAsync(string phoneNumber)
        {
            bool result = await this.dbContext
                                    .Agents
                                    .AnyAsync(a => a.PhoneNumber == phoneNumber);
            return result;
        }

        public async Task<bool> AgentExistsByUserIdAsync(string userId)
        {
            bool result = await this.dbContext
                               .Agents
                               .AnyAsync(a => a.UserId.ToString() == userId);
            return result;
                               
        }

        public async Task CreateAsync(string userId, BecomeAgentFormModel model)
        {
            Agent agent = new Agent()
            {
                UserId = Guid.Parse(userId),
                PhoneNumber = model.PhoneNumber
            };
            await this.dbContext.Agents.AddAsync(agent);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<string?> GetAgentIdByUserIdAsync(string userId)
        {
            Agent? agent = await this.dbContext
                                     .Agents
                                     .FirstOrDefaultAsync(a=>a.UserId.ToString()==userId);
            if (agent == null)
            {
                return null;
            }

            return agent.Id.ToString();
        }

        public async Task<bool> UserHasRentsByUserIdAsync(string userId)
        {
            bool result = await this.dbContext
                                    .Houses.AnyAsync(u => u.RenterId.ToString() == userId);

            return result;
        }
    }
}

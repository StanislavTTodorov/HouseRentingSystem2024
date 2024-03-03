﻿using HouseRentingSystem.Data;
using HouseRentingSystem.Services.Data.Interfaces;
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
        public async Task<bool> AgentExistsByUserId(string userId)
        {
            bool result = await this.dbContext
                               .Agents
                               .AnyAsync(a => a.UserId.ToString() == userId);
            return result;
                               
        }
    }
}

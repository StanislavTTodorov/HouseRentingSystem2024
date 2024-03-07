

using HouseRentingSystem.Web.ViewModels.Agent;

namespace HouseRentingSystem.Web.ViewModels.House
{
    public class HouseDetailsViewModel :HouseAllViewModel
    {
        
        public string Description { get; set; } = null!;

        public string Category { get; set; } = null!;

        public AgentInfoHouseViewModel Agent { get; set; } = null!;

    }
}



using System.ComponentModel.DataAnnotations;

namespace HouseRentingSystem.Web.ViewModels.Agent
{
    public class AgentInfoHouseViewModel
    {
        public string Email { get; set; } = null!;

        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }=null!;
    }
}

using HouseRentingSystem.Services.Data.Interfaces;
using HouseRentingSystem.Web.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HouseRentingSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IHouseService houseService;

        public HomeController(ILogger<HomeController> logger,
                              IHouseService houseService)
        {
            this.logger = logger;
            this.houseService = houseService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<IndexViewModel> viewModel = await this.houseService.LastThreeHousesAsync();
            return View(viewModel);
        }     

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

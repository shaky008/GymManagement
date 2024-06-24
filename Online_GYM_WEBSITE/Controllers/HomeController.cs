using Microsoft.AspNetCore.Mvc;
using Online_GYM_WEBSITE.Models;
using System.Diagnostics;

namespace Online_GYM_WEBSITE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GymManagementDbContext _gymContext;

        public HomeController(ILogger<HomeController> logger, GymManagementDbContext gymContext)
        {
            _logger = logger;
            _gymContext = gymContext;
        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About() {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

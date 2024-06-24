using Microsoft.AspNetCore.Mvc;
using Online_GYM_WEBSITE.Models;
using System.Linq;


namespace Online_GYM_WEBSITE.Controllers
{
    public class AdminController : Controller
    {
        private readonly GymManagementDbContext _context;
        public AdminController(GymManagementDbContext gymdb) {
            _context = gymdb;
        }
        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult AdminMain() {

            var gymDetail = _context.GymMemberships.OrderBy(s => s.GymMembershipId).ToList();
            var memDetail = _context.UserDetails.OrderBy(s => s.UserId).ToList();

            ViewBag.GymDetail = gymDetail;
            ViewBag.MemDetail = memDetail;

            return View();
        }
    }
}

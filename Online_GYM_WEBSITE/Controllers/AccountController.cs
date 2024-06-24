using Microsoft.AspNetCore.Mvc;
using Online_GYM_WEBSITE.Models;
using System.Linq;

namespace Online_GYM_WEBSITE.Controllers
{
    public class AccountController : Controller
    {
        private readonly GymManagementDbContext _gymContext;

        public AccountController(GymManagementDbContext gymdb) {  
            _gymContext = gymdb;
        } 
        public IActionResult Account()
        {
            return View();
        }

        public IActionResult signupUser(UserDetail userD) {
            var userDetail = _gymContext.UserDetails.Where(s => s.UserEmail == userD.UserEmail).FirstOrDefault();
            if (userDetail == null) {
                UserDetail user = new UserDetail();
                user.UserEmail = userD.UserEmail;
                user.UserNumber = userD.UserNumber;
                user.UserName = userD.UserName;
                user.UserType = "customer";


                _gymContext.UserDetails.Add(userDetail);
                _gymContext.SaveChanges();
            }
            return View("Account");
        }
    }
}

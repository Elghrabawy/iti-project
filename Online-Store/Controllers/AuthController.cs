using Microsoft.AspNetCore.Mvc;
using Online_Store.Models;
using Online_Store.ViewModels;

namespace Online_Store.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginVM login)
        {
            if(ModelState.IsValid)
            {
                var db = new StoreContext();
                var user = db.Users.FirstOrDefault(u => u.Username == login.Username && u.Password == login.Password);
                if(user != null)
                {
                    var roles = db.Roles.ToList();
                    HttpContext.Session.SetInt32("UserId", user.UserId);
                    HttpContext.Session.SetString("Username", user.Username);

                    var role = roles.FirstOrDefault(r => r.RoleId == user.RoleId).RoleName;
                    if(role != null)
                    {
                        HttpContext.Session.SetString("Role", role);
                    }

                    return RedirectToAction("Index", "Home");
                }
                login.ErrorMessage = "Invalid username or password";
            }
            return View(login);
        }

        public IActionResult Logout()
        {

            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}

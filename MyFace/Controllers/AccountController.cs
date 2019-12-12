using System.Web.Mvc;
using MyFace.Models.ViewModels;
using MyFace.DataAccess;
using System.Web.Security;

namespace MyFace.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult SignUp()
        {
            return View( new LoginViewModel());
        }
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult SignUp(LoginViewModel loginViewModel)
        {
            loginViewModel.Signup();
            return RedirectToAction("Index","UserList");
        }
        [HttpPost]
        public ActionResult Login(Users login)
        {
            var ur = new UserRepository();
            var hp = new HashPassword();
            var getUser = ur.GetUser(login.username);

            foreach (var user in getUser)
            {
                if (login.username == user.username)
                {
                    if (hp.CovertPasswordBack(user.password, login.password))
                    {
                        FormsAuthentication.RedirectFromLoginPage(login.username, true);
                        return RedirectToAction("Index", "UserList");
                    }
                }
            }         
            return RedirectToAction("Index", "UserList");
        }
    }
}
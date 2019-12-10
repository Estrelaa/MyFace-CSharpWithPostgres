using System.Web.Mvc;
using MyFace.Models.ViewModels;
using MyFace.DataAccess;

namespace MyFace.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult SignUp()
        {
            return View( new LoginViewModel());
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
            var users = new Users();
            var UR = new UserRepository();
            var HP = new HashPassword();

            users = UR.GetUser(login);

            if (users.username == login.username)
            {
                if (HP.CovertPasswordBack(users.password, login.password))
                {
                    Session["User"] = users;
                }
            }
            return RedirectToAction("Index", "UserList");
        }
    }
}
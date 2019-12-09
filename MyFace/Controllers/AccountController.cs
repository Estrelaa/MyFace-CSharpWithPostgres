using System.Web.Mvc;
using MyFace.Models.ViewModels;

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
            loginViewModel.OnPost();
            return RedirectToAction("Index","UserList");
        }
    }
}
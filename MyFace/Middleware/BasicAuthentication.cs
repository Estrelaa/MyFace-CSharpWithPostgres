using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFace.Helpers;
using MyFace.DataAccess;

namespace MyFace.Middleware
{
    //TODO Replace basic authentication with a better authentication method.
    public class BasicAuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var req = filterContext.HttpContext.Request;
            var userNameAndPassword = AuthenticationHelper.ExtractUsernameAndPassword(req);
            var Hashpassword = new HashPassword();

            if (userNameAndPassword != null)
            {
                UserRepository userRepository = new UserRepository();
                var users = userRepository.GetAllUsers();

                foreach (var person in users)
                {
                    if (person.username == userNameAndPassword.Username)
                    {
                        
                        if (Hashpassword.CovertPasswordBack(person.password, userNameAndPassword.Password))
                        {
                            return;
                        }
                    }
                }
            }
            const string realm = "MyFace";

            filterContext.HttpContext.Response.AddHeader("WWW-Authenticate", $"Basic realm=\"{realm}\"");
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}
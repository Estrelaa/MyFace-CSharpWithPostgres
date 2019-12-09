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

            if (userNameAndPassword != null)
            {
                //TODO get password from the database.
                // If username and password match in the database
                UserRepository userRepository = new UserRepository();
                var users = userRepository.GetAllUsers();

                foreach (var person in users)
                {
                    if (person.username == userNameAndPassword.Username)
                    {
                        if (person.password == userNameAndPassword.Password)
                        {
                            return;
                        }
                    }
                }
                    // Log them in
            }
            const string realm = "MyFace";

            filterContext.HttpContext.Response.AddHeader("WWW-Authenticate", $"Basic realm=\"{realm}\"");
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}
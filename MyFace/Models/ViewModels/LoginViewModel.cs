using System;
using MyFace.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFace.Models.ViewModels
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public void OnPost()
        {
            var user = new AddUser();
            var EncpytPassword = new HashPassword();

            Password = EncpytPassword.Hashpassword(Password);

            user.AddUserToSite(Username, Password, FullName);
        }
    }
}
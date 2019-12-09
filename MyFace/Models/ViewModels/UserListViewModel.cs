using MyFace.DataAccess;
using System.Collections.Generic;

namespace MyFace.Models.ViewModels
{
    public class UserListViewModel
    {
        public string Username { get; }
        public IEnumerable<Users> ListOfUsers { get; }

        public UserListViewModel(string username, IEnumerable<Users> listOfUsers)
        {
            Username = username;
            ListOfUsers = listOfUsers;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BCrypt;

namespace MyFace.DataAccess
{
    public class HashPassword
    {
        public string Hashpassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public bool CovertPasswordBack(string savedPasswordHash, string TypedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(TypedPassword, savedPasswordHash);
        }
    }
}

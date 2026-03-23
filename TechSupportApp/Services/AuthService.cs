using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechSupportApp.DataAccess;
using TechSupportApp.Models;
using TechSupportApp.Helpers;

namespace TechSupportApp.Services
{
    public class AuthService
    {
        public User Authenticate(string login, string password)
        {
            using (var context = new AppDbContext())
            {
                var user = context.Users.Include(u => u.Role)
                                         .FirstOrDefault(u => u.Login == login);
                if (user != null && PasswordHelper.VerifyPassword(password, user.PasswordHash))
                    return user;
                return null;
            }
        }
    }
}

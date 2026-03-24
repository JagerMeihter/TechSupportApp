using System.Collections.Generic;
using System.Linq;
using TechSupportApp.DataAccess;
using TechSupportApp.Models;
using TechSupportApp.Helpers;


namespace TechSupportApp.Services
{
    public class UserService
    {
        public List<User> GetAllUsers()
        {
            using (var context = new AppDbContext())
            {
                return context.Users.Include(u => u.Role).ToList();
            }
        }

        public void AddUser(User user, string plainPassword)
        {
            using (var context = new AppDbContext())
            {
                user.PasswordHash = PasswordHelper.HashPassword(plainPassword);
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public void UpdateUser(User user, string newPassword = null)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.Users.Find(user.Id);
                if (existing != null)
                {
                    existing.Login = user.Login;
                    existing.FullName = user.FullName;
                    existing.Phone = user.Phone;
                    existing.RoleId = user.RoleId;
                    if (!string.IsNullOrEmpty(newPassword))
                        existing.PasswordHash = PasswordHelper.HashPassword(newPassword);
                    context.SaveChanges();
                }
            }
        }

        public void DeleteUser(int userId)
        {
            using (var context = new AppDbContext())
            {
                var user = context.Users.Find(userId);
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                }
            }
        }

        public List<Role> GetRoles()
        {
            using (var context = new AppDbContext())
            {
                return context.Roles.ToList();
            }
        }
    }
}
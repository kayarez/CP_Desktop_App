using Rattler.Models;
using System;
using System.Linq;

namespace Rattler.Controller
{
    class LoginController
    {
        public User Login(User user)
        {
            try
            {
                MyDbContext context = new MyDbContext();
                User foundUser = context.Users.FirstOrDefault(User => User.Login == user.Login);
                if (foundUser != null)
                {
                    if (foundUser.Password == user.Password && foundUser.Id !=1)
                    {
                        return foundUser;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public User Admin(User user)
        {
            try
            {
                MyDbContext context = new MyDbContext();
                User foundAdmin = context.Users.FirstOrDefault(User => User.Login == user.Login);
                if (foundAdmin != null)
                {
                    if (foundAdmin.Password == user.Password && foundAdmin.Id == 1)
                    {
                        return foundAdmin;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

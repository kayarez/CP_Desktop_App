using Rattler.Models;
using System;
using System.Linq;
using System.Windows;

namespace Rattler.Controller
{
    class RegistrationController
    {


        public bool CheckIfUserExists(User user)
        {
            MyDbContext context = new MyDbContext();
            if (context.Users.FirstOrDefault(User => User.Login == user.Login) != null)
            {
                return true;
            }
            else if (context.Users.FirstOrDefault(User => User.Email == user.Email) != null)
            {
                return true;
            }
            return false;
        }


        public bool Register(User user)
        {
            try
            {
                if (!CheckIfUserExists(user))
                {
                    MyDbContext context = new MyDbContext();
                    context.Users.Add(user);
                    context.SaveChanges();
                    return true;

                }
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
    }
}

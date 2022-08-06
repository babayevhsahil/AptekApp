using Core.Entities;
using Core.Helpers;
using DataAccess.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    public class AdminController
    {
        private AdminRepository _adminRepositories;
        public AdminController()
        {
            _adminRepositories = new AdminRepository();
        }

        public Admin Authenticate()
        {

            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please Enter Admin Username:");
            string userName = Console.ReadLine();

            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please Enter Admin Password:");
            string password = Console.ReadLine();

            var admin = _adminRepositories.Get(a => a.Username.ToLower() == userName.ToLower()
            && PasswordHasher.Decrypt(a.Password) == password);
            return admin;


        }
    }
}

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
    public class OnwerController
    {
        #region CreateOnwer
        public void CreateOnwer()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Onwer Name:");
            string name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
            {

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Onwer Surname:");
                string surname = Console.ReadLine();

                var onwer = new Onwer
                {
                    Name = name,
                    Surname = surname,
                };
                _onwerRepository.Create(onwer);
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name: {name}, Surname: {surname} ");
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Add a number:");
            }

        }
        #endregion
    }
}
